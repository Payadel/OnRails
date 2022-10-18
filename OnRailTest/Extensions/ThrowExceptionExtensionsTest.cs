using OnRail;
using OnRail.Extensions.OnFail;
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
    public void OnFailThrowException_SuccessfulConditionWithResult_ReturnResult() {
        var result = Result<string>.Ok("Ok")
            .OnFailThrowException();

        Assert.True(result.IsSuccess);
        Assert.Equal("Ok", result.Value);
    }

    [Fact]
    public void OnFailThrowException_FailConditionWithResult_ReturnResult() {
        CheckThrowException(() => Result<string>.Fail(_error)
            .OnFailThrowException());

        CheckThrowException(() => Result<string>.Fail(_error));
    }

    [Fact]
    public void OnFailThrowException_SuccessfulCondition_ReturnResult() {
        var result = Result.Ok()
            .OnFailThrowException();

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void OnFailThrowException_FailConditionsWith_ReturnResult() {
        CheckThrowException(() => Result.Fail(_error)
            .OnFailThrowException());

        CheckThrowException(() => Result.Fail(_error));
    }
}