using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions;

public static class OnFailExtensions {
    #region OnFail

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        ErrorDetail errorDetail) =>
        @this.IsSuccess ? @this : @this.Fail(errorDetail);

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Func<ErrorDetail> errorDetail) =>
        @this.IsSuccess ? @this : @this.Fail(errorDetail());

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        object moreDetail) {
        if (!@this.IsSuccess)
            @this.Detail.AddDetail(moreDetail);
        return @this;
    }

    public static Result OnFail(
        this Result @this,
        ErrorDetail errorDetail) =>
        @this.IsSuccess ? @this : @this.Fail(errorDetail);

    public static Result OnFail(
        this Result @this,
        Func<ErrorDetail> errorDetail) =>
        @this.IsSuccess ? @this : @this.Fail(errorDetail());

    public static Result OnFail(
        this Result @this,
        object moreDetail) {
        if (!@this.IsSuccess)
            @this.Detail.AddDetail(moreDetail);
        return @this;
    }

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Func<Result<T>, Result<T>> fail) =>
        @this.IsSuccess ? @this : fail(@this);

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Func<Result<T>> fail) =>
        @this.IsSuccess ? @this : fail();

    public static Result OnFail(
        this Result @this,
        Func<Result, Result> fail) =>
        @this.IsSuccess ? @this : fail(@this);

    public static Result OnFail(
        this Result @this,
        Func<Result> fail) =>
        @this.IsSuccess ? @this : fail();

    public static Result OnFail(
        this Result @this,
        Action fail) {
        if (!@this.IsSuccess)
            fail();
        return @this;
    }

    public static Result OnFail(
        this Result @this,
        Action<Result> fail) {
        if (!@this.IsSuccess)
            fail(@this);
        return @this;
    }

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Action<Result<T>> fail) {
        if (!@this.IsSuccess)
            fail(@this);
        return @this;
    }

    #endregion

    #region TryOnFail

    public static Result<T> TryOnFail<T>(
        this Result<T> @this,
        Func<ErrorDetail> errorDetail) {
        if (@this.IsSuccess)
            return @this;

        return TryExtensions.Try(
            () => @this.Fail(errorDetail()));
    }

    public static Result TryOnFail(
        this Result @this,
        ErrorDetail errorDetail) {
        if (@this.IsSuccess)
            return @this;

        return TryExtensions.Try(
            () => @this.Fail(errorDetail));
    }

    public static Result TryOnFail(
        this Result @this,
        Func<ErrorDetail> errorDetail) {
        if (@this.IsSuccess)
            return @this;

        return TryExtensions.Try(
            () => @this.Fail(errorDetail()));
    }

    public static Result<T> TryOnFail<T>(
        this Result<T> @this,
        Func<Result<T>, Result<T>> fail) {
        if (@this.IsSuccess)
            return @this;

        return TryExtensions.Try(
            () => fail(@this));
    }

    public static Result<T> TryOnFail<T>(
        this Result<T> @this,
        Func<Result<T>> fail) =>
        @this.IsSuccess ? @this : TryExtensions.Try(fail);

    public static Result TryOnFail(
        this Result @this,
        Func<Result, Result> fail) {
        if (@this.IsSuccess)
            return @this;

        return TryExtensions.Try(
            () => fail(@this));
    }

    public static Result TryOnFail(
        this Result @this,
        Func<Result> fail) =>
        @this.IsSuccess ? @this : TryExtensions.Try(fail);

    public static Result TryOnFail(
        this Result @this,
        Action fail) =>
        @this.IsSuccess ? @this : TryExtensions.Try(fail);

    public static Result<T> TryOnFail<T>(
        this Result<T> @this,
        Action<Result<T>> fail) {
        if (@this.IsSuccess)
            return @this;

        try {
            fail(@this);
            return @this;
        }
        catch (Exception e) {
            return @this.Fail(new ExceptionError(e));
        }
    }

    #endregion

    #region TryOnFailAsync

    public static Task<Result<T>> TryOnFailAsync<T>(
        this Task<Result<T>> @this,
        Func<ErrorDetail> errorDetail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(() => methodResult.Fail(errorDetail())));

    public static Task<Result<T>> TryOnFailAsync<T>(
        this Result<T> @this,
        Func<Task<ErrorDetail>> errorDetail) =>
        @this.OnFailAsync(
            methodResult => TryExtensions.Try(async () => methodResult.Fail(await errorDetail())));

    public static Task<Result<T>> TryOnFailAsync<T>(
        this Task<Result<T>> @this,
        Func<Task<ErrorDetail>> errorDetail) =>
        @this.OnFailAsync(
            methodResult => TryExtensions.Try(async () => methodResult.Fail(await errorDetail())));

    public static Task<Result> TryOnFailAsync(
        this Task<Result> @this,
        ErrorDetail errorDetail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(() => methodResult.Fail(errorDetail)));

    public static Task<Result> TryOnFailAsync(
        this Task<Result> @this,
        Func<ErrorDetail> errorDetail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(() => methodResult.Fail(errorDetail())));

    public static Task<Result> TryOnFailAsync(
        this Result @this,
        Func<Task<ErrorDetail>> errorDetail) =>
        @this.OnFailAsync(
            methodResult => TryExtensions.Try(async () => methodResult.Fail(await errorDetail())));

    public static Task<Result> TryOnFailAsync(
        this Task<Result> @this,
        Func<Task<ErrorDetail>> errorDetail) =>
        @this.OnFailAsync(
            methodResult => TryExtensions.Try(async () => methodResult.Fail(await errorDetail())));

    public static Task<Result<T>> TryOnFailAsync<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, Result<T>> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(() => fail(methodResult)));

    public static Task<Result<T>> TryOnFailAsync<T>(
        this Result<T> @this,
        Func<Result<T>, Task<Result<T>>> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(() => fail(methodResult)));

    public static Task<Result<T>> TryOnFailAsync<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, Task<Result<T>>> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(() => fail(methodResult)));

    public static Task<Result<T>> TryOnFailAsync<T>(
        this Task<Result<T>> @this,
        Func<Result<T>> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(fail));

    public static Task<Result<T>> TryOnFailAsync<T>(
        this Result<T> @this,
        Func<Task<Result<T>>> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(fail));

    public static Task<Result<T>> TryOnFailAsync<T>(
        this Task<Result<T>> @this,
        Func<Task<Result<T>>> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(fail));

    public static Task<Result> TryOnFailAsync(
        this Task<Result> @this,
        Func<Result, Result> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(() => fail(methodResult)));

    public static Task<Result> TryOnFailAsync(
        this Result @this,
        Func<Result, Task<Result>> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(() => fail(methodResult)));

    public static Task<Result> TryOnFailAsync(
        this Task<Result> @this,
        Func<Result, Task<Result>> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(() => fail(methodResult)));

    public static Task<Result> TryOnFailAsync(
        this Task<Result> @this,
        Func<Result> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(fail));

    public static Task<Result> TryOnFailAsync(
        this Result @this,
        Func<Task<Result>> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(fail));

    public static Task<Result> TryOnFailAsync(
        this Task<Result> @this,
        Func<Task<Result>> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(fail));

    public static Task<Result> TryOnFailAsync(
        this Task<Result> @this,
        Action fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(fail));

    public static Task<Result<T>> TryOnFailAsync<T>(
        this Task<Result<T>> @this,
        Action<Result<T>> fail) =>
        @this.OnFailAsync(methodResult => TryExtensions.Try(() => fail(methodResult)));

    #endregion

    #region OnFailOperateWhen

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<bool> predicate,
        Func<Result> operation
    ) => @this.OnFailOperateWhen(predicate(), operation);

    public static Result OnFailOperateWhen(
        this Result @this,
        bool predicate,
        Func<Result> operation
    ) => @this.OnFail(() => OperateExtensions.OperateWhen(predicate, operation));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<Result<T>> operation
    ) => @this.OnFailOperateWhen(predicate(), operation);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Result<T>> operation
    ) => @this.OnFail(() => @this.OperateWhen(predicate, operation));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<Result<T>, bool> predicate,
        Func<Result<T>, Result<T>> operation
    ) => @this.OnFailOperateWhen(predicate(@this), operation);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<Result<T>, Result<T>> operation
    ) => @this.OnFailOperateWhen(predicate(), operation);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Result<T>, Result<T>> operation
    ) => @this.OnFail(result => predicate ? operation(result) : @this);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<Result<T>, bool> predicate,
        Func<Result<T>> operation
    ) => @this.OnFailOperateWhen(predicate(@this), operation);

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result, bool> predicate,
        Func<Result> operation
    ) => @this.OnFailOperateWhen(predicate(@this), operation);

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<bool> predicate,
        Func<Result, Result> operation
    ) => @this.OnFailOperateWhen(predicate(), operation);

    public static Result OnFailOperateWhen(
        this Result @this,
        bool predicate,
        Func<Result, Result> operation
    ) => @this.OnFail(result => predicate ? operation(result) : @this);

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result, bool> predicate,
        Func<Result, Result> operation
    ) => @this.OnFailOperateWhen(predicate(@this), operation);

    public static Result OnFailOperateWhen(
        this Result @this,
        bool predicate,
        Result result
    ) => @this.OnFail(() => predicate ? result : @this);

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result> predicate,
        Result result
    ) => @this.OnFailOperateWhen(predicate().IsSuccess, result);

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result> predicate,
        Func<Result> result
    ) => @this.OnFailOperateWhen(predicate().IsSuccess, result);

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result, Result> predicate,
        Result result
    ) => @this.OnFailOperateWhen(predicate(@this).IsSuccess, result);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Result<T> result
    ) => @this.OnFail(() => predicate ? result : @this);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        Result<T> result
    ) => @this.OnFailOperateWhen(predicate().IsSuccess, result);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<Result<T>, bool> predicate,
        Result<T> result
    ) => @this.OnFailOperateWhen(predicate(@this), result);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<Result<T>, Result> predicate,
        Result<T> result
    ) => @this.OnFailOperateWhen(predicate(@this).IsSuccess, result);

    #endregion

    #region OnFailOperateWhenAsync

    public static Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Task<Result>> operation) =>
        @this.OnFailOperateWhenAsync(predicate(), operation);

    public static async Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Task<Result>> operation) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        if (predicate)
            return await operation();
        return methodResult;
    }

    public static Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Result> operation) =>
        @this.OnFailOperateWhenAsync(predicate(), operation);

    public static Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Result result) =>
        @this.OnFailOperateWhenAsync(predicate(), result);

    public static async Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Result> operation) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate ? operation() : methodResult;
    }

    public static async Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Result result) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate ? result : methodResult;
    }

    public static Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnFailOperateWhenAsync(predicate(), operation);

    public static Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnFailAsync(() => @this.OperateWhen<Task<Result<T>>>(predicate, operation));

    public static Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicate,
        Func<Result<T>, Task<Result<T>>> operation
    ) => @this.OnFailAsync(result => predicate(result) ? operation(result) : @this);

    public static Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Result<T>, Task<Result<T>>> operation
    ) => @this.OnFailOperateWhenAsync(predicate(), operation);

    public static Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Result<T>, Task<Result<T>>> operation
    ) => @this.OnFailAsync(result => predicate ? operation(result) : @this);

    public static Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnFailAsync(result => predicate(result) ? operation() : @this);

    public static Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        Func<Result, bool> predicate,
        Func<Task<Result>> operation
    ) => @this.OnFailAsync(result => predicate(result) ? operation() : @this);

    public static Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Result, Task<Result>> operation
    ) => @this.OnFailOperateWhenAsync(predicate(), operation);

    public static Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Result, Task<Result>> operation
    ) => @this.OnFailAsync(result => predicate ? operation(result) : @this);

    public static Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        Func<Result, bool> predicate,
        Func<Result, Task<Result>> operation
    ) => @this.OnFailAsync(result => predicate(result) ? operation(result) : @this);

    public static Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Result<T>> operation
    ) => @this.OnFailOperateWhenAsync(predicate(), operation);

    public static Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Result<T>> operation
    ) => @this.OnFailAsync(methodResult => methodResult.OperateWhen(predicate, operation));

    public static async Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicate,
        Func<Result<T>, Result<T>> operation) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? operation(methodResult) : methodResult;
    }

    public static Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Result<T>, Result<T>> operation) =>
        @this.OnFailOperateWhenAsync(predicate(), operation);

    public static async Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Result<T>, Result<T>> operation) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate ? operation(methodResult) : methodResult;
    }

    public static async Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicate,
        Func<Result<T>> operation) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? operation() : methodResult;
    }

    public static async Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        Func<Result, bool> predicate,
        Func<Result> operation) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? operation() : methodResult;
    }

    public static async Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        Func<Result, bool> predicate,
        Result result) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? result : methodResult;
    }

    public static Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Result, Result> operation) =>
        @this.OnFailOperateWhenAsync(predicate(), operation);

    public static async Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Result, Result> operation) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate ? operation(methodResult) : methodResult;
    }

    public static async Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        Func<Result, bool> predicate,
        Func<Result, Result> operation) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? operation(methodResult) : methodResult;
    }

    public static async Task<Result> OnFailOperateWhenAsync(
        this Task<Result> @this,
        Func<Result, Result> predicate,
        Result result) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult).IsSuccess ? result : methodResult;
    }

    public static async Task<Result<T>> OnFailOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, Result> predicate,
        Result<T> result) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult).IsSuccess ? result : methodResult;
    }

    #endregion

    #region OnFailAsync

    public static async Task<Result<TSource>> OnFailAsync<TSource>(
        this Task<Result<TSource>> @this,
        object moreDetail) {
        var t = await @this;
        if (!t.IsSuccess)
            t.Detail.AddDetail(moreDetail);
        return t;
    }

    public static async Task<Result> OnFailAsync(
        this Task<Result> @this,
        object moreDetail) {
        var t = await @this;
        if (!t.IsSuccess)
            t.Detail.AddDetail(moreDetail);
        return t;
    }

    public static async Task<Result<TSource>> OnFailAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task<Result<TSource>>> onFailTask) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            return await onFailTask();

        return methodResult;
    }

    public static async Task<Result<TSource>> OnFailAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>, Result<TSource>> onFailTask) {
        var methodResult = await @this;
        return !methodResult.IsSuccess ? onFailTask(methodResult) : methodResult;
    }

    public static async Task<Result<TSource>> OnFailAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>> onFailTask
    ) {
        var methodResult = await @this;
        return !methodResult.IsSuccess ? onFailTask() : methodResult;
    }

    public static async Task<Result> OnFailAsync(
        this Task<Result> @this,
        Func<Task<Result>> onFailTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? methodResult : await onFailTask();
    }

    public static async Task<Result> OnFailAsync(
        this Task<Result> @this,
        Func<Result, Task<Result>> onFailTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? methodResult : await onFailTask(methodResult);
    }

    public static async Task<Result> OnFailAsync(
        this Task<Result> @this,
        Func<Result, Result> onFailTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? methodResult : onFailTask(methodResult);
    }

    public static async Task<Result> OnFailAsync(
        this Task<Result> @this,
        Func<Result> onFailTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? methodResult : onFailTask();
    }

    public static async Task<Result> OnFailAsync(
        this Task<Result> @this,
        Action onFailTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            onFailTask();

        return methodResult;
    }

    public static async Task<Result<T>> OnFailAsync<T>(
        this Task<Result<T>> @this,
        Action onFailTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            onFailTask();

        return methodResult;
    }

    public static async Task<Result<T>> OnFailAsync<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, Task<Result<T>>> onFailTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            return await onFailTask(methodResult);

        return methodResult;
    }

    public static async Task<Result<T>> OnFailAsync<T>(
        this Task<Result<T>> @this,
        ErrorDetail errorDetail) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? methodResult : methodResult.Fail(errorDetail);
    }

    public static async Task<Result<T>> OnFailAsync<T>(
        this Result<T> @this,
        Func<Task<ErrorDetail>> errorDetail) =>
        @this.IsSuccess ? @this : @this.Fail(await errorDetail());

    public static async Task<Result> OnFailAsync(
        this Task<Result> @this,
        ErrorDetail errorDetail) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? methodResult : methodResult.Fail(errorDetail);
    }

    public static async Task<Result> OnFailAsync(
        this Task<Result> @this,
        Func<ErrorDetail> errorDetail) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? methodResult : methodResult.Fail(errorDetail());
    }

    public static async Task<Result> OnFailAsync(
        this Result @this,
        Func<Task<ErrorDetail>> errorDetail) =>
        @this.IsSuccess ? @this : @this.Fail(await errorDetail());

    public static async Task<Result<T>> OnFailAsync<T>(
        this Result<T> @this,
        Func<Result<T>, Task<Result<T>>> fail) =>
        @this.IsSuccess ? @this : await fail(@this);

    public static async Task<Result<T>> OnFailAsync<T>(
        this Result<T> @this,
        Func<Task<Result<T>>> fail) =>
        @this.IsSuccess ? @this : await fail();

    public static async Task<Result> OnFailAsync(
        this Result @this,
        Func<Result, Task<Result>> fail) =>
        @this.IsSuccess ? @this : await fail(@this);

    public static async Task<Result> OnFailAsync(
        this Result @this,
        Func<Task<Result>> fail) =>
        @this.IsSuccess ? @this : await fail();

    public static async Task<Result> OnFailAsync(
        this Task<Result> @this,
        Action<Result> fail) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            fail(methodResult);
        return methodResult;
    }

    public static async Task<Result<T>> OnFailAsync<T>(
        this Task<Result<T>> @this,
        Action<Result<T>> fail) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            fail(methodResult);
        return methodResult;
    }

    #endregion

    #region TeeOnFailAsync

    public static async Task<Result<TSource>> TeeOnFailAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<Result<TResult>>> onFailTask) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            await onFailTask();

        return methodResult;
    }

    public static async Task<Result<TSource>> TeeOnFailAsync<TSource>(
        this Task<Result<TSource>> @this, Action onFailTask) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            onFailTask();

        return methodResult;
    }

    public static async Task<Result<TSource>> TeeOnFailAsync<TSource>(
        this Task<Result<TSource>> @this, Action<Result<TSource>> onFailTask) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            onFailTask(methodResult);

        return methodResult;
    }

    public static async Task<Result<TSource>> TeeOnFailAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task<Result>> onFailTask) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            await onFailTask();

        return methodResult;
    }

    public static async Task<Result<TSource>> TeeOnFailAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>, Task<Result<TResult>>> onFailTask) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            await onFailTask(methodResult);

        return methodResult;
    }

    public static async Task<Result<TSource>> TeeOnFailAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>, Result<TResult>> onFailTask) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            onFailTask(methodResult);

        return methodResult;
    }

    public static async Task<Result<TSource>> TeeOnFailAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TResult>> onFailTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            onFailTask();

        return methodResult;
    }

    public static async Task<Result<TSource>> TeeOnFailAsync<TSource, TResult>(
        this Task<Result<TSource>> @this, Action onFailTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            onFailTask();

        return methodResult;
    }

    public static async Task<Result<TSource>> TeeOnFailAsync<TSource, TResult>(
        this Task<Result<TSource>> @this, Action<Result<TSource>> onFailTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            onFailTask(methodResult);

        return methodResult;
    }

    public static async Task<Result<TSource>> TeeOnFailAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result> onFailTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            onFailTask();

        return methodResult;
    }

    public static async Task<Result<T>> TeeOnFailAsync<T>(
        this Task<Result<T>> @this,
        Func<Task> onFailTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            await onFailTask();

        return methodResult;
    }

    public static async Task<Result<T>> TeeOnFailAsync<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, Task> onFailTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            await onFailTask(methodResult);

        return methodResult;
    }

    #endregion

    #region TeeOnFail

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> @this, Action onFail) {
        var methodResult = @this;
        if (!methodResult.IsSuccess)
            onFail();

        return methodResult;
    }

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> @this, Action<Result<TSource>> onFail) {
        var methodResult = @this;
        if (!methodResult.IsSuccess)
            onFail(methodResult);

        return methodResult;
    }

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> @this,
        Func<Task<Result>> onFail) {
        var methodResult = @this;
        if (!methodResult.IsSuccess)
            onFail();

        return methodResult;
    }

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TSource>, Task<Result<TResult>>> onFail) {
        var methodResult = @this;
        if (!methodResult.IsSuccess)
            onFail(methodResult);

        return methodResult;
    }

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TSource>, Result<TResult>> onFail) {
        var methodResult = @this;
        if (!methodResult.IsSuccess)
            onFail(methodResult);

        return methodResult;
    }

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> onFail
    ) {
        var methodResult = @this;
        if (!methodResult.IsSuccess)
            onFail();

        return methodResult;
    }

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> @this, Action onFail
    ) {
        var methodResult = @this;
        if (!methodResult.IsSuccess)
            onFail();

        return methodResult;
    }

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> @this, Action<Result<TSource>> onFail
    ) {
        var methodResult = @this;
        if (!methodResult.IsSuccess)
            onFail(methodResult);

        return methodResult;
    }

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> @this,
        Func<Result> onFail
    ) {
        var methodResult = @this;
        if (!methodResult.IsSuccess)
            onFail();

        return methodResult;
    }

    public static Result<T> TeeOnFail<T>(
        this Result<T> @this,
        Func<Task> onFail
    ) {
        var methodResult = @this;
        if (!methodResult.IsSuccess)
            onFail();

        return methodResult;
    }

    public static Result<T> TeeOnFail<T>(
        this Result<T> @this,
        Func<Result<T>, Task> onFail
    ) {
        var methodResult = @this;
        if (!methodResult.IsSuccess)
            onFail(methodResult);

        return methodResult;
    }

    #endregion

    #region OnFailSuccessWhen

    public static Result OnFailSuccessWhen(
        this Result @this, bool predicate) =>
        @this.OnFailOperateWhen(predicate, Result.Ok);

    public static Result OnFailSuccessWhen(
        this Result @this, Func<bool> predicate) =>
        @this.OnFailSuccessWhen(predicate());

    public static Result OnFailSuccessWhen(
        this Result @this, Result predicate) =>
        @this.OnFailOperateWhen(predicate.IsSuccess, Result.Ok);

    public static Result OnFailSuccessWhen(
        this Result @this, Func<Result, bool> predicate) =>
        @this.OnFailSuccessWhen(predicate(@this));

    public static Result OnFailSuccessWhen(
        this Result @this, Func<Result> predicate) =>
        @this.OnFailSuccessWhen(predicate());

    public static Result OnFailSuccessWhen(
        this Result @this, Func<Result, Result> predicate) =>
        @this.OnFailSuccessWhen(predicate(@this));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, bool predicate, T result) =>
        @this.OnFailOperateWhen(predicate, () => Result<T>.Ok(result));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, bool predicate, Func<T> result) =>
        @this.OnFailOperateWhen(predicate, () => Result<T>.Ok(result()));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Result predicate, T result) =>
        @this.OnFailOperateWhen(predicate.IsSuccess, () => Result<T>.Ok(result));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Result predicate, Func<T> result) =>
        @this.OnFailOperateWhen(predicate.IsSuccess, () => Result<T>.Ok(result()));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<bool> predicate, T result) =>
        @this.OnFailSuccessWhen(predicate(), result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<Result<T>, bool> predicate, T result) =>
        @this.OnFailSuccessWhen(predicate(@this), result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<bool> predicate, Func<T> result) =>
        @this.OnFailSuccessWhen(predicate(), result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<Result<T>, bool> predicate, Func<T> result) =>
        @this.OnFailSuccessWhen(predicate(@this), result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<Result> predicate, T result) =>
        @this.OnFailSuccessWhen(predicate().IsSuccess, result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<Result<T>, Result> predicate, T result) =>
        @this.OnFailSuccessWhen(predicate(@this).IsSuccess, result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<Result> predicate, Func<T> result) =>
        @this.OnFailSuccessWhen(predicate().IsSuccess, result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<Result<T>, Result> predicate, Func<T> result) =>
        @this.OnFailSuccessWhen(predicate(@this).IsSuccess, result);

    #endregion

    #region OnFailSuccessWhenAsync

    public static Task<Result> OnFailSuccessWhenAsync(
        this Task<Result> @this, bool predicate) =>
        @this.OnFailOperateWhenAsync(predicate, Result.Ok);

    public static Task<Result> OnFailSuccessWhenAsync(
        this Task<Result> @this, Result predicate) =>
        @this.OnFailOperateWhenAsync(predicate.IsSuccess, Result.Ok);

    public static Task<Result> OnFailSuccessWhenAsync(
        this Task<Result> @this, Func<bool> predicate) =>
        @this.OnFailSuccessWhenAsync(predicate());

    public static Task<Result> OnFailSuccessWhenAsync(
        this Task<Result> @this, Func<Result, bool> predicate) =>
        @this.OnFailOperateWhenAsync(predicate, Result.Ok);

    public static Task<Result> OnFailSuccessWhenAsync(
        this Task<Result> @this, Func<Result> predicate) =>
        @this.OnFailSuccessWhenAsync(predicate().IsSuccess);

    public static Task<Result> OnFailSuccessWhenAsync(
        this Task<Result> @this, Func<Result, Result> predicate) =>
        @this.OnFailOperateWhenAsync(predicate, Result.Ok());

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, bool predicate, T result) =>
        @this.OnFailOperateWhenAsync(predicate, () => Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, bool predicate, Func<T> result) =>
        @this.OnFailOperateWhenAsync(predicate, () => Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, bool predicate, Func<Task<T>> result) =>
        @this.OnFailOperateWhenAsync(predicate,
            async () => Result<T>.Ok(await result()));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Result predicate, T result) =>
        @this.OnFailOperateWhenAsync(predicate.IsSuccess, () => Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Result predicate, Func<T> result) =>
        @this.OnFailOperateWhenAsync(predicate.IsSuccess, () => Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Result predicate, Func<Task<T>> result) =>
        @this.OnFailOperateWhenAsync(predicate.IsSuccess,
            async () => Result<T>.Ok(await result()));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Func<bool> predicate, T result) =>
        @this.OnFailOperateWhenAsync(predicate, () => Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Func<Result<T>, bool> predicate, T result) =>
        @this.OnFailOperateWhenAsync(predicate, () => Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Func<bool> predicate, Func<T> result) =>
        @this.OnFailOperateWhenAsync(predicate, () => Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Func<Result<T>, bool> predicate, Func<T> result) =>
        @this.OnFailOperateWhenAsync(predicate, () => Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Func<bool> predicate, Func<Task<T>> result) =>
        @this.OnFailOperateWhenAsync(predicate,
            async () => Result<T>.Ok(await result()));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Func<Result<T>, bool> predicate, Func<Task<T>> result) =>
        @this.OnFailOperateWhenAsync(predicate,
            async () => Result<T>.Ok(await result()));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Func<Result> predicate, T result) =>
        @this.OnFailOperateWhenAsync(predicate().IsSuccess, () => Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Func<Result<T>, Result> predicate, T result) =>
        @this.OnFailOperateWhenAsync(predicate, Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Func<Result> predicate, Func<T> result) =>
        @this.OnFailOperateWhenAsync(predicate().IsSuccess, () => Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Func<Result<T>, Result> predicate, Func<T> result) =>
        @this.OnFailOperateWhenAsync(predicate, Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhenAsync<T>(
        this Task<Result<T>> @this, Func<Result> predicate, Func<Task<T>> result) =>
        @this.OnFailOperateWhenAsync(predicate().IsSuccess,
            async () => Result<T>.Ok(await result()));

    #endregion
}