using OnRail;
using OnRail.Extensions.ThrowException;
using OnRail.ResultDetails.Errors;

namespace OnRailTest.Extensions;

public class ThrowExceptionExtensionsTest {
    private readonly ExceptionError _error = new(new Exception("Fake"));

    // ReSharper disable once SuggestBaseTypeForParameter
    private static void CheckThrowException(Action throwExceptionAction) {
        try {
            throwExceptionAction();
            Assert.True(false);
        }
        catch (Exception) {
            Assert.True(true);
        }
    }

    [Fact]
    public void ThrowException_ExceptionError_ThrowException() {
        CheckThrowException(() => _error.ThrowException());
    }

    [Fact]
    public void ThrowException_Chain_ThrowException() {
        object obj = "";
        CheckThrowException(() => obj.ThrowException(_error));
    }

    [Fact]
    public void ThrowExceptionOnFail_SuccessfulConditionWithResult_ReturnResult() {
        var result = Result<string>.Ok("Ok")
            .ThrowExceptionOnFail();

        Assert.True(result.IsSuccess);
        Assert.Equal("Ok", result.Value);
    }

    [Fact]
    public void ThrowExceptionOnFail_FailConditionWithResult_ReturnResult() {
        CheckThrowException(() => Result<string>.Fail(_error)
            .ThrowExceptionOnFail());

        CheckThrowException(() => Result<string>.Fail(_error));
    }

    [Fact]
    public void ThrowExceptionOnFail_SuccessfulCondition_ReturnResult() {
        var result = Result.Ok()
            .ThrowExceptionOnFail();

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void ThrowExceptionOnFail_FailConditionsWith_ReturnResult() {
        CheckThrowException(() => Result.Fail(_error)
            .ThrowExceptionOnFail());

        CheckThrowException(() => Result.Fail(_error));
    }
}