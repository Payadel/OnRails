using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;

namespace OnRails.Extensions.Using;

public static partial class UsingExtensions {
    public static Task<Result<TResult>> Using<TSource, TResult>(
        this Task<TSource> taskObject,
        Func<TResult> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this Task<TSource> taskObject,
        Func<Result<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this Task<TSource> taskObject,
        Func<Task<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this Task<TSource> taskObject,
        Func<Task<Result<TResult>>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this Task<TSource> taskObject,
        Func<TSource, TResult> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this Task<TSource> taskObject,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this Task<TSource> taskObject,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

    public static Task<Result<TResult>> Using<TSource, TResult>(
        this Task<TSource> taskObject,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

    public static Task<Result> Using<TSource>(
        this Task<TSource> taskObject,
        Func<Result> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

    public static Task<Result> Using<TSource>(
        this Task<TSource> taskObject,
        Func<TSource, Result> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

    public static Task<Result> Using<TSource>(
        this Task<TSource> taskObject,
        Func<Task<Result>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

    public static Task<Result> Using<TSource>(
        this Task<TSource> taskObject,
        Func<TSource, Task<Result>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => taskObject)
            .OnSuccess(obj => obj.Using(function, numOfTry));

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
}