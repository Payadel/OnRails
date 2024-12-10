using OnRails;
using OnRails.Extensions.Using;

namespace OnRailTest.ExtensionTests.Using;

public partial class UsingExtensionsTest {
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
        Assert.True(disposable.IsDisposed);
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
    
      [Fact]
        public void TeeUsing_WithAction_ExecutesAction()
        {
            // Arrange
            var disposable = new TestDisposable();
            var actionExecuted = false;

            // Act
            var result = disposable.TeeUsing(() =>
            {
                actionExecuted = true;
                return Result.Ok();
            });

            // Assert
            Assert.Same(disposable, result);
            Assert.True(actionExecuted);
            Assert.True(disposable.IsDisposed);
        }

        [Fact]
        public async Task TeeUsing_WithAsyncFunction_ExecutesFunction()
        {
            // Arrange
            var disposable = new TestDisposable();
            var taskObject = Task.FromResult(disposable);
            var functionExecuted = false;

            // Act
            var result = await taskObject.TeeUsing(async () =>
            {
                functionExecuted = true;
                return await Task.FromResult(Result.Ok());
            });

            // Assert
            Assert.Same(disposable, result);
            Assert.True(functionExecuted);
            Assert.True(disposable.IsDisposed);
        }
}