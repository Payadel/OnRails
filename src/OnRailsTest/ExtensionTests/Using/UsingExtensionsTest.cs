using OnRails;
using OnRails.Extensions.Using;

namespace OnRailTest.ExtensionTests.Using;

public class UsingExtensionsTest {
    private class TestDisposable : IDisposable {
        public bool IsDisposed { get; private set; }
        public void Dispose() => IsDisposed = true;
    }

    private class TestError : Exception;

    #region Using

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

    #endregion

    #region Using Async

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

    #endregion

    #region TeeUsing

    [Fact]
    public void TeeUsing_SuccessfulFunctionWithInputOutput_DisposeObject() {
        var disposableObj = new TestDisposable();
        Assert.False(disposableObj.IsDisposed);

        disposableObj.TeeUsing(obj => {
            Assert.False(obj.IsDisposed);
            return "result";
        });

        Assert.True(disposableObj.IsDisposed);
    }

    [Fact]
    public void TeeUsing_FailFunctionWithInputOutput_DisposeObject() {
        var disposableObj = new TestDisposable();
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
        var disposableObj = new TestDisposable();
        Assert.False(disposableObj.IsDisposed);

        disposableObj.TeeUsing(() => {
            Assert.False(disposableObj.IsDisposed);
            return "result";
        });

        Assert.True(disposableObj.IsDisposed);
    }

    [Fact]
    public void TeeUsing_FailFunctionWithOutput_DisposeObject() {
        var disposableObj = new TestDisposable();
        Assert.False(disposableObj.IsDisposed);

        disposableObj.TeeUsing(() => {
            Assert.False(disposableObj.IsDisposed);
            throw new Exception();
            return "result";
        });

        Assert.True(disposableObj.IsDisposed);
    }

    [Fact]
    public void TeeUsing_ReturnsOriginalObject_AfterFunctionCall() {
        // Arrange
        var disposable = new TestDisposable();
        var functionCallCount = 0;

        // Act
        var result = disposable.TeeUsing(obj => {
            functionCallCount++;
            return 42;
        });

        // Assert
        Assert.Same(disposable, result);
        Assert.Equal(1, functionCallCount);
        Assert.False(disposable.IsDisposed);
    }

    [Fact]
    public async Task TeeUsing_Task_ReturnsOriginalTask() {
        // Arrange
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);

        // Act
        var resultTask = task.TeeUsing(obj => 42);
        var result = await resultTask;

        // Assert
        Assert.Same(disposable, result);
        Assert.False(disposable.IsDisposed);
    }

    [Fact]
    public async Task TeeUsing_Task_DisposesObject_AfterTaskCompletion() {
        // Arrange
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);

        // Act
        var resultTask = task.TeeUsing(obj => Task.CompletedTask);
        var result = await resultTask;

        // Assert
        Assert.Same(disposable, result);
        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void TeeUsing_CallsFunctionWithResultObject() {
        // Arrange
        var disposable = new TestDisposable();
        var functionCallCount = 0;

        // Act
        var result = disposable.TeeUsing(obj => {
            functionCallCount++;
            return 42;
        });

        // Assert
        Assert.Same(disposable, result);
        Assert.Equal(1, functionCallCount);
    }

    [Fact]
    public async Task TeeUsing_Task_CallsFunctionWithResultObject() {
        // Arrange
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);
        var functionCallCount = 0;

        // Act
        var resultTask = task.TeeUsing(obj => {
            functionCallCount++;
            return 42;
        });
        var result = await resultTask;

        // Assert
        Assert.Same(disposable, result);
        Assert.Equal(1, functionCallCount);
    }

    [Fact]
    public void TeeUsing_CallsActionWithResultObject() {
        // Arrange
        var disposable = new TestDisposable();
        var actionCallCount = 0;

        // Act
        var result = disposable.TeeUsing(obj => actionCallCount++);

        // Assert
        Assert.Same(disposable, result);
        Assert.Equal(1, actionCallCount);
    }

    [Fact]
    public async Task TeeUsing_Task_CallsActionWithResultObject() {
        // Arrange
        var disposable = new TestDisposable();
        var task = Task.FromResult(disposable);
        var actionCallCount = 0;

        // Act
        var resultTask = task.TeeUsing(obj => {
            actionCallCount++;
            return Task.CompletedTask;
        });
        var result = await resultTask;

        // Assert
        Assert.Same(disposable, result);
        Assert.Equal(1, actionCallCount);
    }

    [Fact]
    public void TeeUsing_DisposesResource_AfterAction() {
        // Arrange
        var disposable = new TestDisposable();
        var actionCallCount = 0;

        // Act
        var result = disposable.TeeUsing(obj => actionCallCount++);

        // Assert
        Assert.Same(disposable, result);
        Assert.Equal(1, actionCallCount);
        Assert.True(disposable.IsDisposed);
    }

    #endregion
}