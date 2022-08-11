namespace OnRail.Extensions;

public static class UsingExtensions {
    #region Using

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

    #endregion

    #region Async methods

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

    #endregion

    #region TeeUsing

    public static TSource TeeUsing<TSource, TResult>(
        this TSource obj,
        Func<TSource, TResult> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static TSource TeeUsing<TSource, TResult>(
        this TSource obj,
        Func<TResult> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    #endregion
}