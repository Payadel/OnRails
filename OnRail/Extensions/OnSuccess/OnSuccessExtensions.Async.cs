using OnRail.Extensions.Map;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(this Result<TSource> @this,
        Task<TResult> obj, int numOfTry = 1) => @this.IsSuccess
        ? await TryExtensions.Try(obj, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(this Result<TSource> @this,
        Task<Result<TResult>> obj, int numOfTry = 1) => @this.IsSuccess
        ? await TryExtensions.Try(obj, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(this Task<Result<TSource>> @this,
        Task<TResult> obj, int numOfTry = 1) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(obj, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(this Task<Result<TSource>> @this,
        Task<Result<TResult>> obj, int numOfTry = 1) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(obj, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<Result<TResult>>> onSuccessTask,
        int numOfTry = 1) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await t.Value!.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    //TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Action onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        if (t.IsSuccess)
            TryExtensions.Try(onSuccessTask, numOfTry);
        return t.Map();
    }

    //TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        if (t.IsSuccess)
            t.Value!.Try(onSuccessTask, numOfTry);
        return t.Map();
    }

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<TResult>> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await t.Value!.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<Result<TResult>>> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<TResult>> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    //TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<Result>> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await t.Value!.Try(onSuccessTask, numOfTry)
            : Result.Fail(t.Detail);
    }

    //TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await t.Value!.Try(onSuccessTask, numOfTry)
            : Result.Fail(t.Detail);
    }

    //TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task<Result>> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(onSuccessTask, numOfTry)
            : Result.Fail(t.Detail);
    }

    //TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(onSuccessTask, numOfTry)
            : Result.Fail(t.Detail);
    }

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<Task<Result<TResult>>> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    //TODO: Test
    public static async Task<Result> OnSuccess(
        this Task<Result> @this,
        Action onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        if (t.IsSuccess)
            TryExtensions.Try(onSuccessTask, numOfTry);
        return t;
    }

//TODO: Test
    public static async Task<Result<T>> OnSuccess<T>(
        this Task<Result<T>> @this,
        T obj,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess ? Result<T>.Ok(obj) : t;
    }

//TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<Task<TResult>> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

//TODO: Test
    public static async Task<Result> OnSuccess(
        this Task<Result> @this,
        Func<Task<Result>> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(onSuccessTask, numOfTry)
            : Result.Fail(t.Detail);
    }

//TODO: Test
    public static async Task<Result> OnSuccess(
        this Task<Result> @this,
        Func<Task> onSuccessTask,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(onSuccessTask, numOfTry)
            : Result.Fail(t.Detail);
    }

//TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Task<Result<TResult>>> onSuccessTask,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await @this.Value!.Try(onSuccessTask, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

//TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Task<TResult>> onSuccessTask,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await @this.Value!.Try(onSuccessTask, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

//TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<Task<Result<TResult>>> onSuccessTask,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(onSuccessTask, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

//TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<Task<TResult>> onSuccessTask,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(onSuccessTask, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

//TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<TSource, Task<Result>> onSuccessTask,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await @this.Value!.Try(onSuccessTask, numOfTry)
        : Result.Fail(@this.Detail);

//TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<TSource, Task> onSuccessTask,
        int numOfTry = 1) => @this.IsSuccess
        ? await @this.Value!.Try(onSuccessTask, numOfTry)
        : Result.Fail(@this.Detail);

//TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<Task<Result>> onSuccessTask,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(onSuccessTask, numOfTry)
        : Result.Fail(@this.Detail);

//TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<Task> onSuccessTask,
        int numOfTry = 1) => @this.IsSuccess
        ? await TryExtensions.Try(onSuccessTask, numOfTry)
        : Result.Fail(@this.Detail);

//TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Result @this,
        Func<Task<Result<TResult>>> onSuccessTask,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(onSuccessTask, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

//TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Result @this,
        Func<Task<TResult>> onSuccessTask,
        int numOfTry = 1) => @this.IsSuccess
        ? await TryExtensions.Try(onSuccessTask, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

//TODO: Test
    public static async Task<Result> OnSuccess(
        this Result @this,
        Func<Task<Result>> onSuccessTask,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(onSuccessTask, numOfTry)
        : Result.Fail(@this.Detail);

//TODO: Test
    public static async Task<Result> OnSuccess(
        this Result @this,
        Func<Task> onSuccessTask,
        int numOfTry = 1) => @this.IsSuccess
        ? await TryExtensions.Try(onSuccessTask, numOfTry)
        : Result.Fail(@this.Detail);

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result<TResult>> onSuccessTask,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? result.Value!.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> onSuccessTask,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? result.Value!.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

//TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TResult>> onSuccessTask,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> onSuccessTask,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

    //TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result> onSuccessTask,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? result.Value!.Try(onSuccessTask, numOfTry)
            : Result.Fail(result.Detail);
    }

    //TODO: Test
    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result> onSuccessTask,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(onSuccessTask, numOfTry)
            : Result.Fail(result.Detail);
    }

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<Result<TResult>> onSuccessTask,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

    //TODO: Test
    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<TResult> onSuccessTask,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(onSuccessTask, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

    //TODO: Test
    public static async Task<Result> OnSuccess(
        this Task<Result> @this,
        Func<Result> onSuccessTask,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(onSuccessTask, numOfTry)
            : Result.Fail(result.Detail);
    }
}