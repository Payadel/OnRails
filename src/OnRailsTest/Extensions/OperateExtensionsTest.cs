using OnRails;
using OnRails.Extensions.OperateWhen;
using OnRails.ResultDetails;

namespace OnRailTest.Extensions;

public static class OperateExtensionsTest {
    private const int DefaultNumOfTry = 3;
    private const string SuccessResult = "result";

    private static void ActionThrowException() {
        throw new Exception("Fake");
    }

    [Fact]
    public static void OperateWhen_SuccessPredicateAndFunctionReturnFail_FailedResult() {
        var result = OperateWhenExtensions.OperateWhen(true,
            () => Result.Fail(), DefaultNumOfTry);

        Assert.False(result.Success);
    }

    [Fact]
    public static void OperateWhen_SuccessPredicateAndFunctionThrowException_FailedResult() {
        var result = OperateWhenExtensions.OperateWhen(true,
            () => {
                throw new Exception("Fake");
                return Result.Ok();
            }, DefaultNumOfTry);

        TestHelpers.EnsureHasFailed(result, DefaultNumOfTry, true);
    }

    [Fact]
    public static void OperateWhen_FailPredicateAndFunctionThrowException_SuccessResult() {
        var result = OperateWhenExtensions.OperateWhen(false,
            () => {
                throw new Exception("Fake");
                return Result.Ok();
            }, DefaultNumOfTry);

        Assert.True(result.Success);
    }

    //
    [Fact]
    public static void OperateWhen_SuccessPredicateFunctionAndFunctionReturnFail_FailedResult() {
        var result = OperateWhenExtensions.OperateWhen(() => true,
            () => Result.Fail(), DefaultNumOfTry);

        Assert.False(result.Success);
    }

    [Fact]
    public static void OperateWhen_SuccessPredicateFunctionAndFunctionThrowException_FailedResult() {
        var result = OperateWhenExtensions.OperateWhen(() => true,
            () => {
                throw new Exception("Fake");
                return Result.Ok();
            }, DefaultNumOfTry);

        TestHelpers.EnsureHasFailed(result, DefaultNumOfTry, true);
    }

    [Fact]
    public static void OperateWhen_FailPredicateFunctionAndFunctionThrowException_SuccessResult() {
        var result = OperateWhenExtensions.OperateWhen(() => false,
            () => {
                throw new Exception("Fake");
                return Result.Ok();
            }, DefaultNumOfTry);

        Assert.True(result.Success);
    }

    [Fact]
    public static void OperateWhen_PredicateThrowException_FailedResult() {
        var result = OperateWhenExtensions.OperateWhen(() => {
                throw new Exception("Fake");
                return true;
            },
            Result.Ok, DefaultNumOfTry);

        TestHelpers.EnsureHasFailed(result, DefaultNumOfTry, true);
    }

    //
    [Fact]
    public static void OperateWhen_SuccessPredicateAndSuccessAction_SuccessResult() {
        var result = OperateWhenExtensions.OperateWhen(true,
            () => { }, DefaultNumOfTry);

        Assert.True(result.Success);
    }

    [Fact]
    public static void OperateWhen_SuccessPredicateAndActionThrowException_FailedResult() {
        var result = OperateWhenExtensions.OperateWhen(true, ActionThrowException, DefaultNumOfTry);

        TestHelpers.EnsureHasFailed(result, DefaultNumOfTry, true);
    }

    [Fact]
    public static void OperateWhen_FailPredicateAndActionThrowException_SuccessResult() {
        var result = OperateWhenExtensions.OperateWhen(false, ActionThrowException, DefaultNumOfTry);

        Assert.True(result.Success);
    }

    //
    [Fact]
    public static void OperateWhen_SuccessPredicateFunctionAndSuccessAction_SuccessResult() {
        var result = OperateWhenExtensions.OperateWhen(() => true,
            () => { }, DefaultNumOfTry);

        Assert.True(result.Success);
    }

    [Fact]
    public static void OperateWhen_SuccessPredicateFunctionAndActionThrowException_FailedResult() {
        var result = OperateWhenExtensions.OperateWhen(() => true, ActionThrowException, DefaultNumOfTry);

        TestHelpers.EnsureHasFailed(result, DefaultNumOfTry, true);
    }

    [Fact]
    public static void OperateWhen_PredicateFunctionThrowException_SuccessResult() {
        var result = OperateWhenExtensions.OperateWhen(() => {
                throw new Exception("Fake");
                return true;
            },
            () => { }, DefaultNumOfTry);

        TestHelpers.EnsureHasFailed(result, DefaultNumOfTry, true);
    }

