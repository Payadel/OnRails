using OnRail.Extensions;

namespace OnRailTest.Extensions;

public class TeeExtensionsTest {
    public const int DefaultNumOfTry = 3;
    public static string SuccessfulFunctionWithInputOutput(string str) => str;

    #region Tee

    [Fact]
    public void Tee_SuccessfulActionWithInput_ReturnFirstObject() {
        Assert.Equal("obj", "obj".Tee(_ => { }));
    }

    [Fact]
    public void Tee_FailActionWithInput_TryActionAndReturnFirstObject() {
        var counter = 0;

        var result = "obj".Tee(_ => {
            counter++;
            throw new Exception("Fake");
        }, DefaultNumOfTry);

        Assert.Equal("obj", result);
        Assert.Equal(DefaultNumOfTry, counter);
    }

    [Fact]
    public void Tee_SuccessfulAction_ReturnFirstObject() {
        Assert.Equal("obj", "obj".Tee(() => { }));
    }

    [Fact]
    public void Tee_FailAction_TryActionAndReturnFirstObject() {
        var counter = 0;

        var result = "obj".Tee(() => {
            counter++;
            throw new Exception("Fake");
        }, DefaultNumOfTry);

        Assert.Equal("obj", result);
        Assert.Equal(DefaultNumOfTry, counter);
    }

    [Fact]
    public void Tee_SimpleTeeWithoutOutput_RunAction() {
        TeeExtensions.Tee(() => { Assert.True(true); });
    }

    [Fact]
    public void Tee_FailActionAndSimpleTee_TryActionAndReturnFirstObject() {
        var counter = 0;

        TeeExtensions.Tee(() => {
            counter++;
            throw new Exception("Fake");
        }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
    }

    [Fact]
    public void Tee_SuccessfulFunctionWithInputOutput_ReturnFirstObject() {
        Assert.Equal("obj", "obj".Tee(SuccessfulFunctionWithInputOutput));
    }

    [Fact]
    public void Tee_FailFunctionWithInputOutput_TryFunctionAndReturnFirstObject() {
        var counter = 0;

        var result = "obj".Tee(obj => {
            counter++;
            throw new Exception("Fake");
            return obj;
        }, DefaultNumOfTry);

        Assert.Equal("obj", result);
        Assert.Equal(DefaultNumOfTry, counter);
    }

    [Fact]
    public void Tee_SuccessfulFunctionWithOutput_ReturnFirstObject() {
        Assert.Equal("obj", "obj".Tee(() => ""));
    }

    [Fact]
    public void Tee_FailFunctionWithOutput_TryFunctionAndReturnFirstObject() {
        var counter = 0;

        var result = "obj".Tee(() => {
            counter++;
            throw new Exception("Fake");
            return "";
        }, DefaultNumOfTry);

        Assert.Equal("obj", result);
        Assert.Equal(DefaultNumOfTry, counter);
    }

    [Fact]
    public void Tee_SuccessfulFunctionWithOutputAndSimpleTee_RunFunction() {
        var counter = 0;

        TeeExtensions.Tee(() => counter++, DefaultNumOfTry);

        Assert.Equal(1, counter);
    }

    [Fact]
    public void Tee_FailFunctionWithOutputAndSimpeTee_TryFunctionAndReturnFirstObject() {
        var counter = 0;

        TeeExtensions.Tee(() => {
            counter++;
            throw new Exception("Fake");
            return "";
        }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
    }

    #endregion
}