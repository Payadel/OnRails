using OnRail;
using OnRail.Extensions;
using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;

namespace OnRailTest.Extensions;

public class TryExtensionsTest {
    #region TestMethods

    private const string SuccessStr = "Success";
    private static void SuccessfulAction() { }
    private static void SuccessfulActionWithInput(string input) { }
    private static string SuccessfulFunctionReturnString() => SuccessStr;
    private static string SuccessfulFunctionReturnInput(string input) => input;
    private static Result SuccessfulFunctionReturnResult() => Result.Ok();

    private static Result<string> SuccessfulFunctionReturnResultWithString() =>
        Result<string>.Ok(SuccessStr);

    private static Result<string> SuccessfulFunctionReturnResultWithString(string input) =>
        Result<string>.Ok(input);

    private static void FailAction() => throw new Exception();
    private static void FailActionWithInput(string input) => throw new Exception();
    private static string FailFunctionReturnString() => throw new Exception();
    private static string FailFunctionReturnInput(string input) => throw new Exception();
    private static Result FailFunctionReturnResult() => Result.Fail(new BadRequestError());

    #endregion

    #region Utility

    private static void MustError(ResultBase result, int numOfTry) {
        Assert.False(result.IsSuccess);

        var detailsCount = result.Detail.MoreDetails?.Count;
        if (numOfTry > 1) {
            //We must have two objects: numOfTry - errors
            Assert.Equal(2, detailsCount);
        }
        else {
            //We must have only "numOfTry"
            Assert.Equal(1, detailsCount);
        }

        Assert.Equal(numOfTry, result.Detail.GetMoreDetailProperties("numOfTry", typeof(int)).Single());
    }

    private static void MustExceptionError(ResultBase result, int numOfTry) {
        MustError(result, numOfTry);
        Assert.True(result.Detail is ExceptionError);

        if (numOfTry < 2)
            return;

        var exceptions =
            result.Detail.GetMoreDetailProperties(type: typeof(List<Exception>)).Single() as List<Exception>;
        Assert.Equal(numOfTry, exceptions!.Count);
    }

    private static void MustErrorDetail(ResultBase result, int numOfTry) {
        MustError(result, numOfTry);

        Assert.True(result.Detail is ErrorDetail);
        var exceptions =
            result.Detail.GetMoreDetailProperties(type: typeof(List<object>)).Single() as List<object>;
        Assert.Equal(numOfTry, exceptions!.Count);
    }

    #endregion

    #region Try

