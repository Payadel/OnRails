using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.Map;

public static partial class MapExtensions {
    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> source,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
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

    public static Task<Result> Map<TSource>(
        this Task<TSource> source,
        Action<TSource> onSuccessAction,
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<TSource> source,
        Action onSuccessAction,
        Func<ResultDetail, Result> onFailFunction,
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
        Func<ResultDetail, Result<TResult>> onFailFunction,
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
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(() => TryExtensions.Try(onSuccessAction, numOfTry));

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
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> source,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
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
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task source,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
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
        Func<ResultDetail?, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail?, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

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
        Func<ResultDetail?, Result> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<Result<TSource>> source,
        Action onSuccessAction,
        Func<ResultDetail?, Result> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

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
        Func<ResultDetail, Result<TResult>> onFailFunction,
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
        Func<ResultDetail, Result> onFailFunction,
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