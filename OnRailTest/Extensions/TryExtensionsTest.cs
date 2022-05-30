using OnRail.Extensions;
using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;
using Xunit.Abstractions;

namespace OnRailTest.Extensions;

public class TryExtensionsTest {
    public TryExtensionsTest(ITestOutputHelper testOutputHelper) { }

    private const string SuccessStr = "Success";
    private static void SuccessfulAction() { }
    private static void SuccessfulActionWithInput(string input) { }
    private static string SuccessfulFunctionReturnString() => SuccessStr;
    private static string SuccessfulFunctionReturnInput(string input) => input;
    private static OnRail.Result SuccessfulFunctionReturnResult() => OnRail.Result.Ok();

    private static OnRail.Result<string> SuccessfulFunctionReturnResultWithString() =>
        OnRail.Result<string>.Ok(SuccessStr);

    private static OnRail.Result<string> SuccessfulFunctionReturnResultWithString(string input) =>
        OnRail.Result<string>.Ok(input);

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
    private static void FailAction() => throw new Exception();
    private static void FailActionWithInput(string input) => throw new Exception();
    private static string FailFunctionReturnString() => throw new Exception();
    private static string FailFunctionReturnInput(string input) => throw new Exception();
    private static OnRail.Result FailFunctionReturnResult() => OnRail.Result.Fail(new BadRequestError());

    private static OnRail.Result<string> FailFunctionReturnResultWithString() =>
        OnRail.Result<string>.Fail(new BadRequestError());

    private static OnRail.Result<string> FailFunctionReturnResultWithString(string input) =>
        OnRail.Result<string>.Fail(new BadRequestError());

    [Fact]
    public void Try_FailAction_ReturnExceptionError() {
        var result = TryExtensions.Try(FailAction);

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
        Assert.Single(result.Detail.MoreDetails!);

        var numOfTry = result.Detail.GetMoreDetailProperties("numOfTry", typeof(int)).Single();
        Assert.Equal(1, numOfTry);
    }

    [Fact]
    public void Try_FailActionWithRepeat_ReturnExceptionError() {
        const int numOfTry = 3;
        var result = TryExtensions.Try(FailAction, numOfTry);

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
        Assert.Equal(2, result.Detail.MoreDetails?.Count); // numOfTry - exceptions
        Assert.Equal(numOfTry, result.Detail.GetMoreDetailProperties("numOfTry", typeof(int)).Single());

        var exceptions =
            result.Detail.GetMoreDetailProperties(type: typeof(List<Exception>)).Single() as List<Exception>;
        Assert.Equal(numOfTry, exceptions!.Count);
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

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
        Assert.Equal(2, result.Detail.MoreDetails?.Count); // numOfTry - exceptions
        Assert.Equal(numOfTry, result.Detail.GetMoreDetailProperties("numOfTry", typeof(int)).Single());

        var exceptions =
            result.Detail.GetMoreDetailProperties(type: typeof(List<Exception>)).Single() as List<Exception>;
        Assert.Equal(numOfTry, exceptions!.Count);
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

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
        Assert.Equal(2, result.Detail.MoreDetails?.Count); // numOfTry - exceptions
        Assert.Equal(numOfTry, result.Detail.GetMoreDetailProperties("numOfTry", typeof(int)).Single());

        var exceptions =
            result.Detail.GetMoreDetailProperties(type: typeof(List<Exception>)).Single() as List<Exception>;
        Assert.Equal(numOfTry, exceptions!.Count);
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

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
        Assert.Equal(2, result.Detail.MoreDetails?.Count); // numOfTry - exceptions
        Assert.Equal(numOfTry, result.Detail.GetMoreDetailProperties("numOfTry", typeof(int)).Single());

        var exceptions =
            result.Detail.GetMoreDetailProperties(type: typeof(List<Exception>)).Single() as List<Exception>;
        Assert.Equal(numOfTry, exceptions!.Count);
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

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ErrorDetail);
        Assert.Equal(2, result.Detail.MoreDetails?.Count); // numOfTry - errors
        Assert.Equal(numOfTry, result.Detail.GetMoreDetailProperties("numOfTry", typeof(int)).Single());

        var exceptions =
            result.Detail.GetMoreDetailProperties(type: typeof(List<object>)).Single() as List<object>;
        Assert.Equal(numOfTry, exceptions!.Count);
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

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ErrorDetail);
        Assert.Equal(2, result.Detail.MoreDetails?.Count); // numOfTry - errors
        Assert.Equal(numOfTry, result.Detail.GetMoreDetailProperties("numOfTry", typeof(int)).Single());

        var exceptions =
            result.Detail.GetMoreDetailProperties(type: typeof(List<object>)).Single() as List<object>;
        Assert.Equal(numOfTry, exceptions!.Count);
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

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
        Assert.Equal(2, result.Detail.MoreDetails?.Count); // numOfTry - errors
        Assert.Equal(numOfTry, result.Detail.GetMoreDetailProperties("numOfTry", typeof(int)).Single());

        var exceptions =
            result.Detail.GetMoreDetailProperties(type: typeof(List<Exception>)).Single() as List<Exception>;
        Assert.Equal(numOfTry, exceptions!.Count);
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

        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ErrorDetail);
        Assert.Equal(2, result.Detail.MoreDetails?.Count); // numOfTry - errors
        Assert.Equal(numOfTry, result.Detail.GetMoreDetailProperties("numOfTry", typeof(int)).Single());

        var exceptions =
            result.Detail.GetMoreDetailProperties(type: typeof(List<object>)).Single() as List<object>;
        Assert.Equal(numOfTry, exceptions!.Count);
    }
}