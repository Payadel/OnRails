using OnRail.Extensions.Try;

namespace OnRail.Extensions.Using;

public static partial class UsingExtensions {
    public static Result<TResult> Using<TSource, TResult>(
        this TSource obj,
        Func<TSource, TResult> function,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(() => function(obj), numOfTry);
        }
    }

    public static Result Using<T>(
        this T obj,
        Func<T, Result> function,
        int numOfTry = 1) where T : IDisposable {
        using (obj) {
            return TryExtensions.Try(() => function(obj), numOfTry);
        }
    }

    public static Result<TResult> Using<TSource, TResult>(
        this TSource obj,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(() => function(obj), numOfTry);
        }
    }

    public static Result<TResult> Using<TSource, TResult>(
        this TSource obj,
        Func<TResult> function,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(function, numOfTry);
        }
    }

    public static Result Using<TSource>(
        this TSource obj,
        Func<Result> function,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(function, numOfTry);
        }
    }

    public static Result<TResult> Using<TSource, TResult>(
        this TSource obj,
        Func<Result<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(function, numOfTry);
        }
    }

    public static Result Using<TSource>(
        this TSource obj,
        Action<TSource> action,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(() => action(obj), numOfTry);
        }
    }

    public static Result Using<TSource>(
        this TSource obj,
        Action action,
        int numOfTry = 1) where TSource : IDisposable {
        using (obj) {
            return TryExtensions.Try(action, numOfTry);
        }
    }
}