using OnRail.Extensions.Try;
using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions;

public static class MapExtensions {
    #region Map

    public static TResult Map<TSource, TResult>(
        this TSource @this,
        Func<TSource, TResult> function) => function(@this);

    public static TResult Map<TSource, TResult>(
        this TSource _,
        Func<TResult> function) => function();

    public static TResult Map<TSource, TResult>(
        this TSource _,
        TResult result) => result;

    #endregion

    #region MapResult

    public static TResult MapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<ResultDetail, TResult> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction(@this.Value) : onFailFunction(@this.Detail);

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

    public static TResult MapResult<TResult>(
        this Result @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, TResult> onFailFunction
    ) => @this.IsSuccess ? onSuccessFunction() : onFailFunction(@this.Detail);

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

    #endregion

    #region TryMap

    public static Result<TResult> TryMap<TSource, TResult>(
        this TSource _,
        Func<Result<TResult>> onSuccessFunction
    ) => TryExtensions.Try(onSuccessFunction);

    public static Result<TResult> TryMap<TSource, TResult>(
        this TSource _,
        Func<TResult> onSuccessFunction
    ) => TryExtensions.Try(onSuccessFunction);

    public static Result<TResult> TryMap<TSource, TResult>(
        this TSource @this,
        Func<TSource, TResult> function) => TryExtensions.Try(() => function(@this));

    public static Result<TResult> TryMap<TSource, TResult>(
        this TSource @this,
        Func<TSource, Result<TResult>> function) =>
        TryExtensions.Try(() => function(@this));

    #endregion

    #region TryMapResult

