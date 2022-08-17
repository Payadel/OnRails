using OnRail.Extensions.Map;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test

public static partial class OnSuccessExtensions {
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Task<TResult> obj,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(obj, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Task<Result<TResult>> obj,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(obj, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Task<TResult> obj,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(obj, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Task<Result<TResult>> obj,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(obj, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await t.Value!.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Action action,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? TryExtensions.Try(action, numOfTry)
            : t.Map();
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Action<TSource> action,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? t.Value!.Try(action, numOfTry)
            : t.Map();
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await t.Value!.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task<Result>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await t.Value!.Try(function, numOfTry)
            : Result.Fail(t.Detail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Task> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await t.Value!.Try(function, numOfTry)
            : Result.Fail(t.Detail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(function, numOfTry)
            : Result.Fail(t.Detail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(function, numOfTry)
            : Result.Fail(t.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    public static async Task<Result> OnSuccess(
        this Task<Result> @this,
        Action action,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? TryExtensions.Try(action, numOfTry)
            : t;
    }

    public static async Task<Result<T>> OnSuccess<T>(
        this Task<Result<T>> @this,
        T obj,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? Result<T>.Ok(obj)
            : t;
    }

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail);
    }

    public static async Task<Result> OnSuccess(
        this Task<Result> @this,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(function, numOfTry)
            : Result.Fail(t.Detail);
    }

    public static async Task<Result> OnSuccess(
        this Task<Result> @this,
        Func<Task> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(@this, numOfTry);
        return t.IsSuccess
            ? await TryExtensions.Try(function, numOfTry)
            : Result.Fail(t.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await @this.Value!.Try(function, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await @this.Value!.Try(function, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<TSource, Task<Result>> function,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await @this.Value!.Try(function, numOfTry)
        : Result.Fail(@this.Detail);

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<TSource, Task> function,
        int numOfTry = 1) => @this.IsSuccess
        ? await @this.Value!.Try(function, numOfTry)
        : Result.Fail(@this.Detail);

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(function, numOfTry)
        : Result.Fail(@this.Detail);

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<Task> function,
        int numOfTry = 1) => @this.IsSuccess
        ? await TryExtensions.Try(function, numOfTry)
        : Result.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Result @this,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Result @this,
        Func<Task<TResult>> function,
        int numOfTry = 1) => @this.IsSuccess
        ? await TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(@this.Detail);

    public static async Task<Result> OnSuccess(
        this Result @this,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? await TryExtensions.Try(function, numOfTry)
        : Result.Fail(@this.Detail);

    public static async Task<Result> OnSuccess(
        this Result @this,
        Func<Task> function,
        int numOfTry = 1) => @this.IsSuccess
        ? await TryExtensions.Try(function, numOfTry)
        : Result.Fail(@this.Detail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? result.Value!.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? result.Value!.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TResult>> function,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> function,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<TSource, Result> function,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? result.Value!.Try(function, numOfTry)
            : Result.Fail(result.Detail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result> function,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result.Fail(result.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<Result<TResult>> function,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> @this,
        Func<TResult> function,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail);
    }

    public static async Task<Result> OnSuccess(
        this Task<Result> @this,
        Func<Result> function,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result.Fail(result.Detail);
    }
}