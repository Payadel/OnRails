using OnRail.Extensions;

namespace OnRailTest.Extensions;

public static class TaskExtensionsTest {
    private const int DefaultNumOfTry = 3;
    private static readonly Task SuccessfulTask = Task.Run(() => { });
    private static readonly Task<int> SuccessfulTaskWithOutput = Task.FromResult(1);

    private static readonly Task FailTask = Task.Run(async () => {
        await Task.Delay(100);
        throw new Exception("Fake");
    });

    private static readonly Task<int> FailTaskWithOutput = Task.Run(async () => {
        await Task.Delay(100);
        throw new Exception("Fake");
        return 1;
    });

    private static readonly List<Task> SuccessfulTasks = new() {SuccessfulTask, SuccessfulTask};

    private static readonly List<Task<int>> SuccessfulTasksWithOutput =
        new() {SuccessfulTaskWithOutput, SuccessfulTaskWithOutput};

    private static readonly List<Task> FailTasks = new() {SuccessfulTask, FailTask};
    private static readonly List<Task<int>> FailTasksWithOutput = new() {SuccessfulTaskWithOutput, FailTaskWithOutput};

    [Fact]
    public static async Task BindAsync_SuccessfulTasks_BindTasks() {
        var result = await SuccessfulTasks.Bind(DefaultNumOfTry);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public static async Task BindAsync_FailTasks_ReturnExceptionError() {
        var result = await FailTasks.Bind(DefaultNumOfTry);

        Assert.False(result.IsSuccess);
        Utility.EnsureIsExceptionError(result, DefaultNumOfTry);
    }

    [Fact]
    public static async Task BindAsync_SuccessfulTasksWithOutput_ReturnResult() {
        var result = await SuccessfulTasksWithOutput.Bind(DefaultNumOfTry);

        Assert.True(result.IsSuccess);
        Assert.IsType<List<int>>(result.Value);
        Assert.Equal(2, result.Value!.Count);
    }

    [Fact]
    public static async Task BindAsync_FailTasksWithOutput_ReturnExceptionError() {
        var result = await FailTasksWithOutput.Bind(DefaultNumOfTry);

        Assert.False(result.IsSuccess);
        Utility.EnsureIsExceptionError(result, DefaultNumOfTry);
    }
}