using OnRail.Extensions.Tee;

namespace OnRail.Extensions.OperateWhen;

//TODO: Test

public static partial class OperateWhenExtensions {
    public static Task<T> TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Task> function,
        int numOfTry = 1) =>
        @this.Tee(() => OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> TeeOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task> function,
        int numOfTry = 1) =>
        @this.Tee(() => OperateWhen(predicate, function, numOfTry));

    public static Task<TSource> TeeOperateWhen<TSource, TResult>(
        this TSource @this,
        bool predicate,
        Func<Task<TResult>> function,
        int numOfTry = 1) =>
        @this.Tee(() => OperateWhen(predicate, function, numOfTry));

    public static Task<Result<TSource>> TeeOperateWhen<TSource, TResult>(
        this Result<TSource> @this,
        bool predicate,
        Func<Task<TResult>> function,
        int numOfTry = 1) =>
        @this.Tee(() => OperateWhen(predicate, function, numOfTry));

    public static Task<T> TeeOperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<Task> function,
        int numOfTry = 1) =>
        @this.Tee(() => OperateWhen(predicateFun, function, numOfTry));

    public static Task<Result<T>> TeeOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<Task> function,
        int numOfTry = 1) =>
        @this.Tee(() => OperateWhen(predicateFun, function, numOfTry));

    public static Task<TSource> TeeOperateWhen<TSource, TResult>(
        this TSource @this,
        Func<bool> predicateFun,
        Func<Task<TResult>> function,
        int numOfTry = 1) =>
        @this.Tee(() => OperateWhen(predicateFun, function, numOfTry));

    public static Task<Result<TSource>> TeeOperateWhen<TSource, TResult>(
        this Result<TSource> @this,
        Func<bool> predicateFun,
        Func<Task<TResult>> function,
        int numOfTry = 1) =>
        @this.Tee(() => OperateWhen(predicateFun, function, numOfTry));

    public static Task<T> TeeOperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Func<Task> function,
        int numOfTry = 1) =>
        @this.Tee(() => @this.OperateWhen(predicate, function, numOfTry));

    public static Task<TSource> TeeOperateWhen<TSource, TResult>(
        this TSource @this,
        Func<TSource, bool> predicate,
        Func<Task<TResult>> function,
        int numOfTry = 1) =>
        @this.Tee(() => @this.OperateWhen(predicate, function, numOfTry));

    public static Task<T> TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Func<T, Task> function,
        int numOfTry = 1) =>
        @this.Tee(() => @this.OperateWhen(predicate, function, numOfTry));

    public static Task<T> TeeOperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<T, Task> function,
        int numOfTry = 1
    ) => @this.Tee(() => @this.OperateWhen(predicateFun, function, numOfTry));

    public static Task<TSource> TeeOperateWhen<TSource, TResult>(
        this TSource @this,
        bool predicate,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) =>
        @this.Tee(() => @this.OperateWhen(predicate, function, numOfTry));

    public static Task<TSource> TeeOperateWhen<TSource, TResult>(
        this TSource @this,
        Func<bool> predicateFun,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => @this.Tee(() => @this.OperateWhen(predicateFun, function, numOfTry));
}