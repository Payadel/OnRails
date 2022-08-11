namespace OnRail.Extensions.OperateWhen;

public static partial class OperateWhenExtensions {
    public static async Task<T> TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Task> function) {
        if (predicate)
            await function();
        return @this;
    }

    public static async Task<Result<T>> TeeOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task> function) {
        if (predicate)
            await function();
        return @this;
    }

    public static async Task<Result<TSource>> TeeOperateWhen<TSource, TResult>(
        this TSource @this,
        bool predicate,
        Func<Task<TResult>> function) {
        if (predicate)
            await function();
        return Result<TSource>.Ok(@this);
    }

    public static async Task<Result<TSource>> TeeOperateWhen<TSource, TResult>(
        this Result<TSource> @this,
        bool predicate,
        Func<Task<TResult>> function) {
        if (predicate)
            await function();
        return @this;
    }

    public static Task<T> TeeOperateWhen<T>(
        this T @this,
        Func<bool> predicate,
        Func<Task> function) =>
        @this.TeeOperateWhen(predicate(), function);

    public static Task<Result<T>> TeeOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<Task> function) =>
        @this.TeeOperateWhen(predicate(), function);

    public static Task<Result<TSource>> TeeOperateWhen<TSource, TResult>(
        this TSource @this,
        Func<bool> predicate,
        Func<Task<TResult>> function) =>
        @this.TeeOperateWhen(predicate(), function);

    public static Task<Result<TSource>> TeeOperateWhen<TSource, TResult>(
        this Result<TSource> @this,
        Func<bool> predicate,
        Func<Task<TResult>> function) =>
        @this.TeeOperateWhen(predicate(), function);

    public static Task<T> TeeOperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Func<Task> function) =>
        @this.TeeOperateWhen(predicate(@this), function);

    public static Task<Result<TSource>> TeeOperateWhen<TSource, TResult>(
        this TSource @this,
        Func<TSource, bool> predicate,
        Func<Task<TResult>> function) =>
        @this.TeeOperateWhen(predicate(@this), function);

    public static async Task<T> TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Func<T, Task> function) {
        if (predicate)
            await function(@this);
        return @this;
    }

    public static Task<T> TeeOperateWhen<T>(
        this T @this,
        Func<bool> predicate,
        Func<T, Task> function) =>
        @this.TeeOperateWhen(predicate(), function);

    public static async Task<Result<TSource>> TeeOperateWhen<TSource, TResult>(
        this TSource @this,
        bool predicate,
        Func<TSource, Task<TResult>> function) {
        if (predicate)
            await function(@this);
        return Result<TSource>.Ok(@this);
    }

    public static Task<Result<TSource>> TeeOperateWhen<TSource, TResult>(
        this TSource @this,
        Func<bool> predicate,
        Func<TSource, Task<TResult>> function) =>
        @this.TeeOperateWhen(predicate(), function);
}