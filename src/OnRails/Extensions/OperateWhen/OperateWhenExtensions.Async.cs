using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;

namespace OnRails.Extensions.OperateWhen;

public static partial class OperateWhenExtensions {
    #region Condition base boolean

    public static Task<Result> OperateWhen(
        bool condition,
        Func<Task> function,
        int numOfTry = 1
    ) => TryExtensions.Try(async () => {
        if (condition)
            await function();
    }, numOfTry);

    public static Task<Result> OperateWhen(
        Func<bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => TryExtensions.Try(async () => {
        var condition = predicate();
        if (condition)
            await function();
    }, numOfTry);

    public static Task<Result> OperateWhen(
        bool condition,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(async () => {
        if (condition)
            await function();
    }, numOfTry);

    public static Task<Result> OperateWhen(
        Func<bool> predicate,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        bool condition,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => source.Try(numOfTry)
        .OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        bool condition,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.Try(numOfTry)
        .OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        bool condition,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.Try(numOfTry)
        .OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(async () => predicate(await source))
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        bool condition,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.Try(numOfTry)
        .OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<bool> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.Try(numOfTry)
        .OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<T, bool> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.Try(numOfTry)
        .OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

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
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

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
        .OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.Try(numOfTry)
        .OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> source,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.Try(numOfTry)
        .OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static async Task<Result<T>> OperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => condition
        ? await TryExtensions.Try(function, numOfTry)
        : source;

    public static async Task<Result> OperateWhen(
        this Result source,
        bool condition,
        Func<Task> function,
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

    public static async Task<Result> OperateWhen(
        this Result source,
        bool condition,
        Func<Task<Result>> function,
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
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result> OperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result> OperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Result<T> source,
        Func<Result<T>, bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result> OperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Result<T>, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result> OperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result> OperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result> OperateWhen(
        this Result source,
        bool condition,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) => condition ? source.Try(function, numOfTry) : Task.FromResult(source);

    public static Task<Result<T>> OperateWhen<T>(
        this Result<T> source,
        Func<Result<T>, bool> predicate,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result> OperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<T, Task<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicate, numOfTry)
            .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

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
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static async Task<Result<T>> OperateWhen<T>(
        this T source,
        Func<T, Result> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => predicate(source).Success
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

    public static async Task<Result<T>> OperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Result<T>, Task<Result<T>>> operation,
        int numOfTry = 1
    ) => condition
        ? await source.Try(operation, numOfTry)
        : source;

    public static Task<Result<T>> OperateWhen<T>(
        this Result<T> source,
        Func<Result<T>, bool> predicateFunc,
        Func<Result<T>, Task<Result<T>>> operation,
        int numOfTry = 1
    ) => source.Try(predicateFunc, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, operation, numOfTry), numOfTry: 1);

    #endregion
}