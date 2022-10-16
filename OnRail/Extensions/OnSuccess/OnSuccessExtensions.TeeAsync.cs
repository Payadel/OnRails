using OnRail.Extensions.Tee;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Task<Result<T>> OnSuccessTee<T>(
        this Task<Result<T>> source,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.Tee(action, numOfTry));

    public static Task<Result<T>> OnSuccessTee<T>(
        this Task<Result<T>> source,
        Action action,
        int numOfTry = 1) => source
        .OnSuccess(() => source.Tee(action, numOfTry));

    public static Task<Result> OnSuccessTee(
        this Task<Result> source,
        Action action,
        int numOfTry = 1) =>
        source.OnSuccess(() => source.Tee(action, numOfTry));

    public static Task<Result<TSource>> OnSuccessTee<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.Tee(function, numOfTry));

    public static Task<Result<TSource>> OnSuccessTee<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TResult> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.Tee(function, numOfTry));

    public static Task<Result> OnSuccessTee<TResult>(
        this Task<Result> source,
        Func<TResult> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.Tee(function, numOfTry));
}