namespace OnRail.Extensions;

public static class UsingExtensions {
    #region Using

    public static TResult Using<TSource, TResult>(
        this TSource obj,
        Func<TSource, TResult> function) where TSource : IDisposable {
        using (obj) {
            return function(obj);
        }
    }

    public static TResult Using<TSource, TResult>(
        this TSource obj,
        Func<TResult> function) where TSource : IDisposable {
        using (obj) {
            return function();
        }
    }

    public static void Using<TSource>(
        this TSource obj,
        Action<TSource> action) where TSource : IDisposable {
        using (obj) {
            action(obj);
        }
    }

    #endregion

    #region UsingAsync

    public static Task<TResult> UsingAsync<TSource, TResult>(
        this TSource obj,
        Func<TSource, Task<TResult>> function) where TSource : IDisposable {
        using (obj) {
            return function(obj);
        }
    }

    public static Task<Result<TResult>> UsingAsync<TSource, TResult>(
        this TSource obj,
        Func<TSource, Task<Result<TResult>>> function) where TSource : IDisposable {
        using (obj) {
            return function(obj);
        }
    }

    public static Task<TResult> UsingAsync<TSource, TResult>(
        this TSource obj,
        Func<Task<TResult>> function) where TSource : IDisposable {
        using (obj) {
            return function();
        }
    }

    public static Task<Result<TResult>> UsingAsync<TSource, TResult>(
        this TSource obj,
        Func<Task<Result<TResult>>> function) where TSource : IDisposable {
        using (obj) {
            return function();
        }
    }

    #endregion

    #region TeeUsing

    public static T TeeUsing<T>(
        this T obj,
        Action<T> action) where T : IDisposable =>
        obj.Tee(() => obj.Using(action));

    public static TSource TeeUsing<TSource, TResult>(
        this TSource obj,
        Func<TSource, TResult> function) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function));

    #endregion

    #region TryTeeUsing

    public static Result<T> TryTeeUsing<T>(
        this T obj,
        Action<T> action) where T : IDisposable =>
        TryExtensions.Try(() => obj.TeeUsing(action));

    public static Result<TSource> TryTeeUsing<TSource, TResult>(
        this TSource obj,
        Func<TSource, TResult> function) where TSource : IDisposable =>
        TryExtensions.Try(() => obj.TeeUsing(function));

    #endregion

    #region TryUsing

    public static Result TryUsing<T>(
        this T obj,
        Action<T> action) where T : IDisposable =>
        TryExtensions.Try(() => obj.Using(action));

    public static Result<TResult> TryUsing<TSource, TResult>(
        this TSource obj,
        Func<TSource, TResult> function) where TSource : IDisposable =>
        TryExtensions.Try(() => obj.Using(function));

    #endregion

    #region TryUsingAsync

    public static Task<Result<TResult>> TryUsingAsync<TSource, TResult>(
        this TSource obj,
        Func<TSource, Task<TResult>> function,
        int numOfTry) where TSource : IDisposable =>
        TryExtensions.TryAsync(() => obj.UsingAsync(function), numOfTry);

    public static Task<Result<TResult>> TryUsingAsync<TSource, TResult>(
        this TSource obj,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry) where TSource : IDisposable =>
        TryExtensions.TryAsync(() => obj.UsingAsync(function), numOfTry);

    #endregion
}