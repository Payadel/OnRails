namespace OnRail.Extensions;

//TODO: Add numOfTry to OnSuccessAsync

public static class TaskExtensions {
    #region Task

    public static Task<Result> Bind(
        this IEnumerable<Task> tasks,
        int numOfTry = 1) =>
        TryExtensions.Try(async () => {
            foreach (var task in tasks) {
                await task;
            }
        }, numOfTry);

    public static Task<Result<List<T>>> Bind<T>(
        this IEnumerable<Task<T>> tasks,
        int numOfTry = 1) =>
        TryExtensions.Try(async () => {
            var items = tasks.ToList();
            var result = new List<T>(items.Count);

            foreach (var task in items) {
                result.Add(await task);
            }

            return result;
        }, numOfTry);


    //TODO: Test
    public static Task<Result> Bind(
        this Task thisTask,
        int numOfTry = 1,
        params Task[] tasks) =>
        TryExtensions.Try(async () => await thisTask, numOfTry)
            .OnSuccessAsync(() => tasks.Bind());

    //TODO: Test
    public static Task<Result<List<T>>> Bind<T>(
        this Task<T> thisTask,
        int numOfTry = 1,
        params Task<T>[] tasks) =>
        TryExtensions.Try(async () => await thisTask, numOfTry)
            .OnSuccessAsync(task1 => tasks.Bind()
                .OnSuccessAsync(taskResults => {
                    taskResults.Add(task1);
                    return taskResults;
                }));

    #endregion
}