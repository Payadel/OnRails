using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.Map;

public static partial class MapExtensions {
    public static TResult MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, TResult> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction() : onFailFunction(@this.Detail);

    public static TResult MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<TResult> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction(@this.Value) : onFailFunction();

    public static TResult MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> onSuccessFunction,
        Func<TResult> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction() : onFailFunction();

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction(@this.Value) : onFailFunction(@this.Detail);

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction() : onFailFunction(@this.Detail);

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction(@this.Value) : onFailFunction();

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction() : onFailFunction();

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => @this.IsSuccess
        ? Result<TResult>.Ok(onSuccessFunction(@this.Value))
        : onFailFunction(@this.Detail);

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction
    ) => @this.IsSuccess
        ? onSuccessFunction(@this.Value)
        : Result<TResult>.Fail(onFailFunction(@this.Detail));

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction
    ) => @this.IsSuccess
        ? Result<TResult>.Ok(onSuccessFunction(@this.Value))
        : Result<TResult>.Fail(onFailFunction(@this.Detail));

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => @this.IsSuccess ? Result<TResult>.Ok(onSuccessFunction()) : onFailFunction(@this.Detail);

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction() : Result<TResult>.Fail(onFailFunction(@this.Detail));

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction
    ) => @this.IsSuccess
        ? Result<TResult>.Ok(onSuccessFunction())
        : Result<TResult>.Fail(onFailFunction(@this.Detail));

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) => @this.IsSuccess ? Result<TResult>.Ok(onSuccessFunction(@this.Value)) : onFailFunction();

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        ErrorDetail errorDetail
    ) => @this.IsSuccess ? onSuccessFunction(@this.Value) : Result<TResult>.Fail(errorDetail);

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        ErrorDetail errorDetail
    ) => @this.IsSuccess
        ? Result<TResult>.Ok(onSuccessFunction(@this.Value))
        : Result<TResult>.Fail(errorDetail);

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) => @this.IsSuccess ? Result<TResult>.Ok(onSuccessFunction()) : onFailFunction();

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> onSuccessFunction,
        ErrorDetail errorDetail
    ) => @this.IsSuccess ? onSuccessFunction() : Result<TResult>.Fail(errorDetail);

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> onSuccessFunction,
        ErrorDetail errorDetail
    ) => @this.IsSuccess
        ? Result<TResult>.Ok(onSuccessFunction())
        : Result<TResult>.Fail(errorDetail);

    public static Result<TResult> MapResult<TResult>(
        this Result @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction() : onFailFunction(@this.Detail);

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction
    ) => @this.IsSuccess ? onSuccessFunction(@this.Value) : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> onSuccessFunction
    ) => @this.IsSuccess ? onSuccessFunction() : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> MapResult<TResult>(
        this Result @this,
        Func<Result<TResult>> onSuccessFunction
    ) => @this.IsSuccess ? onSuccessFunction() : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> MapResult<TResult>(
        this Result @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => @this.IsSuccess ? Result<TResult>.Ok(onSuccessFunction()) : onFailFunction(@this.Detail);

    public static Result<TResult> MapResult<TResult>(
        this Result @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction() : Result<TResult>.Fail(onFailFunction(@this.Detail));

    public static Result<TResult> MapResult<TResult>(
        this Result @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, ErrorDetail> onFailFunction
    ) => @this.IsSuccess
        ? Result<TResult>.Ok(onSuccessFunction())
        : Result<TResult>.Fail(onFailFunction(@this.Detail));

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        TResult value) => @this
        .OnSuccess(value)
        .OnFail(methodResult => Result<TResult>.Fail(methodResult.Detail));

    public static Result<TResult> MapResult<TResult>(
        this Result @this,
        TResult value) => @this
        .OnSuccess(value)
        .OnFail(methodResult => Result<TResult>.Fail(methodResult.Detail));

    public static Result MapResult<TSource>(
        this Result<TSource> @this) =>
        @this.IsSuccess ? Result.Ok() : Result.Fail(@this.Detail);

    public static Result<TResult> MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<ResultDetail, TResult> onFailFunction
    ) => TryExtensions.Try<TResult>(() => @this.MapResult(onSuccessFunction, onFailFunction));

    public static Result<TResult> MapResult<TResult>(
        this Result @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, TResult> onFailFunction
    ) => TryExtensions.Try<TResult>(() => @this.MapResult(onSuccessFunction, onFailFunction));

    public static async Task<Result<TResult>> MapResult<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result<TResult>> MapResult<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result<TResult>> MapResult<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(onFailFunction);

    public static async Task<Result<TResult>> MapResult<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> onSuccessFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction);

    public static async Task<Result> MapResult<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result> MapResult<TSource>(
        this Task<Result<TSource>> @this,
        Action onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result> MapResult<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> onSuccessFunction,
        Func<Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(onFailFunction);

    public static async Task<Result> MapResult<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> onSuccessFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction);

    public static async Task<Result<TResult>> MapResult<TResult>(
        this Task<Result> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result<TResult>> MapResult<TResult>(
        this Task<Result> @this,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(onFailFunction);

    public static async Task<Result<TResult>> MapResult<TResult>(
        this Task<Result> @this,
        Func<TResult> onSuccessFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction);

    public static async Task<Result> MapResult(
        this Task<Result> @this,
        Action onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result> MapResult(
        this Task<Result> @this,
        Action onSuccessFunction,
        Func<Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(onFailFunction);

    public static async Task<Result> MapResult(
        this Task<Result> @this,
        Action onSuccessFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction);
}