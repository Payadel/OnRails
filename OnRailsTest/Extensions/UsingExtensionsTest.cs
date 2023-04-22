using OnRails;
using OnRails.Extensions.Using;
using OnRails.ResultDetails;
using Xunit.Sdk;

namespace OnRailTest.Extensions;

public class UsingExtensionsTest {
    private class Disposable : IDisposable {
        public bool IsDisposed { get; private set; } = false;

        public void Dispose() {
            IsDisposed = true;
            GC.SuppressFinalize(this);
        }
    }

    private const int DefaultNumOfTry = 3;

    private static void EnsureTryWrapperValid(ResultDetail resultDetail) {
        //If the try method is not used correctly,
        //the Assert Exception (FalseException) may not work properly
        //and the unit-test result may be incorrect.
        //In this section, we want to make sure that the exception does not fall into our Try method.

        var lastException = (resultDetail.GetMoreDetailProperties<List<object>>()
            .SingleOrDefault() as List<object>)?.Last();
        Assert.True(lastException is not FalseException);
    }

    #region Using

    [Fact]
    public void Using_SuccessfulAction_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => Assert.False(disposableObj.IsDisposed));

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }

    [Fact]
    public void Using_FailAction_DisposeAndReturnExceptionError() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        void Action() => throw new Exception();
        var result = disposableObj.Using(Action, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    [Fact]
    public void Using_SuccessfulActionWithInput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => Assert.False(obj.IsDisposed));

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }

    [Fact]
    public void Using_FailActionWithInput_DisposeAndReturnExceptionError() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        void Action(Disposable obj) => throw new Exception();
        var result = disposableObj.Using(Action, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    [Fact]
    public void Using_SuccessfulFunctionWithInputOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            return "result";
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
        Assert.Equal("result", result.Value);
    }

    [Fact]
    public void Using_FailFunctionWithInputOutput_DisposeAndReturnExceptionError() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            throw new Exception();
            return "result";
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    [Fact]
    public void Using_SuccessfulFunctionWithInputAndResultValueOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            return Result<string>.Ok("result");
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
        Assert.Equal("result", result.Value);
    }

    [Fact]
    public void Using_FailFunctionWithInputAndResultValueOutput_DisposeAndReturnErrorDetail() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            return Result<string>.Fail();
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }


    [Fact]
    public void Using_SuccessfulFunctionWithOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return "result";
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
        Assert.Equal("result", result.Value);
    }

    [Fact]
    public void Using_FailFunctionWithOutput_DisposeAndReturnExceptionError() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            throw new Exception();
            return "result";
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    [Fact]
    public void Using_SuccessfulFunctionWithResultValueOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return Result<string>.Ok("result");
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
        Assert.Equal("result", result.Value);
    }

    [Fact]
    public void Using_FailFunctionWithResultValueOutput_DisposeAndReturnErrorDetail() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return Result<string>.Fail();
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    [Fact]
    public void Using_SuccessfulFunctionWithResultOutput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return Result.Ok();
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }

    [Fact]
    public void Using_FailFunctionWithResultOutput_DisposeAndReturnErrorDetail() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return Result.Fail();
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    [Fact]
    public void Using_SuccessfulFunctionWithInputAndResultOutput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => {
            Assert.False(disposableObj.IsDisposed);
            return Result.Ok();
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }

    [Fact]
    public void Using_FailFunctionWithInputAndResultOutput_DisposeAndReturnErrorDetail() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => {
            Assert.False(disposableObj.IsDisposed);
            return Result.Fail();
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    #endregion

    #region Using Async

    [Fact]
    public async Task UsingAsync_SuccessfulFunctionWithInputOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            return Task.FromResult("result");
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
        Assert.Equal("result", result.Value);
    }

    [Fact]
    public async Task UsingAsync_FailFunctionWithInputOutput_DisposeAndReturnExceptionError() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            throw new Exception();
            return Task.FromResult("result");
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    [Fact]
    public async Task UsingAsync_SuccessfulFunctionWithInputAndResultValueOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            return Task.FromResult(Result<string>.Ok("result"));
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
        Assert.Equal("result", result.Value);
    }

    [Fact]
    public async Task UsingAsync_FailFunctionWithInputAndResultValueOutput_DisposeAndReturnErrorDetail() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            return Task.FromResult(Result<string>.Fail());
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    [Fact]
    public async Task UsingAsync_SuccessfulFunctionWithResultValueOutput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return Task.FromResult(Result<string>.Ok("result"));
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
        Assert.Equal("result", result.Value);
    }

    [Fact]
    public async Task UsingAsync_FailFunctionWithResultValueOutput_DisposeAndReturnErrorDetail() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return Task.FromResult(Result<string>.Fail());
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    [Fact]
    public async Task UsingAsync_SuccessfulFunctionWithResultOutput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return Task.FromResult(Result.Ok());
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UsingAsync_FailFunctionWithResultOutput_DisposeAndReturnErrorDetail() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return Task.FromResult(Result.Fail());
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    [Fact]
    public async Task UsingAsync_SuccessfulFunctionWithInputAndResultOutput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            return Task.FromResult(Result.Ok());
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UsingAsync_FailFunctionWithInputAndResultOutput_DisposeAndReturnErrorDetail() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            return Task.FromResult(Result.Fail());
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    [Fact]
    public async Task UsingAsync_SuccessfulFunctionWithOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return Task.FromResult("result");
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
        Assert.Equal("result", result.Value);
    }

    [Fact]
    public async Task UsingAsync_FailFunctionWithOutput_DisposeAndReturnExceptionError() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            throw new Exception();
            return Task.FromResult("result");
        }, DefaultNumOfTry);

        Assert.True(disposableObj.IsDisposed);
        Helper.EnsureHasFailed(result, DefaultNumOfTry, true);
        EnsureTryWrapperValid(result.Detail);
    }

    #endregion

    #region TeeUsing

    [Fact]
    public void TeeUsing_SuccessfulFunctionWithInputOutput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        disposableObj.TeeUsing(obj => {
            Assert.False(obj.IsDisposed);
            return "result";
        });

        Assert.True(disposableObj.IsDisposed);
    }

    [Fact]
    public void TeeUsing_FailFunctionWithInputOutput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        disposableObj.TeeUsing(obj => {
            Assert.False(obj.IsDisposed);
            throw new Exception();
            return "result";
        });

        Assert.True(disposableObj.IsDisposed);
    }

    [Fact]
    public void TeeUsing_SuccessfulFunctionWithOutput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        disposableObj.TeeUsing(() => {
            Assert.False(disposableObj.IsDisposed);
            return "result";
        });

        Assert.True(disposableObj.IsDisposed);
    }

    [Fact]
    public void TeeUsing_FailFunctionWithOutput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        disposableObj.TeeUsing(() => {
            Assert.False(disposableObj.IsDisposed);
            throw new Exception();
            return "result";
        });

        Assert.True(disposableObj.IsDisposed);
    }

    #endregion
}