    public static Result<TResult> TryMapResult<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<ResultDetail, TResult> onFailFunction
    ) => TryExtensions.Try(() => @this.MapResult(onSuccessFunction, onFailFunction));

    public static Result<TResult> TryMapResult<TResult>(
        this Result @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, TResult> onFailFunction
    ) => TryExtensions.Try(() => @this.MapResult(onSuccessFunction, onFailFunction));

    #endregion

    #region TryMapAsync

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) {
        try {
            await @this;
            var result = onSuccessFunction();
            return Result<TResult>.Ok(result);
        }
        catch (Exception e) {
            return Result<TResult>.Fail(new ExceptionError(e));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) {
        try {
            var source = await @this;
            var result = onSuccessFunction(source);
            return Result<TResult>.Ok(result);
        }
        catch (Exception) {
            return onFailFunction();
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, TResult> onSuccessFunction
    ) {
        try {
            var source = await @this;
            var result = onSuccessFunction(source);
            return Result<TResult>.Ok(result);
        }
        catch (Exception e) {
            return Result<TResult>.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Task<Result<TResult>>> onSuccessFunction
    ) {
        try {
            var source = await @this;
            return await onSuccessFunction(source);
        }
        catch (Exception e) {
            return Result<TResult>.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<Result<TResult>>> onSuccessFunction
    ) => TryExtensions.Try(() => onSuccessFunction(@this));

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Task<TResult>> onSuccessFunction
    ) {
        try {
            var source = await @this;
            var result = await onSuccessFunction(source);
            return Result<TResult>.Ok(result);
        }
        catch (Exception e) {
            return Result<TResult>.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<TResult>> onSuccessFunction
    ) => TryExtensions.Try(() => onSuccessFunction(@this));

    public static async Task<Result> TryMapAsync<TSource>(
        this Task<TSource> @this,
        Action<TSource> onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction
    ) {
        try {
            var source = await @this;
            onSuccessFunction(source);
            return Result.Ok();
        }
        catch (Exception e) {
            return onFailFunction(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryMapAsync<TSource>(
        this Task<TSource> @this,
        Action onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction
    ) {
        try {
            await @this;
            onSuccessFunction();
            return Result.Ok();
        }
        catch (Exception e) {
            return onFailFunction(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryMapAsync<TSource>(
        this Task<TSource> @this,
        Action<TSource> onSuccessFunction,
        Func<Result> onFailFunction
    ) {
        try {
            var source = await @this;
            onSuccessFunction(source);
            return Result.Ok();
        }
        catch (Exception) {
            return onFailFunction();
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TResult>(
        this Task @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) {
        try {
            await @this;
            var result = onSuccessFunction();
            return Result<TResult>.Ok(result);
        }
        catch (Exception e) {
            return onFailFunction(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TResult>(
        this Task @this,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) {
        try {
            await @this;
            var result = onSuccessFunction();
            return Result<TResult>.Ok(result);
        }
        catch (Exception) {
            return onFailFunction();
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TResult>(
        this Task @this,
        Func<TResult> onSuccessFunction
    ) {
        try {
            await @this;
            var result = onSuccessFunction();
            return Result<TResult>.Ok(result);
        }
        catch (Exception e) {
            return Result<TResult>.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TResult>(
        this Task @this,
        Func<Task<TResult>> onSuccessFunction
    ) {
        try {
            await @this;
            var result = await onSuccessFunction();
            return Result<TResult>.Ok(result);
        }
        catch (Exception e) {
            return Result<TResult>.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this TSource _,
        Func<Task<TResult>> onSuccessFunction
    ) {
        try {
            var result = await onSuccessFunction();
            return Result<TResult>.Ok(result);
        }
        catch (Exception e) {
            return Result<TResult>.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TResult>(
        this Task @this,
        Func<Result<TResult>> onSuccessFunction
    ) {
        try {
            await @this;
            return onSuccessFunction();
        }
        catch (Exception e) {
            return Result<TResult>.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TResult>(
        this Task @this,
        Func<Task<Result<TResult>>> onSuccessFunction
    ) {
        try {
            await @this;
            return await onSuccessFunction();
        }
        catch (Exception e) {
            return Result<TResult>.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this TSource _,
        Func<Task<Result<TResult>>> onSuccessFunction
    ) {
        try {
            return await onSuccessFunction();
        }
        catch (Exception e) {
            return Result<TResult>.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryMapAsync(
        this Task @this,
        Action onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction
    ) {
        try {
            await @this;
            onSuccessFunction();
            return Result.Ok();
        }
        catch (Exception e) {
            return onFailFunction(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryMapAsync(
        this Task @this,
        Action onSuccessFunction,
        Func<Result> onFailFunction
    ) {
        try {
            await @this;
            onSuccessFunction();
            return Result.Ok();
        }
        catch (Exception) {
            return onFailFunction();
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) {
        try {
            var source = await @this;
            return onSuccessFunction(source);
        }
        catch (Exception e) {
            return onFailFunction(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) {
        try {
            await @this;
            return onSuccessFunction();
        }
        catch (Exception e) {
            return onFailFunction(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) {
        try {
            var source = await @this;
            return onSuccessFunction(source);
        }
        catch (Exception) {
            return onFailFunction();
        }
    }

    public static async Task<Result> TryMapAsync<TSource>(
        this Task<TSource> @this,
        Func<Result> onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction
    ) {
        try {
            await @this;
            return onSuccessFunction();
        }
        catch (Exception e) {
            return onFailFunction(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TResult>(
        this Task @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) {
        try {
            await @this;
            return onSuccessFunction();
        }
        catch (Exception e) {
            return onFailFunction(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryMapAsync<TResult>(
        this Task @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) {
        try {
            await @this;
            return onSuccessFunction();
        }
        catch (Exception) {
            return onFailFunction();
        }
    }

    public static Task<Result> TryMapAsync<TSource>(
        this TSource _,
        Func<Task<Result>> onSuccessFunction
    ) => TryExtensions.Try(onSuccessFunction);

    public static Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry
    ) => TryExtensions.Try(() => function(@this), numOfTry);

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry
    ) {
        var t = await @this;
        return await TryExtensions.Try(() => function(t), numOfTry);
    }

    public static Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry
    ) => TryExtensions.Try(() => function(@this), numOfTry);

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry
    ) {
        var t = await @this;
        return await TryExtensions.Try(() => function(t), numOfTry);
    }

    public static async Task<Result<TResult>> TryMapAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Result<TResult>> function
    ) {
        var t = await @this;
        return TryExtensions.Try(() => function(t));
    }

    #endregion

    #region TryMapResultAsync

    public static async Task<Result<TResult>> TryMapResultAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .TryOnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result<TResult>> TryMapResultAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .TryOnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result<TResult>> TryMapResultAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .TryOnFail(onFailFunction);

    public static async Task<Result<TResult>> TryMapResultAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> onSuccessFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction);

    public static async Task<Result> TryMapResultAsync<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .TryOnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result> TryMapResultAsync<TSource>(
        this Task<Result<TSource>> @this,
        Action onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .TryOnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result> TryMapResultAsync<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> onSuccessFunction,
        Func<Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .TryOnFail(onFailFunction);

    public static async Task<Result> TryMapResultAsync<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> onSuccessFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction);

    public static async Task<Result<TResult>> TryMapResultAsync<TResult>(
        this Task<Result> @this,
        Func<TResult> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .TryOnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result<TResult>> TryMapResultAsync<TResult>(
        this Task<Result> @this,
        Func<TResult> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .TryOnFail(onFailFunction);

    public static async Task<Result<TResult>> TryMapResultAsync<TResult>(
        this Task<Result> @this,
        Func<TResult> onSuccessFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction);

    public static async Task<Result> TryMapResultAsync(
        this Task<Result> @this,
        Action onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .TryOnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result> TryMapResultAsync(
        this Task<Result> @this,
        Action onSuccessFunction,
        Func<Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .TryOnFail(onFailFunction);

    public static async Task<Result> TryMapResultAsync(
        this Task<Result> @this,
        Action onSuccessFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction);

    #endregion

    #region MapResultAsync

    public static async Task<Result<TResult>> MapResultAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result<TResult>> MapResultAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result<TResult>> MapResultAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(onFailFunction);

    public static async Task<Result> MapResultAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result> onSuccessFunction,
        Func<Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(onFailFunction);

    public static async Task<Result<TResult>> MapResultAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result<TResult>> onSuccessFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction);

    public static async Task<Result> MapResultAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result> onSuccessFunction,
        Func<ResultDetail, Result> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result<TResult>> MapResultAsync<TResult>(
        this Task<Result> @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<ResultDetail, Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(detail => onFailFunction(detail.Detail));

    public static async Task<Result<TResult>> MapResultAsync<TResult>(
        this Task<Result> @this,
        Func<Result<TResult>> onSuccessFunction,
        Func<Result<TResult>> onFailFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction)
        .OnFail(onFailFunction);

    public static async Task<Result<TResult>> MapResultAsync<TResult>(
        this Task<Result> @this,
        Func<Result<TResult>> onSuccessFunction
    ) => (await @this)
        .OnSuccess(onSuccessFunction);

    public static async Task<Result<TResult>> MapResultAsync<TResult>(
        this Task<Result> @this,
        TResult result
    ) => (await @this).MapResult(result);

    public static async Task<Result> MapResultAsync<TSource>(
        this Task<Result<TSource>> @this) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? Result.Ok() : Result.Fail(methodResult.Detail);
    }

    #endregion

    #region GetValue

    public static T GetValue<T>(this Result<T> @this) => @this.Value;

    #endregion

    #region MapToTask

    public static Task<T> MapToTask<T>(
        this T @this) => Task.FromResult(@this);

    #endregion
}