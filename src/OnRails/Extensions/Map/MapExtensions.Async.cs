using OnRails.Extensions.OnFail;
using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;

namespace OnRails.Extensions.Map;

public static partial class MapExtensions {
    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> source,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> source,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> source,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(function, numOfTry);

    public static Task<Result> Map<T>(
        this Task<T> source,
        Action<T> onSuccessAction,
        Func<Result, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<TSource> source,
        Action onSuccessAction,
        Func<Result, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<TSource> source,
        Action<TSource> onSuccessFunction,
        Func<Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task source,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task source,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task source,
        Func<TResult> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(function, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task source,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(function, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this TSource _,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(function, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task source,
        Func<Result<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(function, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task source,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(function, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this TSource _,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(function, numOfTry);

    //TODO: onFailFunction
    public static Task<Result> Map(
        this Task source,
        Action onSuccessAction,
        Func<Result, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessAction)
        .OnFail(onFailFunction);

    public static Task<Result> Map(
        this Task source,
        Action onSuccessAction,
        Func<Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> source,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> source,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> source,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<TSource> source,
        Func<Result> onSuccessFunction,
        Func<Result, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task source,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task source,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this TSource _,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(function, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this TSource source,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => source.Try(function, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> source,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(result => result.Try(function, numOfTry));

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this TSource source,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => source.Try(function, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> source,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(result => result.Try(function, numOfTry));

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> source,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(result => result.Try(function, numOfTry));

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<Result<TSource>> source,
        Action<TSource> onSuccessFunction,
        Func<Result, Result> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<Result<TSource>> source,
        Action onSuccessAction,
        Func<Result, Result> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<Result<TSource>> source,
        Action<TSource> onSuccessAction,
        Func<Result> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task<Result> source,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task<Result> source,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map(
        this Task<Result> source,
        Action onSuccessAction,
        Func<Result, Result> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map(
        this Task<Result> source,
        Action onSuccessAction,
        Func<Result> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<Result<TSource>> source
    ) => TryExtensions.Try(source)
        .OnSuccess(Result.Ok);
}