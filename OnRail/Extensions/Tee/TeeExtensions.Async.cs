using OnRail.Extensions.Try;

namespace OnRail.Extensions.Tee;

public static partial class TeeExtensions {
    public static async Task Tee<TResult>(
        Func<Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.Try(function, numOfTry);
    }

    public static async Task<T> Tee<T>(
        this Task<T> @this,
        Action<T> action,
        int numOfTry = 1
    ) {
        var t = await @this;
        TryExtensions.Try(() => action(t), numOfTry);
        return t;
    }

    public static async Task<T> Tee<T>(
        this Task<T> @this,
        Action action,
        int numOfTry = 1) {
        TryExtensions.Try(action, numOfTry);
        return await @this;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        var t = await @this;
        t.Try(function, numOfTry);
        return t;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> @this,
        Func<TResult> function,
        int numOfTry = 1) {
        TryExtensions.Try(function, numOfTry);
        return await @this;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) {
        await @this.Try(function, numOfTry);
        return @this;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this TSource @this,
        Func<Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.Try(function, numOfTry);
        return @this;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) {
        await @this.Try(function, numOfTry);
        return await @this;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> @this,
        Func<Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.Try(function, numOfTry);
        return await @this;
    }
}