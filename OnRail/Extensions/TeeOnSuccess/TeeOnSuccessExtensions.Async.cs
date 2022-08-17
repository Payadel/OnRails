using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Tee;

namespace OnRail.Extensions.TeeOnSuccess;

public static partial class TeeOnSuccessExtensions {
    public static async Task<Result<T>> TeeOnSuccess<T>(
        this Task<Result<T>> @this,
        Action<T> action,
        int numOfTry = 1) {
        await @this.OnSuccess(action);
        return await @this;
    }

    public static Task<Result<T>> TeeOnSuccess<T>(
        this Task<Result<T>> @this,
        Action action,
        int numOfTry = 1) => @this
        .OnSuccess(() => @this.Tee<Task<Result<T>>>(action));

    public static Task<Result> TeeOnSuccess(
        this Task<Result> @this,
        Action action,
        int numOfTry = 1) =>
        @this.OnSuccess(() => @this.Tee<Task<Result>>(action));

    public static async Task<Result<TSource>> TeeOnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        await @this.OnSuccess(function);
        return await @this;
    }

    public static Task<Result<TSource>> TeeOnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> function,
        int numOfTry = 1) => @this
        .OnSuccess(() => @this.Tee<Task<Result<TSource>>, TResult>(function));

    public static Task<Result> TeeOnSuccess<TResult>(
        this Task<Result> @this,
        Func<TResult> function,
        int numOfTry = 1) =>
        @this.OnSuccess(() => @this.Tee<Task<Result>, TResult>(function));
}