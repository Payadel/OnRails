using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions.Map;

public static partial class MapExtensions {
    #region Map

    public static TResult Map<TSource, TResult>(
        this TSource _,
        TResult result) => result;

    public static Result<TResult> Map<TSource, TResult>(
        this TSource _,
        Func<Result<TResult>> onSuccessFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(onSuccessFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this TSource _,
        Func<TResult> onSuccessFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(onSuccessFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this TSource @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) => @this.Try(function, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this TSource @this,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) => @this.Try(function, numOfTry);

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
        Func<TSource, TResult> onSuccessFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(result => result.Try(onSuccessFunction, numOfTry));

    public static Task<Result> Map<TSource>(
        this Task<TSource> @this,
        Action<TSource> onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(result => result.Try(onSuccessFunction, numOfTry));

    public static Task<Result> Map<TSource>(
        this Task<TSource> @this,
        Action onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
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
        Func<TResult> onSuccessFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(() => TryExtensions.Try(onSuccessFunction, numOfTry));

    public static Task<Result<TResult>> Map<TResult>(
        this Task @this,
        Func<Task<TResult>> onSuccessFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(() => TryExtensions.Try(onSuccessFunction, numOfTry));

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this TSource _,
        Func<Task<TResult>> onSuccessFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(onSuccessFunction, numOfTry);

    public static Task<Result<TResult>> Map<TResult>(
        this Task @this,
        Func<Result<TResult>> onSuccessFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(() => TryExtensions.Try(onSuccessFunction, numOfTry));

    public static Task<Result<TResult>> Map<TResult>(
        this Task @this,
        Func<Task<Result<TResult>>> onSuccessFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(() => TryExtensions.Try(onSuccessFunction, numOfTry));

    public static Task<Result<TResult>> Map<TSource, TResult>(
        this TSource _,
        Func<Task<Result<TResult>>> onSuccessFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(onSuccessFunction, numOfTry);

    public static Task<Result> Map(
        this Task @this,
        Action onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(() => TryExtensions.Try(onSuccessFunction, numOfTry));

    public static Task<Result> Map(
        this Task @this,
        Action onSuccessFunction,
        Func<Result> onFailFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(onSuccessFunction, numOfTry)
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
        Func<Task<Result>> onSuccessFunction,
        int numOfTry = 1
    ) => TryExtensions.Try(onSuccessFunction, numOfTry);

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

    #endregion

    #region GetValue

    public static T GetValue<T>(this Result<T> @this) => @this.Value!;

    #endregion

    #region MapToTask

    public static Task<T> MapToTask<T>(this T @this) => Task.FromResult(@this);

    #endregion
}