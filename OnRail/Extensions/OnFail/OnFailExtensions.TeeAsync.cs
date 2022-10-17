using OnRail.Extensions.Tee;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Task<Result<TSource>> OnFailTee<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Task<Result<TSource>> OnFailTee<TSource>(
        this Task<Result<TSource>> source,
        Action action,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(action, numOfTry));

    public static Task<Result<TSource>> OnFailTee<TSource>(
        this Task<Result<TSource>> source,
        Action<Result<TSource>> action,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(action, numOfTry));

    public static Task<Result<TSource>> OnFailTee<TSource>(
        this Task<Result<TSource>> source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Task<Result<TSource>> OnFailTee<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<Result<TSource>, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Task<Result<TSource>> OnFailTee<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<Result<TSource>, Result<TResult>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Task<Result<TSource>> OnFailTee<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<Result<TResult>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Task<Result<TSource>> OnFailTee<TSource>(
        this Task<Result<TSource>> source,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Task<Result<T>> OnFailTee<T>(
        this Task<Result<T>> source,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Task<Result<T>> OnFailTee<T>(
        this Task<Result<T>> source,
        Func<Result<T>, Task> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));
}