    [Fact]
    public static void OperateWhen_FailPredicateFunctionAndActionThrowException_SuccessResult() {
        var result = OperateWhenExtensions.OperateWhen(() => false, ActionThrowException, DefaultNumOfTry);

        Assert.True(result.Success);
    }

    //
    [Fact]
    public static void OperateWhen_SuccessPredicateAndFunctionReturnValue_SuccessResultWithValue() {
        var result = "input".OperateWhen(true,
            () => Result<string>.Ok(SuccessResult));

        Assert.True(result.Success);
        Assert.Equal(SuccessResult, result.Value);
    }

    [Fact]
    public static void OperateWhen_SuccessPredicateAndFunctionReturnFailedResult_FailedResult() {
        var result = "input".OperateWhen(true,
            () => Result<string>.Fail(new ErrorDetail()));

        Assert.False(result.Success);
        Assert.True(result.Detail is ErrorDetail);
    }

    [Fact]
    public static void OperateWhen_FailPredicateAndFunctionReturnValue_ResultWithFirstInput() {
        const string firstInput = "input";
        var result = firstInput.OperateWhen(false,
            () => Result<string>.Ok(SuccessResult));

        Assert.True(result.Success);
        Assert.Equal(firstInput, result.Value);
    }

    //
    [Fact]
    public static void OperateWhen_SuccessPredicateResultAndFunctionReturnValue_SuccessResultWithValue() {
        var result = "input".OperateWhen(true,
            () => Result<string>.Ok(SuccessResult));

        Assert.True(result.Success);
        Assert.Equal(SuccessResult, result.Value);
    }

    [Fact]
    public static void OperateWhen_SuccessPredicateResultAndFunctionReturnFailedResult_FailedResult() {
        var result = "input".OperateWhen(true,
            () => Result<string>.Fail(new ErrorDetail()));

        Assert.False(result.Success);
        Assert.True(result.Detail is ErrorDetail);
    }

    [Fact]
    public static void OperateWhen_FailPredicateResultAndFunctionReturnValue_ResultWithFirstInput() {
        const string firstInput = "input";
        var result = firstInput.OperateWhen(false,
            () => Result<string>.Ok(SuccessResult));

        Assert.True(result.Success);
        Assert.Equal(firstInput, result.Value);
    }

    //
    [Fact]
    public static void OperateWhen_OnResultWithValue_SuccessPredicateAndFunctionReturnValue_SuccessResultWithValue() {
        var result = Result<string>.Ok("input")
            .OperateWhen(true,
                () => Result<string>.Ok(SuccessResult));

        Assert.True(result.Success);
        Assert.Equal(SuccessResult, result.Value);
    }

    [Fact]
    public static void OperateWhen_OnResultWithValue_SuccessPredicateAndFunctionReturnFailedResult_FailedResult() {
        var result = Result<string>.Ok("input")
            .OperateWhen(true,
                () => Result<string>.Fail(new ErrorDetail()));

        Assert.False(result.Success);
        Assert.True(result.Detail is ErrorDetail);
    }

    [Fact]
    public static void OperateWhen_OnResultWithValue_FailPredicateAndFunctionReturnValue_ResultWithFirstInput() {
        const string firstInput = "input";
        var result = Result<string>.Ok(firstInput)
            .OperateWhen(false, () => Result<string>.Ok(SuccessResult));

        Assert.True(result.Success);
        Assert.Equal(firstInput, result.Value);
    }

    //
    [Fact]
    public static void OperateWhen_OnResultWithValue_SuccessPredicateAndSuccessAction_SuccessResult() {
        var result = Result<string>.Ok("input")
            .OperateWhen(true,
                () => { }, DefaultNumOfTry);

        Assert.True(result.Success);
    }

    [Fact]
    public static void OperateWhen_OnResultWithValue_SuccessPredicateAndActionThrowException_FailedResult() {
        var result = Result<string>.Ok("input")
            .OperateWhen(true, ActionThrowException, DefaultNumOfTry);

        TestHelpers.EnsureHasFailed(result, DefaultNumOfTry, true);
    }

    [Fact]
    public static void OperateWhen_OnResultWithValue_FailPredicateAndActionThrowException_SuccessResult() {
        var result = Result<string>.Ok("input")
            .OperateWhen(false, ActionThrowException, DefaultNumOfTry);

        Assert.True(result.Success);
    }
}