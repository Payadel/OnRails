using OnRails.Extensions.Tee;

namespace OnRails.Extensions.OperateWhen;

public static partial class OperateWhenExtensions {
    public static Task<T> TeeOperateWhen<T>(
        this T source,
        bool condition,
        Func<Task> function,
        int numOfTry = 1) =>
        source.Tee(() => OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> TeeOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Task> function,
        int numOfTry = 1) =>
        source.Tee(() => OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<TSource> TeeOperateWhen<TSource, TResult>(
        this TSource source,
        bool condition,
        Func<Task<TResult>> function,
        int numOfTry = 1) =>
        source.Tee(() => OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<Result<TSource>> TeeOperateWhen<TSource, TResult>(
        this Result<TSource> source,
        bool condition,
        Func<Task<TResult>> function,
        int numOfTry = 1) =>
        source.Tee(() => OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<T> TeeOperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<Task> function,
        int numOfTry = 1) =>
        source.Tee(() => OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<T>> TeeOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Task> function,
        int numOfTry = 1) =>
        source.Tee(() => OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<TSource> TeeOperateWhen<TSource, TResult>(
        this TSource source,
        Func<bool> predicate,
        Func<Task<TResult>> function,
        int numOfTry = 1) =>
        source.Tee(() => OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<Result<TSource>> TeeOperateWhen<TSource, TResult>(
        this Result<TSource> source,
        Func<bool> predicate,
        Func<Task<TResult>> function,
        int numOfTry = 1) =>
        source.Tee(() => OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<T> TeeOperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<Task> function,
        int numOfTry = 1) =>
        source.Tee(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<TSource> TeeOperateWhen<TSource, TResult>(
        this TSource source,
        Func<TSource, bool> predicate,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) => source.Tee(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<T> TeeOperateWhen<T>(
        this T source,
        bool condition,
        Func<T, Task> function,
        int numOfTry = 1
    ) => source.Tee(() => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<T> TeeOperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<T, Task> function,
        int numOfTry = 1
    ) => source.Tee(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Task<TSource> TeeOperateWhen<TSource, TResult>(
        this TSource source,
        bool condition,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => source.Tee(() => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Task<TSource> TeeOperateWhen<TSource, TResult>(
        this TSource source,
        Func<bool> predicate,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => source.Tee(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);
}