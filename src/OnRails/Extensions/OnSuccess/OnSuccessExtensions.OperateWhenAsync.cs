using OnRails.Extensions.OperateWhen;

namespace OnRails.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> source,
        Func<bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> source,
        Func<bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> source,
        Func<bool> predicate,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, action, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, action, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, action, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, action, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<T> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<T, T> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        Func<T, T> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> source,
        bool condition,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> source,
        bool condition,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(condition, action, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> source,
        bool condition,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        bool condition,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, action, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        bool condition,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, action, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<T> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<T, T> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result source,
        Func<bool> predicate,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result source,
        Func<bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        Func<T, bool> predicate,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        Func<T, bool> predicate,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<T, Task<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        Func<T, bool> predicate,
        Func<T, Task<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result source,
        bool condition,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result source,
        bool condition,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        bool condition,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        bool condition,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        bool condition,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        bool condition,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> source,
        bool condition,
        Func<T, Task<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> source,
        Func<bool> predicate,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> source,
        bool condition,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.OperateWhen(condition, function, numOfTry), numOfTry: 1);
}