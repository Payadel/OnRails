using OnRail.Extensions.Try;

namespace OnRail.Extensions.Using;

public static partial class UsingExtensions {
    public static Task<Result<TResult>> Using<TSource, TResult>(
        this TSource obj,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(() => function(obj), numOfTry);
        }
    }

    public static Task<Result> Using<TSource>(
        this TSource obj,
        Func<Task<Result>> function,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(function, numOfTry);
        }
    }

    public static Task<Result> Using<TSource>(
        this TSource obj,
        Func<TSource, Task<Result>> function,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(() => function(obj), numOfTry);
        }
    }

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this TSource obj,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(() => function(obj), numOfTry);
        }
    }

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this TSource obj,
        Func<Task<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(function, numOfTry);
        }
    }

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this TSource obj,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(function, numOfTry);
        }
    }
}