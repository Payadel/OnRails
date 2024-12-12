using OnRails;
using OnRails.Extensions.Using;

namespace OnRailTest.ExtensionTests.Using;

public partial class UsingExtensionsTest {
    [Fact]
    public void Using_WithAction_ExecutesActionAndDisposes() {
        var disposable = new TestDisposable();

        var result = disposable.Using(() => { Assert.False(disposable.IsDisposed); });

        Assert.True(result.Success);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void Using_WithFunction_ExecutesFunctionAndDisposes() {
        var disposable = new TestDisposable();

        var result = disposable.Using(() => 42);

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void Using_WithFunction_ExecutesWithRetryOnException() {
        var disposable = new TestDisposable();
        var attempt = 0;

        var result = disposable.Using(() => {
            attempt++;
            if (attempt < 2) throw new TestError();
            return 42;
        }, 2);

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.Equal(2, attempt);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void Using_WithResultFunction_ReturnsResultAndDisposes() {
        var disposable = new TestDisposable();

        var result = disposable.Using(() => Result<int>.Ok(42));

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void Using_WithResultFunction_FailsOnExceptionAndDisposes() {
        var disposable = new TestDisposable();

        var result = disposable.Using(() => {
            throw new TestError();
            return Result.Ok();
        }, 1);

        Assert.False(result.Success);
        Assert.NotNull(result.Detail);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void Using_WithActionWithParameter_ExecutesActionAndDisposes() {
        var disposable = new TestDisposable();

        var result = disposable.Using(d => {
            Assert.False(d.IsDisposed);
            Assert.Same(disposable, d);
        });

        Assert.True(result.Success);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void Using_WithFunctionWithParameter_ExecutesFunctionAndDisposes() {
        var disposable = new TestDisposable();

        var result = disposable.Using(d => {
            Assert.False(d.IsDisposed);
            Assert.Same(disposable, d);
            return 42;
        });

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void Using_WithResultFunctionWithParameter_ReturnsResultAndDisposes() {
        var disposable = new TestDisposable();

        var result = disposable.Using(d => {
            Assert.False(d.IsDisposed);
            Assert.Same(disposable, d);
            return Result<int>.Ok(42);
        });

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void Using_WithResultFunctionWithParameter_FailsOnExceptionAndDisposes() {
        var disposable = new TestDisposable();

        var result = disposable.Using(d => {
            Assert.False(d.IsDisposed);
            throw new TestError();
            return Result.Ok();
        }, 1);

        Assert.False(result.Success);
        Assert.NotNull(result.Detail);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void Using_WithRetries_StopsAfterMaxTries() {
        var disposable = new TestDisposable();
        var attempts = 0;

        var result = disposable.Using(() => {
            attempts++;
            throw new TestError();
            return Result.Ok();
        }, 3);

        Assert.False(result.Success);
        Assert.NotNull(result.Detail);
        Assert.Equal(3, attempts);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void Using_SuccessfulAction_DisposeObject() {
        var disposableObj = new TestDisposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => Assert.False(disposableObj.IsDisposed));

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }

    [Fact]
    public void Using_SuccessfulActionWithInput_DisposeObject() {
        var disposableObj = new TestDisposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => Assert.False(obj.IsDisposed));

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }

    [Fact]
    public void Using_SuccessfulFunctionWithInputOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new TestDisposable();
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
    public void Using_SuccessfulFunctionWithInputAndResultValueOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new TestDisposable();
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
    public void Using_SuccessfulFunctionWithOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new TestDisposable();
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
    public void Using_SuccessfulFunctionWithResultValueOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new TestDisposable();
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
    public void Using_SuccessfulFunctionWithResultOutput_DisposeObject() {
        var disposableObj = new TestDisposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return Result.Ok();
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }

    [Fact]
    public void Using_SuccessfulFunctionWithInputAndResultOutput_DisposeObject() {
        var disposableObj = new TestDisposable();
        Assert.False(disposableObj.IsDisposed);

        var result = disposableObj.Using(obj => {
            Assert.False(disposableObj.IsDisposed);
            return Result.Ok();
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }
}