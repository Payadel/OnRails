using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails.Extensions.Bind;

public static class BindExtensions {
    public static async Task<Result> Bind(
        this IEnumerable<Task> tasks,
        int numOfTry = 1
    ) {
        foreach (var task in tasks) {
            var result = await TryExtensions.Try(task, numOfTry);
            if (!result.Success)
                return result;
        }

        return Result.Ok();
    }

    public static Task<Result<List<T>>> Bind<T>(
        this IEnumerable<Task<T>> tasks,
        int numOfTry = 1
    ) => TryExtensions.Try(async () => {
        var items = tasks.ToList();
        var result = new List<T>(items.Count);

        foreach (var task in items) {
            var taskResult = await TryExtensions.Try(task, numOfTry);
            if (!taskResult.Success)
                return Result<List<T>>.Fail(taskResult.Detail as ErrorDetail);
            result.Add(taskResult.Value!);
        }

        return Result<List<T>>.Ok(result);
    }, numOfTry: 1);

    //TODO: Test
    public static Task<Result> Bind(
        this Task source,
        int numOfTry = 1,
        params Task[] tasks
    ) => TryExtensions.Try(() => source, numOfTry)
        .OnSuccess(() => tasks.Bind(numOfTry));

    //TODO: Test
    public static Task<Result<List<T>>> Bind<T>(
        this Task<T> source,
        int numOfTry = 1,
        params Task<T>[] tasks
    ) => TryExtensions.Try(() => source, numOfTry)
        .OnSuccess(t => tasks.Bind(numOfTry)
            .OnSuccess(taskResults => {
                taskResults.Add(t);
                return taskResults;
            }, numOfTry));
}