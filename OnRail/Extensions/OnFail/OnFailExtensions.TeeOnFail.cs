using OnRail.Extensions.Tee;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> source, Action action, int numOfTry = 1) =>
        source.OnFail(() => TeeExtensions.Tee(action, numOfTry));

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> source, Action<Result<TSource>> action, int numOfTry = 1) =>
        source.OnFail(result => result.Tee(action, numOfTry));

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.OnFail(() => TeeExtensions.Tee(function, numOfTry));

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> source,
        Func<Result<TSource>, Result<TResult>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> source,
        Func<Result<TResult>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> source,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Result<T> TeeOnFail<T>(
        this Result<T> source,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Result<T> TeeOnFail<T>(
        this Result<T> source,
        Func<Result<T>, Task> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));
}