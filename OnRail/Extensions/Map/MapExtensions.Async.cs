using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.Map;

public static partial class MapExtensions {
    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(function, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<TSource> @this,
        Action<TSource> onSuccessAction,
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<TSource> @this,
        Action onSuccessAction,
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<TSource> @this,
        Action<TSource> onSuccessFunction,
        Func<Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task @this,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task @this,
        Func<TResult> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(function, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task @this,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(function, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this TSource _,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(function, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task @this,
        Func<Result<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(function, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task @this,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(function, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this TSource _,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(function, numOfTry);

    public static Task<Result> Map(
        this Task @this,
        Action onSuccessAction,
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(() => TryExtensions.Try(onSuccessAction, numOfTry));

    public static Task<Result> Map(
        this Task @this,
        Action onSuccessAction,
        Func<Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<TSource> @this,
        Func<Result> onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this TSource _,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(function, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => @this.Try(function, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(result => result.Try(function, numOfTry));

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => @this.Try(function, numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(result => result.Try(function, numOfTry));

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(result => result.Try(function, numOfTry));

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<Result<TSource>> @this,
        Action onSuccessAction,
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Task<Result> Map<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> onSuccessAction,
        Func<Result> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task<Result> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task<Result> @this,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map(
        this Task<Result> @this,
        Action onSuccessAction,
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Task<Result> Map(
        this Task<Result> @this,
        Action onSuccessAction,
        Func<Result> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessAction, numOfTry)
        .OnFail(onFailFunction, numOfTry);
}