using OnRail.ResultDetails;

namespace OnRail.Extensions;

public static class OnSuccessExtensions {
    #region OnSuccess

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        TResult successResult) =>
        @this.IsSuccess ? Result<TResult>.Ok(successResult) : Result<TResult>.Fail(@this.Detail);

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

    #region OnSuccessAsync

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<Result<TResult>>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess
            ? await onSuccessTask(methodResult.Value)
            : Result<TResult>.Fail(methodResult.Detail);
    }

    public static Task<Result<TSource>> OnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Action onSuccessTask
    ) => @this.OnSuccessAsync(() => {
        onSuccessTask();
        return @this;
    });

    public static Task<Result<TSource>> OnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> onSuccessTask
    ) => @this.OnSuccessAsync(methodResult => {
        onSuccessTask(methodResult);
        return @this;
    });

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<TResult>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess
            ? Result<TResult>.Ok(await onSuccessTask(methodResult.Value))
            : Result<TResult>.Fail(methodResult.Detail);
    }

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<Result<TResult>>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? await onSuccessTask() : Result<TResult>.Fail(methodResult.Detail);
    }

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<TResult>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess
            ? Result<TResult>.Ok(await onSuccessTask())
            : Result<TResult>.Fail(methodResult.Detail);
    }

    public static async Task<Result> OnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<Result>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess
            ? await onSuccessTask(methodResult.Value)
            : Result.Fail(methodResult.Detail);
    }

    public static async Task<Result> OnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task> onSuccessTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            return Result.Fail(methodResult.Detail);

        await onSuccessTask(methodResult.Value);
        return Result.Ok();
    }

    public static async Task<Result> OnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task<Result>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? await onSuccessTask() : Result.Fail(methodResult.Detail);
    }

    public static async Task<Result> OnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task> onSuccessTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            return Result.Fail(methodResult.Detail);

        await onSuccessTask();
        return Result.Ok();
    }

    public static async Task<Result<TResult>> OnSuccessAsync<TResult>(
        this Task<Result> @this,
        Func<Task<Result<TResult>>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? await onSuccessTask() : Result<TResult>.Fail(methodResult.Detail);
    }

    public static Task<Result> OnSuccessAsync(
        this Task<Result> @this,
        Action onSuccessTask
    ) => @this.OnSuccessAsync(() => {
        onSuccessTask();
        return @this;
    });

    public static async Task<Result<TResult>> OnSuccessAsync<TResult>(
        this Task<Result> @this,
        Func<Task<TResult>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess
            ? Result<TResult>.Ok(await onSuccessTask())
            : Result<TResult>.Fail(methodResult.Detail);
    }

    public static async Task<Result> OnSuccessAsync(
        this Task<Result> @this,
        Func<Task<Result>> onSuccessTask
    ) {
        var methodResult = await @this;
        return methodResult.IsSuccess ? await onSuccessTask() : Result.Fail(methodResult.Detail);
    }

    public static async Task<Result> OnSuccessAsync(
        this Task<Result> @this,
        Func<Task> onSuccessTask
    ) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            return Result.Fail(methodResult.Detail);

        await onSuccessTask();
        return Result.Ok();
    }

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Task<Result<TResult>>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask(@this.Value) : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Task<TResult>> onSuccessTask
    ) => @this.IsSuccess
        ? Result<TResult>.Ok(await onSuccessTask(@this.Value))
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Result<TSource> @this,
        Func<Task<Result<TResult>>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask() : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Result<TSource> @this,
        Func<Task<TResult>> onSuccessTask
    ) => @this.IsSuccess
        ? Result<TResult>.Ok(await onSuccessTask())
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result> OnSuccessAsync<TSource>(
        this Result<TSource> @this,
        Func<TSource, Task<Result>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask(@this.Value) : Result.Fail(@this.Detail);

    public static async Task<Result> OnSuccessAsync<TSource>(
        this Result<TSource> @this,
        Func<TSource, Task> onSuccessTask) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        await onSuccessTask(@this.Value);
        return Result.Ok();
    }

    public static async Task<Result> OnSuccessAsync<TSource>(
        this Result<TSource> @this,
        Func<Task<Result>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask() : Result.Fail(@this.Detail);

    public static async Task<Result> OnSuccessAsync<TSource>(
        this Result<TSource> @this,
        Func<Task> onSuccessTask) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        await onSuccessTask();
        return Result.Ok();
    }

    public static async Task<Result<TResult>> OnSuccessAsync<TResult>(
        this Result @this,
        Func<Task<Result<TResult>>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask() : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccessAsync<TResult>(
        this Result @this,
        Func<Task<TResult>> onSuccessTask) =>
        @this.IsSuccess
            ? Result<TResult>.Ok(await onSuccessTask())
            : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result> OnSuccessAsync(
        this Result @this,
        Func<Task<Result>> onSuccessTask
    ) => @this.IsSuccess ? await onSuccessTask() : Result.Fail(@this.Detail);

    public static async Task<Result> OnSuccessAsync(
        this Result @this,
        Func<Task> onSuccessTask) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        await onSuccessTask();
        return Result.Ok();
    }

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result<TResult>> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TResult>> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result<TResult>> OnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result> OnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result> OnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result<TResult>> OnSuccessAsync<TResult>(
        this Task<Result> @this,
        Func<Result<TResult>> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result<TResult>> OnSuccessAsync<TResult>(
        this Task<Result> @this,
        Func<TResult> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    public static async Task<Result> OnSuccessAsync(
        this Task<Result> @this,
        Func<Result> onSuccessTask
    ) => (await @this)
        .OnSuccess(onSuccessTask);

    #endregion

    #region TryOnSuccess

    public static Result<TResult> TryOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> success) =>
        @this.OnSuccess(source => source.TryMap(success));

    public static Result<TResult> TryOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> success) =>
        @this.OnSuccess(() => TryExtensions.Try(success));

    public static Result<TResult> TryOnSuccess<TResult>(
        this Result @this,
        Func<TResult> success) =>
        @this.OnSuccess(() => TryExtensions.Try(success));

    public static Result<TResult> TryOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> success) =>
        @this.OnSuccess(source => source.TryMap(success));

    public static Result<TResult> TryOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> success) =>
        @this.OnSuccess(() => TryExtensions.Try(success));

    public static Result<TResult> TryOnSuccess<TResult>(
        this Result @this,
        Func<Result<TResult>> success) =>
        @this.OnSuccess(() => TryExtensions.Try(success));

    public static Result TryOnSuccess<TSource>(
        this Result<TSource> @this,
        Action<TSource> success) =>
        @this.OnSuccess(source => source.Try(success));

    public static Result TryOnSuccess<TSource>(
        this Result<TSource> @this,
        Action success) =>
        @this.OnSuccess(() => TryExtensions.Try(success));

    public static Result TryOnSuccess(
        this Result @this,
        Action success) =>
        @this.OnSuccess(() => TryExtensions.Try(success));

    #endregion

    #region TryOnSuccessAsync

    public static Task<Result<TResult>> TryOnSuccessAsync<TResult>(
        this Task<Result> @this,
        Func<Task<TResult>> success,
        int numOfTry) =>
        @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result<TResult>> TryOnSuccessAsync<TResult>(
        this Task<Result> @this,
        Func<Task<Result<TResult>>> success,
        int numOfTry) =>
        @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result<TResult>> TryOnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<TResult>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(source => source.TryMapAsync(success, numOfTry));

    public static Task<Result<TResult>> TryOnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<Result<TResult>>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(source => source.TryMapAsync(success, numOfTry));

    public static Task<Result<TResult>> TryOnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<TResult>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result<TResult>> TryOnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<Result<TResult>>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task> success,
        int numOfTry
    ) => @this.OnSuccessAsync(source => source.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<Result>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(source => source.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task<Result>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync(
        this Task<Result> @this,
        Func<Task> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync(
        this Task<Result> @this,
        Func<Task<Result>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result<TResult>> TryOnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> success
    ) => @this.OnSuccessAsync(source => source.TryMap(success));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task> success
    ) => @this.OnSuccessAsync(source => source.TryAsync(success));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<Result>> success
    ) => @this.OnSuccessAsync(source => source.TryAsync(success));

    public static Task<Result<TResult>> TryOnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> success
    ) => @this.OnSuccessAsync(() => TryExtensions.Try(success));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> success
    ) => @this.OnSuccessAsync(source => source.Try(success));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Task<Result<TSource>> @this,
        Action success
    ) => @this.OnSuccessAsync(() => TryExtensions.Try(success));

    public static Task<Result<TResult>> TryOnSuccessAsync<TResult>(
        this Task<Result> @this,
        Func<TResult> success
    ) => @this.OnSuccessAsync(() => TryExtensions.Try(success));

    public static Task<Result> TryOnSuccessAsync(
        this Task<Result> @this,
        Action success
    ) => @this.OnSuccessAsync(() => TryExtensions.Try(success));

    public static Task<Result<TResult>> TryOnSuccessAsync<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Task<TResult>> onSuccessTask) =>
        @this.OnSuccessAsync(source => source.TryMapAsync(onSuccessTask));

    public static Task<Result<TResult>> TryOnSuccessAsync<TResult>(
        this Result @this,
        Func<Task<TResult>> success,
        int numOfTry) =>
        @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result<TResult>> TryOnSuccessAsync<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Task<TResult>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(source => source.TryMapAsync(success, numOfTry));

    public static Task<Result<TResult>> TryOnSuccessAsync<TSource, TResult>(
        this Result<TSource> @this,
        Func<Task<TResult>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Result<TSource> @this,
        Func<TSource, Task> success,
        int numOfTry
    ) => @this.OnSuccessAsync(source => source.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Result<TSource> @this,
        Func<Task> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync(
        this Result @this,
        Func<Task> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result<TResult>> TryOnSuccessAsync<TResult>(
        this Result @this,
        Func<Task<Result<TResult>>> success,
        int numOfTry) =>
        @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result<TResult>> TryOnSuccessAsync<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Task<Result<TResult>>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(source => source.TryMapAsync(success, numOfTry));

    public static Task<Result<TResult>> TryOnSuccessAsync<TSource, TResult>(
        this Result<TSource> @this,
        Func<Task<Result<TResult>>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Result<TSource> @this,
        Func<TSource, Task<Result>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(source => source.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync<TSource>(
        this Result<TSource> @this,
        Func<Task<Result>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    public static Task<Result> TryOnSuccessAsync(
        this Result @this,
        Func<Task<Result>> success,
        int numOfTry
    ) => @this.OnSuccessAsync(() => TryExtensions.TryAsync(success, numOfTry));

    #endregion

    #region OnSuccessFailWhen

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

    #region OnSuccessFailWhenAsync

    public static Task<Result> OnSuccessFailWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccessAsync(() => predicate() ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result> OnSuccessFailWhenAsync(
        this Task<Result> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccessAsync(() => predicate ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate(source) ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate(source) ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate() ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate() ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result> OnSuccessFailWhenAsync(
        this Task<Result> @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccessAsync(() => predicate().IsSuccess ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result> OnSuccessFailWhenAsync(
        this Task<Result> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccessAsync(() => predicate.IsSuccess ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate(source).IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate(source).IsSuccess ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate().IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate().IsSuccess ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate.IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhenAsync<T>(
        this Task<Result<T>> @this,
        Result predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccessAsync(source =>
        predicate.IsSuccess ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    #endregion

    #region OnSuccessOperateWhen

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<bool> predicateFun,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateExtensions.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<Result<T>> operation
    ) => @this.OnSuccess(() => @this.OperateWhen(predicateFun, operation));

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
    ) => @this.OnSuccess(value => @this.OperateWhen(predicateFun, () => operation(value)));

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
    ) => @this.OnSuccess(() => OperateExtensions.OperateWhen(predicateFun, action));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        bool predicate,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateExtensions.OperateWhen(predicate, operation));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        bool predicate,
        Action action
    ) => @this.OnSuccess(() => OperateExtensions.OperateWhen(predicate, action));

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
    ) => @this.OnSuccess(() => OperateExtensions.OperateWhen(predicateFun, operation));

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
    ) => @this.OnSuccess(() => OperateExtensions.OperateWhen(predicateFun, action));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Result predicate,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateExtensions.OperateWhen(predicate, operation));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Result predicate,
        Action operation
    ) => @this.OnSuccess(() => OperateExtensions.OperateWhen(predicate.IsSuccess, operation));

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
    ) => @this.OnSuccessAsync(() => OperateExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccessAsync(() => OperateExtensions.OperateWhenAsync(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Action operation
    ) => @this.OnSuccessAsync(() => OperateExtensions.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Action<T> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Action operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Action<T> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, T> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, T> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate(source), operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Result> operation
    ) => @this.OnSuccessAsync(() => OperateExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Action operation
    ) => @this.OnSuccessAsync(() => OperateExtensions.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccessAsync(() => OperateExtensions.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Action operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Action<T> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, T> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhen(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        Func<bool> predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccessAsync(() => @this.OperateWhenAsync(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        Func<bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccessAsync(() => @this.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(() => @this.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(source => @this.OperateWhenAsync(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task> operation
    ) => @this.OnSuccessAsync(source => @this.OperateWhenAsync(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(source => @this.OperateWhenAsync(predicate, () => operation(source)));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(source => @this.OperateWhenAsync(predicate(source), () => operation(source)));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<Task<T>> operation
    ) => @this.OnSuccessAsync(source => @this.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Task<T>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<T, Task<T>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, Task<T>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate(source), operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        bool predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccessAsync(() => @this.OperateWhenAsync(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Result @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccessAsync(() => @this.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<T>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, Task<T>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        Func<bool> predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccessAsync(() => OperateExtensions.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate(source), operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate(source), operation));

    public static Task<Result> OnSuccessOperateWhenAsync(
        this Task<Result> @this,
        bool predicate,
        Func<Task<Result>> operation
    ) => @this.OnSuccessAsync(() => OperateExtensions.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    public static Task<Result<T>> OnSuccessOperateWhenAsync<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, Task<Result<T>>> operation
    ) => @this.OnSuccessAsync(source => source.OperateWhenAsync(predicate, operation));

    #endregion

    //TODO: OnSuccessTryOperateWhen
    //TODO: OnSuccessTryOperateWhenAsync
}