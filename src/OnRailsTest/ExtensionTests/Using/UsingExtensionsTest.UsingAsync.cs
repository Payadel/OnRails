using OnRails;
using OnRails.Extensions.Using;

namespace OnRailTest.ExtensionTests.Using;

public partial class UsingExtensionsTest {
    [Fact]
    public async Task UsingAsync_SuccessfulFunctionWithInputOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new TestDisposable();
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
    public async Task UsingAsync_SuccessfulFunctionWithInputAndResultValueOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new TestDisposable();
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
    public async Task UsingAsync_SuccessfulFunctionWithResultValueOutput_DisposeObject() {
        var disposableObj = new TestDisposable();
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
    public async Task UsingAsync_SuccessfulFunctionWithResultOutput_DisposeObject() {
        var disposableObj = new TestDisposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(() => {
            Assert.False(disposableObj.IsDisposed);
            return Task.FromResult(Result.Ok());
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UsingAsync_SuccessfulFunctionWithInputAndResultOutput_DisposeObject() {
        var disposableObj = new TestDisposable();
        Assert.False(disposableObj.IsDisposed);

        var result = await disposableObj.Using(obj => {
            Assert.False(obj.IsDisposed);
            return Task.FromResult(Result.Ok());
        });

        Assert.True(disposableObj.IsDisposed);
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UsingAsync_SuccessfulFunctionWithOutput_DisposeObjectAndReturnResult() {
        var disposableObj = new TestDisposable();
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
    public async Task UsingAsync_WithTaskAndFunction_DisposesAndReturnsResult() {
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);

        var result = await task.Using(() => 42, 1);

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public async Task UsingAsync_WithTaskAndAsyncFunction_DisposesAndReturnsResult() {
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);

        var result = await task.Using(async () => {
            await Task.Delay(10);
            return 42;
        }, 1);

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public async Task UsingAsync_WithTaskAndRetry_SucceedsAfterRetries() {
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);
        var attempts = 0;

        var result = await task.Using(() => {
            attempts++;
            if (attempts < 3) throw new TestError();
            return 42;
        }, 3);

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.Equal(3, attempts);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public async Task UsingAsync_WithTaskAndFailingFunction_TracksFailure() {
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);

        var result = await task.Using(() => {
            throw new TestError();
            return Result.Ok();
        }, 1);

        Assert.False(result.Success);
        Assert.NotNull(result.Detail);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public async Task UsingAsync_WithTaskAndAction_DisposesAndExecutesAction() {
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);

        var result = await task.Using(() => { Assert.False(disposable.IsDisposed); }, 1);

        Assert.True(result.Success);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public async Task UsingAsync_WithTaskAndAsyncResultFunction_DisposesAndReturnsResult() {
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);

        var result = await task.Using(async () => {
            await Task.Delay(10);
            return Result<int>.Ok(42);
        }, 1);

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public async Task UsingAsync_WithTaskAndResultFunction_FailsAndTracksError() {
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);

        var result = await task.Using(() => {
            throw new TestError();
            return Result.Ok();
        }, 1);

        Assert.False(result.Success);
        Assert.NotNull(result.Detail);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public async Task UsingAsync_WithAsyncObjectAndAsyncFunction_DisposesAndReturnsResult() {
        var disposable = new TestDisposable();

        var result = await disposable.Using(async () => {
            await Task.Delay(10);
            return 42;
        }, 1);

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public async Task UsingAsync_WithAsyncObjectAndAsyncResultFunction_DisposesAndReturnsResult() {
        var disposable = new TestDisposable();

        var result = await disposable.Using(async () => {
            await Task.Delay(10);
            return Result<int>.Ok(42);
        }, 1);

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public async Task UsingAsync_WithAsyncObjectAndAsyncFunctionWithParameter_DisposesAndReturnsResult() {
        var disposable = new TestDisposable();

        var result = await disposable.Using(async d => {
            Assert.False(d.IsDisposed);
            await Task.Delay(10);
            return 42;
        }, 1);

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public async Task UsingAsync_WithAsyncObjectAndAsyncResultFunctionWithParameter_DisposesAndReturnsResult() {
        var disposable = new TestDisposable();

        var result = await disposable.Using(async d => {
            Assert.False(d.IsDisposed);
            await Task.Delay(10);
            return Result<int>.Ok(42);
        }, 1);

        Assert.True(result.Success);
        Assert.Equal(42, result.Value);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public async Task UsingAsync_WithRetries_FailsAfterMaxTries() {
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);
        var attempts = 0;

        var result = await task.Using(() => {
            attempts++;
            throw new TestError();
            return Result.Ok();
        }, 3);

        Assert.False(result.Success);
        Assert.NotNull(result.Detail);
        Assert.Equal(3, attempts);
        Assert.True(disposable.IsDisposed);
    }
}