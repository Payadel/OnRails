using OnRail.Extensions.OperateWhen;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions;

public static class OnSuccessExtensions {
    #region OnSuccess

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        TResult successResult) =>
        @this.IsSuccess
            ? Result<TResult>.Ok(successResult)
            : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TResult>(
        this Result @this,
        TResult successResult) =>
        @this.IsSuccess ? Result<TResult>.Ok(successResult) : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> success) =>
        @this.IsSuccess ? success(@this.Value) : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> success) =>
        @this.IsSuccess ? success() : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TResult>(
        this Result @this,
        Func<Result<TResult>> success) =>
        @this.IsSuccess ? success() : Result<TResult>.Fail(@this.Detail);

    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<TSource, Result> success) =>
        @this.IsSuccess ? success(@this.Value) : Result.Fail(@this.Detail);

    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<Result> success) =>
        @this.IsSuccess ? success() : Result.Fail(@this.Detail);

    public static Result OnSuccess(
        this Result @this,
        Func<Result> success) =>
        @this.IsSuccess ? success() : Result.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> success) =>
        @this.IsSuccess
            ? Result<TResult>.Ok(success(@this.Value))
            : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> success) =>
        @this.IsSuccess ? Result<TResult>.Ok(success()) : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TResult>(
        this Result @this,
        Func<TResult> success) =>
        @this.IsSuccess ? Result<TResult>.Ok(success()) : Result<TResult>.Fail(@this.Detail);

    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Action<TSource> success) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        success(@this.Value);
        return Result.Ok();
    }

    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Action success) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        success();
        return Result.Ok();
    }

    public static Result OnSuccess(
        this Result @this,
        Action success) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        success();
        return Result.Ok();
    }

    #endregion

    #region Async OnSuccess

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(this Result<TSource> @this,
        Task<TResult> obj, int numOfTry = 1) => @this.IsSuccess
        ? await TryExtensions.Try(obj, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(this Result<TSource> @this,
        Task<Result<TResult>> obj, int numOfTry = 1) => @this.IsSuccess
        ? await TryExtensions.Try(obj, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    public static Task<Result<TResult>> OnSuccess<TSource, TResult>(this Task<Result<TSource>> @this,
        Task<TResult> obj, int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnSuccess(() => obj);

    public static Task<Result<TResult>> OnSuccess<TSource, TResult>(this Task<Result<TSource>> @this,
        Task<Result<TResult>> obj, int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnSuccess(() => obj);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<Result<TResult>>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess
            ? await onSuccessTask(methodResult.Value)
            : Result<TResult>.Fail(methodResult.Detail);
    }

    public static Task<Result<TSource>> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Action onSuccessTask
    ) => @this.OnSuccess(() => {
        onSuccessTask();
        return @this;
    });

    public static Task<Result<TSource>> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> onSuccessTask
    ) => @this.OnSuccess(methodResult => {
        onSuccessTask(methodResult);
        return @this;
    });

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<TResult>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess
            ? Result<TResult>.Ok(await onSuccessTask(methodResult.Value))
            : Result<TResult>.Fail(methodResult.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<Result<TResult>>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? await onSuccessTask() : Result<TResult>.Fail(methodResult.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<TResult>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess
            ? Result<TResult>.Ok(await onSuccessTask())
            : Result<TResult>.Fail(methodResult.Detail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<Result>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess
            ? await onSuccessTask(methodResult.Value)
            : Result.Fail(methodResult.Detail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task> onSuccessTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            return Result.Fail(methodResult.Detail);

        await onSuccessTask(methodResult.Value);
        return Result.Ok();
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task<Result>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? await onSuccessTask() : Result.Fail(methodResult.Detail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task> onSuccessTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            return Result.Fail(methodResult.Detail);

        await onSuccessTask();
        return Result.Ok();
    }

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<Task<Result<TResult>>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? await onSuccessTask() : Result<TResult>.Fail(methodResult.Detail);
    }

    public static Task<Result> OnSuccess(
        this Task<Result> @this,
        Action onSuccessTask
    ) => @this.OnSuccess(() => {
        onSuccessTask();
        return @this;
    });

    public static Task<Result<T>> OnSuccess<T>(
        this Task<Result<T>> @this,
        T obj,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnSuccess(() => obj);

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<Task<TResult>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess
            ? Result<TResult>.Ok(await onSuccessTask())
            : Result<TResult>.Fail(methodResult.Detail);
    }

    public static async Task<Result> OnSuccess(
        this Task<Result> @this,
        Func<Task<Result>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? await onSuccessTask() : Result.Fail(methodResult.Detail);
    }

    public static async Task<Result> OnSuccess(
        this Task<Result> @this,
        Func<Task> onSuccessTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            return Result.Fail(methodResult.Detail);

        await onSuccessTask();
        return Result.Ok();
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Task<Result<TResult>>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask(@this.Value) : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Task<TResult>> onSuccessTask
    ) => @this.IsSuccess
        ? Result<TResult>.Ok(await onSuccessTask(@this.Value))
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<Task<Result<TResult>>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask() : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<Task<TResult>> onSuccessTask
    ) => @this.IsSuccess
        ? Result<TResult>.Ok(await onSuccessTask())
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<TSource, Task<Result>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask(@this.Value) : Result.Fail(@this.Detail);

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<TSource, Task> onSuccessTask) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        await onSuccessTask(@this.Value);
        return Result.Ok();
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<Task<Result>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask() : Result.Fail(@this.Detail);

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<Task> onSuccessTask) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        await onSuccessTask();
        return Result.Ok();
    }

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Result @this,
        Func<Task<Result<TResult>>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask() : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Result @this,
        Func<Task<TResult>> onSuccessTask) =>
        @this.IsSuccess
            ? Result<TResult>.Ok(await onSuccessTask())
            : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result> OnSuccess(
        this Result @this,
        Func<Task<Result>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask() : Result.Fail(@this.Detail);

    public static async Task<Result> OnSuccess(
        this Result @this,
        Func<Task> onSuccessTask) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        await onSuccessTask();
        return Result.Ok();
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result<TResult>> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TResult>> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<Result<TResult>> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<TResult> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result> OnSuccess(
        this Task<Result> @this,
        Func<Result> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    #endregion

    #region FailWhen OnSuccess

    public static Result OnSuccessFailWhen(
        this Result @this,
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate() ? Result.Fail(errorDetail) : @this);

    public static Result OnSuccessFailWhen(
        this Result @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate ? Result.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source => predicate(source) ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source => predicate(source) ? Result<T>.Fail(errorDetail(source)) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate() ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source => predicate() ? Result<T>.Fail(errorDetail(source)) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source => predicate ? Result<T>.Fail(errorDetail(source)) : @this);

    public static Result OnSuccessFailWhen(
        this Result @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate().IsSuccess ? Result.Fail(errorDetail) : @this);

    public static Result OnSuccessFailWhen(
        this Result @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate.IsSuccess ? Result.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source => predicate(source).IsSuccess ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate(source).IsSuccess ? Result<T>.Fail(errorDetail(source)) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate().IsSuccess ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source => predicate().IsSuccess ? Result<T>.Fail(errorDetail(source)) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate.IsSuccess ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Result predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source => predicate.IsSuccess ? Result<T>.Fail(errorDetail(source)) : @this);

    #endregion

    #region FailWhenAsync OnSuccess

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate() ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate(source) ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate(source) ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate() ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate() ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate().IsSuccess ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate.IsSuccess ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate(source).IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate(source).IsSuccess ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate().IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate().IsSuccess ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate.IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Result predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate.IsSuccess ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    #endregion

    #region OnSuccessOperateWhen

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<bool> predicateFun,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<Result<T>> operation
    ) => @this.OnSuccess(t => t.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Action action
    ) => @this.OnSuccess(t => t.OperateWhen(predicateFun, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Action<T> action
    ) => @this.OnSuccess(t => t.OperateWhen(predicateFun, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(value => @this.OperateWhen(predicate(value), operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicateFun,
        Action action
    ) => @this.OnSuccess(t => t.OperateWhen(predicateFun, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicateFun,
        Action<T> action
    ) => @this.OnSuccess(t => t.OperateWhen(predicateFun, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => @this.OperateWhen(
        predicate(value), () => operation(value)));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<bool> predicateFun,
        Action action
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicateFun, action));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        bool predicate,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        bool predicate,
        Action action
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(() => @this.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Action action
    ) => @this.OnSuccess(t => t.OperateWhen(predicate, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Action<T> action
    ) => @this.OnSuccess(t => t.OperateWhen(predicate, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => @this.OperateWhen(predicate, () => operation(value)));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<Result> predicateFun,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFun,
        Func<Result<T>> operation
    ) => @this.OnSuccess(() => @this.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFun,
        Action action
    ) => @this.OnSuccess(t => t.OperateWhen(predicateFun(), action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFun,
        Action<T> action
    ) => @this.OnSuccess(t => t.OperateWhen(predicateFun(), action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Action operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Action<T> operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFun,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => @this.Value.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => @this.OperateWhen(
        predicate(value), () => operation(value)));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<Result> predicateFun,
        Action action
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicateFun, action));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Result predicate,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Result predicate,
        Action operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate.IsSuccess, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(t => t.OperateWhen(predicate.IsSuccess, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Action operation
    ) => @this.OnSuccess(t => t.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Action<T> operation
    ) => @this.OnSuccess(t => t.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => @this.OperateWhen(predicate, () => operation(value)));

    #endregion

    #region OnSuccessOperateWhenAsync

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Action operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Action<T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Action operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Action<T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Action operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Action operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Action<T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, T> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        Func<bool> predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        Func<bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(() => @this.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(source => @this.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => @this.OperateWhen(predicate, () => operation(source)));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => @this.OperateWhen(predicate(source), () => operation(source)));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<T, Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        bool predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, Task<T>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccess(source => source.OperateWhen(predicate, operation));

    #endregion
}