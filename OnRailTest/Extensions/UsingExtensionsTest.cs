using OnRail.Extensions;
using OnRail.ResultDetails.Errors;

namespace OnRailTest.Extensions;

public class UsingExtensionsTest {
    private class Disposable : IDisposable {
        public bool IsDisposed { get; private set; } = false;

        public void Dispose() {
            IsDisposed = true;
            GC.SuppressFinalize(this);
        }
    }

    #region Using

    [Fact]
    public void Using_SuccessfulAction_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => Assert.False(disposableObj.IsDisposed));

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Using_FailAction_DisposeAndReturnExceptionError() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => throw new Exception());

        Assert.True(disposableObj.IsDisposed);
        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
    }

    [Fact]
    public void Using_SuccessfulActionWithInput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => Assert.False(obj.IsDisposed));

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Using_FailActionWithInput_DisposeAndReturnExceptionError() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => throw new Exception());

        Assert.True(disposableObj.IsDisposed);
        Assert.False(result.IsSuccess);
        Assert.True(result.Detail is ExceptionError);
    }

    [Fact]
    public void Using_SuccessfulFunctionWithInputOutput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            return "result";
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.IsSuccess);
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
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void Using_SuccessfulFunctionWithOutput_DisposeObject() {
        var disposableObj = new Disposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return "result";
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.IsSuccess);
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
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.False(result.IsSuccess);
    }

    #endregion

    #region UsingAsync

    

    #endregion
}