using OnRails.Extensions.Try;

namespace OnRails.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> source,
        Func<Task<Result<TSource>>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (!result.Success)
            return await TryExtensions.Try(function, numOfTry);

        return result;
    }

    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> source,
        Func<Result<TSource>, Result<TSource>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.Success
            ? result.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> source,
        Func<Result<TSource>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.Success
            ? TryExtensions.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.Success
            ? await TryExtensions.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.Success
            ? await source.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Func<Result, Result> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.Success
            ? result.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Func<Result> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.Success
            ? TryExtensions.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> source,
        Func<Result<T>, Task<Result<T>>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (!result.Success)
            await source.Try(function, numOfTry);

        return result;
    }

    public static async Task<Result<T>> OnFail<T>(
        this Result<T> source,
        Func<Result<T>, Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.Success
        ? source
        : await source.Try(function, numOfTry);

    public static async Task<Result<T>> OnFail<T>(
        this Result<T> source,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) =>
        source.Success ? source : await TryExtensions.Try(function, numOfTry);

    public static async Task<Result> OnFail(
        this Result source,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) => source.Success
        ? source
        : await source.Try(function, numOfTry);

    public static async Task<Result> OnFail(
        this Result source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.Success
        ? source
        : await TryExtensions.Try(function, numOfTry);
}