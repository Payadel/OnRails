namespace OnRail.Extensions;

public static class UsingExtensions {
    #region Using

    public static Result<TResult> Using<TSource, TResult>(
        this TSource obj,
        Func<TSource, TResult> function) where TSource : IDisposable =>
        TryExtensions.Try(() => {
            using (obj) {
                return function(obj);
            }
        });


    public static Result<TResult> Using<TSource, TResult>(
        this TSource obj,
        Func<TResult> function) where TSource : IDisposable =>
        TryExtensions.Try(() => {
            using (obj) {
                return function();
            }
        });

    public static Result Using<TSource>(
        this TSource obj,
        Action<TSource> action) where TSource : IDisposable =>
        TryExtensions.Try(() => {
            using (obj) {
                action(obj);
            }
        });

    public static Result Using<TSource>(
        this TSource obj,
        Action action) where TSource : IDisposable =>
        TryExtensions.Try(() => {
            using (obj) {
                action();
            }
        });

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
}