    [Fact]
    public void Try_SuccessfulAction_ReturnSuccessDetail() {
        var result = TryExtensions.Try(SuccessfulAction);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Try_SuccessfulActionWithInput_ReturnSuccessDetail() {
        var result = TryExtensions.Try(() => SuccessfulActionWithInput("input"));

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Try_SuccessfulActionWithInput2_ReturnSuccessDetail() {
        const string input = "input";
        var result = input.Try(SuccessfulActionWithInput);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Try_SuccessfulFunction_ReturnString() {
        var result = TryExtensions.Try(SuccessfulFunctionReturnString);

        Assert.True(result.IsSuccess);
        Assert.Equal(SuccessStr, result.Value);
    }

    [Fact]
    public void Try_SuccessfulFunction_ReturnResultWithString() {
        var result = TryExtensions.Try(SuccessfulFunctionReturnResultWithString);

        Assert.True(result.IsSuccess);
        Assert.Equal(SuccessStr, result.Value);
    }

    [Fact]
    public void Try_SuccessfulFunction_ReturnsResult() {
        var result = TryExtensions.Try(SuccessfulFunctionReturnResult);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Try_SuccessfulFunctionWithInput_ReturnInput() {
        const string input = "input";
        var result = TryExtensions.Try(() => SuccessfulFunctionReturnInput(input));

        Assert.True(result.IsSuccess);
        Assert.Equal(input, result.Value);
    }

    [Fact]
    public void Try_SuccessfulFunctionWithInput_ReturnResultWithString() {
        const string input = "input";
        var result = TryExtensions.Try(() => SuccessfulFunctionReturnResultWithString(input));

        Assert.True(result.IsSuccess);
        Assert.Equal(input, result.Value);
    }

    //----------------------------------------------------------------------------
    private static Result<string> FailFunctionReturnResultWithString() =>
        Result<string>.Fail(new BadRequestError());

    private static Result<string> FailFunctionReturnResultWithString(string input) =>
        Result<string>.Fail(new BadRequestError());

    [Fact]
    public void Try_FailAction_ReturnExceptionError() {
        var result = TryExtensions.Try(FailAction);

        MustExceptionError(result, 1);
    }

    [Fact]
    public void Try_FailActionWithRepeat_ReturnExceptionError() {
        const int numOfTry = 3;
        var result = TryExtensions.Try(FailAction, numOfTry);

        MustExceptionError(result, numOfTry);
    }

    [Fact]
    public void Try_FailActionWithInput_ReturnExceptionError() {
        var result = TryExtensions.Try(() => FailActionWithInput("input"));

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
    }

    [Fact]
    public void Try_FailActionWithInputRepeat_ReturnExceptionError() {
        const int numOfTry = 3;
        var result = TryExtensions.Try(() => FailActionWithInput("input"), numOfTry);

        MustExceptionError(result, numOfTry);
    }

    [Fact]
    public void Try_FailActionWithInput2_ReturnExceptionError() {
        const string input = "input";
        var result = input.Try(FailActionWithInput);

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
    }

    [Fact]
    public void Try_FailActionWithInputRepeat2_ReturnExceptionError() {
        const int numOfTry = 3;
        const string input = "input";
        var result = input.Try(FailActionWithInput, numOfTry);

        MustExceptionError(result, numOfTry);
    }

    [Fact]
    public void Try_FailFunction_ReturnExceptionError() {
        var result = TryExtensions.Try(FailFunctionReturnString);

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
    }

    [Fact]
    public void Try_FailFunctionRepeat_ReturnExceptionError() {
        const int numOfTry = 3;
        var result = TryExtensions.Try(FailFunctionReturnString, numOfTry);

        MustExceptionError(result, numOfTry);
    }

    [Fact]
    public void Try_FailFunction_ReturnBadRequestError() {
        var result = TryExtensions.Try(FailFunctionReturnResultWithString);

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is BadRequestError);
    }

    [Fact]
    public void Try_FailFunctionRepeat_ReturnErrorDetail() {
        const int numOfTry = 3;
        var result = TryExtensions.Try(FailFunctionReturnResultWithString, numOfTry);

        MustErrorDetail(result, numOfTry);
    }

    [Fact]
    public void Try_FailFunction_ReturnsErrorDetail() {
        var result = TryExtensions.Try(FailFunctionReturnResult);

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ErrorDetail);
    }

    [Fact]
    public void Try_FailFunctionReturnResult_ReturnErrorDetail() {
        const int numOfTry = 3;
        var result = TryExtensions.Try(FailFunctionReturnResult, numOfTry);

        MustErrorDetail(result, numOfTry);
    }

    [Fact]
    public void Try_FailFunctionWithInput_ReturnExceptionError() {
        const string input = "input";
        var result = TryExtensions.Try(() => FailFunctionReturnInput(input));

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
    }

    [Fact]
    public void Try_FailFunctionReturnResultRepeat_ReturnExceptionError() {
        const int numOfTry = 3;
        var result = TryExtensions.Try(() => FailFunctionReturnInput("input"), numOfTry);

        MustExceptionError(result, numOfTry);
    }

    [Fact]
    public void Try_FailFunctionWithInput_ReturnResultWithString() {
        const string input = "input";
        var result = TryExtensions.Try(() => FailFunctionReturnResultWithString(input));

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ErrorDetail);
    }

    [Fact]
    public void Try_FailFunctionReturnResultWithString_ReturnErrorDetail() {
        const int numOfTry = 3;
        const string input = "input";
        var result = TryExtensions.Try(() => FailFunctionReturnResultWithString(input), numOfTry);

        MustErrorDetail(result, numOfTry);
    }

    #endregion

    #region TryAsync

    [Fact]
    public async Task TryAsync_SuccessFunctionReturnValue_ReturnValue() {
        var result = await TryExtensions.TryAsync(() => Task.FromResult(SuccessStr));

        Assert.True(result.IsSuccess);
        Assert.Equal(SuccessStr, result.Value);
    }

    [Fact]
    public async Task TryAsync_FailFunctionReturnValue_ReturnExceptionError() {
        const int numOfTry = 3;
        var result = await TryExtensions.TryAsync(() => Task.FromResult(FailFunctionReturnString()), numOfTry);

        MustExceptionError(result, numOfTry);
    }

    [Fact]
    public async Task TryAsync_SuccessFunctionReturnResultWithValue_ReturnResultWithValue() {
        var result = await TryExtensions.TryAsync(() => Task.FromResult(SuccessfulFunctionReturnResultWithString()));

        Assert.True(result.IsSuccess);
        Assert.Equal(SuccessStr, result.Value);
    }

    [Fact]
    public async Task TryAsync_FailFunctionReturnResultWithValue_ReturnExceptionError() {
        const int numOfTry = 3;
        var result =
            await TryExtensions.TryAsync(() => Task.FromResult(FailFunctionReturnResultWithString()), numOfTry);

        MustErrorDetail(result, numOfTry);
    }

    #endregion
}