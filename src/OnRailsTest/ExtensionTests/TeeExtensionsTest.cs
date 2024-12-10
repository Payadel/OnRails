using OnRails.Extensions.Tee;

namespace OnRailTest.ExtensionTests;

public class TeeExtensionsTest {
    private const int DefaultNumOfTry = 3;
    private static string SuccessfulFunctionWithInputOutput(string str) => str;


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
            return string.Empty;
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
    public void Tee_FailFunctionWithOutputAndSimpleTee_TryFunctionAndReturnFirstObject() {
        var counter = 0;

        TeeExtensions.Tee(() => {
            counter++;
            throw new Exception("Fake");
            return string.Empty;
        }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
    }

    #endregion

    #region TeeAsync

    [Fact]
    public async Task TeeAsync_SuccessfulFunctionReturnsResul_ExecuteFunction() {
        var counter = 0;

        await TeeExtensions.Tee(() => Task.FromResult(counter++), DefaultNumOfTry);

        Assert.Equal(1, counter);
    }

    [Fact]
    public async Task TeeAsync_FailFunctionReturnsResul_TryFunctionAndReturnTask() {
        var counter = 0;

        await TeeExtensions.Tee(() => {
            counter++;
            throw new Exception("Fake");
            return Task.FromResult(counter);
        }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
    }

    [Fact]
    public async Task TeeAsync_SuccessfulActionWithInput_ExecuteActionAndReturnTask() {
        var counterTask = Task.FromResult(0);

        await counterTask.Tee((int input) => { }, DefaultNumOfTry);

        var counter = await counterTask;
        Assert.Equal(0, counter);
    }

    [Fact]
    public async Task TeeAsync_FailActionWithInput_TryActionAndReturnFirstTask() {
        var counter = 0;
        var result = await Task.FromResult(1)
            .Tee((int number) => {
                counter++;
                throw new Exception("Fake");
            }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task TeeAsync_SuccessfulAction_ExecuteActionAndReturnTask() {
        var counterTask = Task.FromResult(0);

        await counterTask.Tee(() => { }, DefaultNumOfTry);

        var counter = await counterTask;
        Assert.Equal(0, counter);
    }

    [Fact]
    public async Task TeeAsync_FailAction_TryActionAndReturnFirstTask() {
        var counter = 0;
        var result = await Task.FromResult(1)
            .Tee(() => {
                counter++;
                throw new Exception("Fake");
            }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task TeeAsync_SuccessfulFunctionWithInputOutput_ExecuteFunctionAndReturnTask() {
        var counterTask = Task.FromResult(0);

        await counterTask.Tee((int number) => 1, DefaultNumOfTry);

        var counter = await counterTask;
        Assert.Equal(0, counter);
    }

    [Fact]
    public async Task TeeAsync_FailFunctionWithInputOutput_TryFunctionAndReturnFirstTask() {
        var counter = 0;
        var result = await Task.FromResult(1)
            .Tee((int _) => {
                counter++;
                throw new Exception("Fake");
                return counter;
            }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task TeeAsync_SuccessfulFunctionWithInput_ExecuteFunctionAndReturnTask() {
        var counterTask = Task.FromResult(0);

        await counterTask.Tee(() => 1, DefaultNumOfTry);

        var counter = await counterTask;
        Assert.Equal(0, counter);
    }

    [Fact]
    public async Task TeeAsync_FailFunctionWithInput_TryFunctionAndReturnFirstTask() {
        var counter = 0;
        var result = await Task.FromResult(1)
            .Tee(() => {
                counter++;
                throw new Exception("Fake");
                return counter;
            }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task TeeAsync_SuccessfulFunctionWithInputAndResultOnObject_ExecuteFunctionAndReturnTask() {
        var result = await "str".Tee((string _) => Task.FromResult(0), DefaultNumOfTry);

        Assert.Equal("str", result);
    }

    [Fact]
    public async Task TeeAsync_FailFunctionWithInputAndResultOnObject_TryFunctionAndReturnFirstTask() {
        var counter = 0;

        var result = await "str".Tee((string _) => {
            counter++;
            throw new Exception("Fake");
            return Task.FromResult(1);
        }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
        Assert.Equal("str", result);
    }

    [Fact]
    public async Task TeeAsync_SuccessfulFunctionWithResultOnObject_ExecuteFunctionAndReturnTask() {
        var result = await "str".Tee(() => Task.FromResult(0), DefaultNumOfTry);

        Assert.Equal("str", result);
    }

    [Fact]
    public async Task TeeAsync_FailFunctionWithResultOnObject_TryFunctionAndReturnFirstTask() {
        var counter = 0;

        var result = await "str".Tee(() => {
            counter++;
            throw new Exception("Fake");
            return Task.FromResult(1);
        }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
        Assert.Equal("str", result);
    }

    [Fact]
    public async Task TeeAsync_SuccessfulFunctionWithInputAndResult_ExecuteFunctionAndReturnTask() {
        var counterTask = Task.FromResult(0);

        await counterTask.Tee((int _) => Task.FromResult(""), DefaultNumOfTry);

        var counter = await counterTask;
        Assert.Equal(0, counter);
    }


    [Fact]
    public async Task TeeAsync_FailFunctionWithInputAndResult_TryFunctionAndReturnFirstTask() {
        var counter = 0;
        var result = await Task.FromResult(1)
            .Tee((int _) => {
                counter++;
                throw new Exception("Fake");
                return Task.FromResult("");
            }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task TeeAsync_SuccessfulFunctionWithResult_ExecuteFunctionAndReturnTask() {
        var counterTask = Task.FromResult(0);

        await counterTask.Tee(() => Task.FromResult(""), DefaultNumOfTry);

        var counter = await counterTask;
        Assert.Equal(0, counter);
    }

    [Fact]
    public async Task TeeAsync_FailFunctionWithResult_TryFunctionAndReturnFirstTask() {
        var counter = 0;
        var result = await Task.FromResult(1)
            .Tee(() => {
                counter++;
                throw new Exception("Fake");
                return Task.FromResult("");
            }, DefaultNumOfTry);

        Assert.Equal(DefaultNumOfTry, counter);
        Assert.Equal(1, result);
    }

    #endregion
}