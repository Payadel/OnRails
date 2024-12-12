using OnRails.Extensions.Tee;

namespace OnRails.Extensions.Using;

public static partial class UsingExtensions {
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

    public static TSource TeeUsing<TSource, TResult>(
        this TSource obj,
        Func<Result<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static TSource TeeUsing<TSource, TResult>(
        this TSource obj,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static TSource TeeUsing<TSource>(
        this TSource obj,
        Func<Result> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static TSource TeeUsing<TSource>(
        this TSource obj,
        Func<TSource, Result> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static Task<TSource> TeeUsing<TSource, TResult>(
        this Task<TSource> obj,
        Func<Task<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static Task<TSource> TeeUsing<TSource, TResult>(
        this Task<TSource> obj,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static Task<TSource> TeeUsing<TSource, TResult>(
        this Task<TSource> obj,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static Task<TSource> TeeUsing<TSource, TResult>(
        this Task<TSource> obj,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static Task<TSource> TeeUsing<TSource>(
        this Task<TSource> obj,
        Func<Task<Result>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static Task<TSource> TeeUsing<TSource>(
        this Task<TSource> obj,
        Func<TSource, Task<Result>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static Task<TSource> TeeUsing<TSource>(
        this Task<TSource> taskObject,
        Action action,
        int numOfTry = 1) where TSource : IDisposable =>
        taskObject.Tee(() => taskObject.Using(action, numOfTry));

    public static Task<TSource> TeeUsing<TSource>(
        this Task<TSource> taskObject,
        Action<TSource> action,
        int numOfTry = 1) where TSource : IDisposable =>
        taskObject.Tee(() => taskObject.Using(action, numOfTry));
}