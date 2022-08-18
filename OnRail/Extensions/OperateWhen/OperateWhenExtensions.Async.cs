using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.OperateWhen;

//TODO: Test

public static partial class OperateWhenExtensions {
    public static async Task<Result> OperateWhen(
        bool condition,
        Func<Task> function,
        int numOfTry = 1
    ) {
        if (condition)
            return await TryExtensions.Try(function, numOfTry);
        return Result.Ok();
    }

    public static Task<Result> OperateWhen(
        Func<bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate)
        .OnSuccess(condition => OperateWhen(condition, function, numOfTry));

    public static async Task<Result> OperateWhen(
        bool condition,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) {
        if (condition)
            return await TryExtensions.Try(function, numOfTry);
        return Result.Ok();
    }

    public static Task<Result> OperateWhen(
        Func<bool> predicate,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate)
        .OnSuccess(condition => OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        bool condition,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(async () => {
        var t = await source;
        return condition
            ? await function()
            : t;
    }, numOfTry);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(async () => {
        var t = await source;
        return condition
            ? Result<T>.Ok(await function())
            : t;
    }, numOfTry);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        bool condition,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) => TryExtensions.Try(async () => {
        var t = await source;
        return condition
            ? await function()
            : Result<T>.Ok(t);
    }, numOfTry);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        bool condition,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1) => TryExtensions.Try(async () => {
        var t = await source;
        return condition
            ? await function(t)
            : Result<T>.Ok(t);
    }, numOfTry);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(async () => predicate(await source))
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        bool condition,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(t => t.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<bool> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(t => t.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<T, bool> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(t => t.OperateWhen(predicate, function, numOfTry));

    public static async Task<Result<T>> OperateWhen<T>(
        this T source,
        bool condition,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => condition
        ? await TryExtensions.Try(function, numOfTry)
        : Result<T>.Ok(source);

    public static async Task<Result<T>> OperateWhen<T>(
        this T source,
        bool condition,
        Func<T, Task<T>> function,
        int numOfTry = 1
    ) => condition
        ? await source.Try<T, T>(function, numOfTry)
        : Result<T>.Ok(source);

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<T, Task<T>> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static async Task<Result<T>> OperateWhen<T>(
        this T source,
        bool condition,
        Func<Task> function,
        int numOfTry = 1
    ) => condition
        ? await TryExtensions.Try(function, numOfTry)
            .OnSuccess(() => source)
        : Result<T>.Ok(source);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(t => t.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(t => t.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(t => t.OperateWhen(predicate, function, numOfTry));

    public static async Task<Result<T>> OperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => condition
        ? await TryExtensions.Try(function, numOfTry)
        : source;

    public static async Task<Result<T>> OperateWhen<T>(
        this T source,
        bool condition,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => condition
        ? await TryExtensions.Try(function, numOfTry)
        : Result<T>.Ok(source);

    public static async Task<Result<T>> OperateWhen<T>(
        this T source,
        bool condition,
        Func<T, Task> function,
        int numOfTry = 1
    ) => condition
        ? await source.Try(function, numOfTry)
            .OnSuccess(() => source)
        : Result<T>.Ok(source);

    public static async Task<Result<T>> OperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => condition
        ? await TryExtensions.Try(function, numOfTry)
        : source;

    public static Task<Result<T>> OperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(t => t.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<T, Task<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicate, numOfTry)
            .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static async Task<Result<T>> OperateWhen<T>(
        this T source,
        bool condition,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => condition
        ? await source.Try<T>(function, numOfTry)
        : Result<T>.Ok(source);

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry));

    public static async Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<T, Result> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => predicate(source).IsSuccess
        ? await TryExtensions.Try(function, numOfTry)
        : Result<T>.Ok(source);

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<T, Task> function,
        int numOfTry = 1
    ) => TryExtensions.Try(async () => {
        if (predicate())
            await function(source);
        return source;
    }, numOfTry);
}