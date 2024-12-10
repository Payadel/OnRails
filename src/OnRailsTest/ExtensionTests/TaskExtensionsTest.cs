using OnRails.Extensions.Bind;

namespace OnRailTest.ExtensionTests;

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

    private static readonly List<Task> SuccessfulTasks = [SuccessfulTask, SuccessfulTask];

    private static readonly List<Task<int>> SuccessfulTasksWithOutput =
        [SuccessfulTaskWithOutput, SuccessfulTaskWithOutput];

    private static readonly List<Task> FailTasks = [SuccessfulTask, FailTask];
    private static readonly List<Task<int>> FailTasksWithOutput = [SuccessfulTaskWithOutput, FailTaskWithOutput];

    [Fact]
    public static async Task BindAsync_SuccessfulTasks_BindTasks() {
        var result = await SuccessfulTasks.Bind(DefaultNumOfTry);

        Assert.True(result.Success);
    }

    [Fact]
    public static async Task BindAsync_SuccessfulTasksWithOutput_ReturnResult() {
        var result = await SuccessfulTasksWithOutput.Bind(DefaultNumOfTry);

        Assert.True(result.Success);
        Assert.IsType<List<int>>(result.Value);
        Assert.Equal(2, result.Value!.Count);
    }
}