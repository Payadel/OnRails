using OnRail.Extensions.Fail;
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
        Func<Result<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(function, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this TSource _,
        Func<TResult> function,
        int numOfTry = 1
    ) => TryExtensions.Try(function, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this TSource source,
        Func<TSource, TResult> function,
        int numOfTry = 1) => source.Try(function, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this TSource source,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) => source.Try(function, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<Result<TResult>, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, Result<TResult>> onSuccessFunction,
        ErrorDetail? errorDetail,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => result.Fail(errorDetail), numOfTry: 1);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, TResult> onSuccessFunction,
        ErrorDetail? errorDetail,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => result.Fail(errorDetail), numOfTry: 1);


    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);


    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<Result<TResult>> onSuccessFunction,
        ErrorDetail? errorDetail,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => result.Fail(errorDetail), numOfTry: 1);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        Func<TResult> onSuccessFunction,
        ErrorDetail? errorDetail,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(result => result.Fail(errorDetail), numOfTry: 1);

    public static Result<TResult> Map<TResult>(
        this Result source,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TResult>(
        this Result source,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>, Result<TResult>> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TResult>(
        this Result source,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TResult>(
        this Result source,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>, ErrorDetail> onFailFunction,
        int numOfTry = 1
    ) => source
        .OnSuccess(onSuccessFunction, numOfTry)
        .OnFail(onFailFunction, numOfTry);

    public static Result<TResult> Map<TSource, TResult>(
        this Result<TSource> source,
        TResult value) => source.OnSuccess(value);

    public static Result<T> Map<T>(
        this Result source,
        T value
    ) => source.OnSuccess(value);

    public static Result Map<TSource>(
        this Result<TSource> source) =>
        source.IsSuccess ? Result.Ok() : Result.Fail(source.Detail as ErrorDetail);

    #endregion

    #region MapToTask

    public static Task<T> MapToTask<T>(this T source) => Task.FromResult(source);

    #endregion
}