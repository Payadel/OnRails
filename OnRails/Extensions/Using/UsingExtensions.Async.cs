using OnRails.Extensions.Try;

namespace OnRails.Extensions.Using;

public static partial class UsingExtensions {
    #region <TSource, Task<Result<TResult>>>

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this TSource obj,
        Func<Task<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(async () => {
            using (obj) {
                return await function();
            }
        }, numOfTry);

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this TSource obj,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(async () => {
            using (obj) {
                return await function();
            }
        }, numOfTry);

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this TSource obj,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Using(() => function(obj), numOfTry);

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this TSource obj,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Using(() => function(obj), numOfTry);

    #endregion


    #region <T, Task<Result>>

    public static Task<Result> Using<T>(
        this T obj,
        Func<Task<Result>> function,
        int numOfTry = 1) where T : IDisposable =>
        TryExtensions.Try(async () => {
            using (obj) {
                return await function();
            }
        }, numOfTry);

    public static Task<Result> Using<T>(
        this T obj,
        Func<T, Task<Result>> function,
        int numOfTry = 1) where T : IDisposable =>
        obj.Using(() => function(obj), numOfTry);

    #endregion
}