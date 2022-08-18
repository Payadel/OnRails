using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Tee;

namespace OnRail.Extensions.TeeOnSuccess;

public static partial class TeeOnSuccessExtensions {
    public static Task<Result<T>> TeeOnSuccess<T>(
        this Task<Result<T>> source,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.Tee(action, numOfTry));

    public static Task<Result<T>> TeeOnSuccess<T>(
        this Task<Result<T>> source,
        Action action,
        int numOfTry = 1) => source
        .OnSuccess(() => source.Tee(action, numOfTry));

    public static Task<Result> TeeOnSuccess(
        this Task<Result> source,
        Action action,
        int numOfTry = 1) =>
        source.OnSuccess(() => source.Tee(action, numOfTry));

    public static Task<Result<TSource>> TeeOnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.Tee(function, numOfTry));

    public static Task<Result<TSource>> TeeOnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TResult> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.Tee(function, numOfTry));

    public static Task<Result> TeeOnSuccess<TResult>(
        this Task<Result> source,
        Func<TResult> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.Tee(function, numOfTry));
}