using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

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
    
    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => result.Fail(errorDetail), numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => result.Fail(errorDetail), numOfTry);


    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);


    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> onSuccessFunction,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => result.Fail(errorDetail), numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> onSuccessFunction,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => result.Fail(errorDetail), numOfTry);

    public static Result<TResult> Map<TResult>(
        this Result @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TResult>(
        this Result @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TResult>(
        this Result @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TResult>(
        this Result @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        TResult value) => @this
        .OnSuccess(value)
        .OnFail(result => Result<TResult>.Fail(result.Detail));

    public static Result<TResult> Map<TResult>(
        this Result @this,
        TResult value) => @this
        .OnSuccess(value)
        .OnFail(result => Result<TResult>.Fail(result.Detail));

    public static Result Map<TSource>(
        this Result<TSource> @this) =>
        @this.IsSuccess ? Result.Ok() : Result.Fail(@this.Detail);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<ResultDetail, TResult> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);

    public static Result<TResult> Map<TResult>(
        this Result @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, TResult> onFailFunction,
        int numOfTry = 1
    ) => @this
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => onFailFunction(result.Detail), numOfTry);
    
    #endregion

    #region GetValue

    public static T GetValue<T>(this Result<T> @this) => @this.Value!;

    #endregion

    #region MapToTask

    public static Task<T> MapToTask<T>(this T @this) => Task.FromResult(@this);

    #endregion
}