using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
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
}