using OnRail.Extensions.Try;

namespace OnRail.Extensions.Tee;

public static partial class TeeExtensions {
    public static async Task Tee<TResult>(
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) {
        await TryExtensions.Try(function, numOfTry);
    }

    public static async Task<T> Tee<T>(
        this Task<T> source,
        Action<T> action,
        int numOfTry = 1
    ) {
        var t = await source;
        TryExtensions.Try(() => action(t), numOfTry);
        return t;
    }

    public static async Task<T> Tee<T>(
        this Task<T> source,
        Action action,
        int numOfTry = 1
    ) {
        TryExtensions.Try(action, numOfTry);
        return await source;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> source,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) {
        var t = await source;
        t.Try(function, numOfTry);
        return t;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> source,
        Func<TResult> function,
        int numOfTry = 1
    ) {
        TryExtensions.Try(function, numOfTry);
        return await source;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this TSource source,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) {
        await source.Try(function, numOfTry);
        return source;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this TSource source,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) {
        await TryExtensions.Try(function, numOfTry);
        return source;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> source,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) {
        await source.Try(function, numOfTry);
        return await source;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> source,
        Func<Task<TResult>> function,
        int numOfTry = 1
    ) {
        await TryExtensions.Try(function, numOfTry);
        return await source;
    }
}