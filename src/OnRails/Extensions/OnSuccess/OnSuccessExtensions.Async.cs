using OnRails.Extensions.Map;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails.Extensions.OnSuccess;

//TODO: Test

public static partial class OnSuccessExtensions {
    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> source,
        Task<TResult> obj,
        int numOfTry = 1
    ) => source.Success
        ? await TryExtensions.Try(obj, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> source,
        Task<Result<TResult>> obj,
        int numOfTry = 1
    ) => source.Success
        ? await TryExtensions.Try(obj, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Task<TResult> obj,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await TryExtensions.Try(obj, numOfTry)
            : Result<TResult>.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Task<Result<TResult>> obj,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await TryExtensions.Try(obj, numOfTry)
            : Result<TResult>.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await t.Value!.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> source,
        Action action,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? TryExtensions.Try(action, numOfTry)
            : t.Map();
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> source,
        Action<TSource> action,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? t.Value!.Try(action, numOfTry)
            : t.Map();
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await t.Value!.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> source,
        Func<TSource, Task<Result>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await t.Value!.Try(function, numOfTry)
            : Result.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> source,
        Func<TSource, Task> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await t.Value!.Try(function, numOfTry)
            : Result.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await TryExtensions.Try(function, numOfTry)
            : Result.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> source,
        Func<Task> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await TryExtensions.Try(function, numOfTry)
            : Result.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> source,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result> OnSuccess(
        this Task<Result> source,
        Action action,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? TryExtensions.Try(action, numOfTry)
            : t;
    }

    public static async Task<Result<T>> OnSuccess<T>(
        this Task<Result<T>> source,
        T obj,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? Result<T>.Ok(obj)
            : t;
    }

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> source,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result> OnSuccess(
        this Task<Result> source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await TryExtensions.Try(function, numOfTry)
            : Result.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result> OnSuccess(
        this Task<Result> source,
        Func<Task> function,
        int numOfTry = 1
    ) {
        var t = await TryExtensions.Try(source, numOfTry);
        return t.Success
            ? await TryExtensions.Try(function, numOfTry)
            : Result.Fail(t.Detail as ErrorDetail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => source.Success
        ? await source.Value!.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => source.Success
        ? await source.Value!.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> source,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => source.Success
        ? await TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Result<TSource> source,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) => source.Success
        ? await TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> source,
        Func<TSource, Task<Result>> function,
        int numOfTry = 1
    ) => source.Success
        ? await source.Value!.Try(function, numOfTry)
        : Result.Fail(source.Detail as ErrorDetail);

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> source,
        Func<TSource, Task> function,
        int numOfTry = 1) => source.Success
        ? await source.Value!.Try(function, numOfTry)
        : Result.Fail(source.Detail as ErrorDetail);

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.Success
        ? await TryExtensions.Try(function, numOfTry)
        : Result.Fail(source.Detail as ErrorDetail);

    public static async Task<Result> OnSuccess<TSource>(
        this Result<TSource> source,
        Func<Task> function,
        int numOfTry = 1
    ) => source.Success
        ? await TryExtensions.Try(function, numOfTry)
        : Result.Fail(source.Detail as ErrorDetail);

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Result source,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => source.Success
        ? await TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Result source,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) => source.Success
        ? await TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static async Task<Result> OnSuccess(
        this Result source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.Success
        ? await TryExtensions.Try(function, numOfTry)
        : Result.Fail(source.Detail as ErrorDetail);

    public static async Task<Result> OnSuccess(
        this Result source,
        Func<Task> function,
        int numOfTry = 1) => source.Success
        ? await TryExtensions.Try(function, numOfTry)
        : Result.Fail(source.Detail as ErrorDetail);

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.Success
            ? result.Value!.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail as ErrorDetail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.Success
            ? result.Value!.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail as ErrorDetail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<Result<TResult>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.Success
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail as ErrorDetail);
    }

    public static async Task<Result<TResult>> OnSuccess<TSource, TResult>(
        this Task<Result<TSource>> source,
        Func<TResult> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.Success
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail as ErrorDetail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> source,
        Func<TSource, Result> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.Success
            ? result.Value!.Try(function, numOfTry)
            : Result.Fail(result.Detail as ErrorDetail);
    }

    public static async Task<Result> OnSuccess<TSource>(
        this Task<Result<TSource>> source,
        Func<Result> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.Success
            ? TryExtensions.Try(function, numOfTry)
            : Result.Fail(result.Detail as ErrorDetail);
    }

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> source,
        Func<Result<TResult>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.Success
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail as ErrorDetail);
    }

    public static async Task<Result<TResult>> OnSuccess<TResult>(
        this Task<Result> source,
        Func<TResult> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.Success
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(result.Detail as ErrorDetail);
    }

    public static async Task<Result> OnSuccess(
        this Task<Result> source,
        Func<Result> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.Success
            ? TryExtensions.Try(function, numOfTry)
            : Result.Fail(result.Detail as ErrorDetail);
    }
}