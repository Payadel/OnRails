using OnRails.Extensions.Try;

namespace OnRails.Extensions.Using;

public static partial class UsingExtensions {
    public static Result<TResult> Using<TSource, TResult>(
        this TSource obj,
        Func<TSource, TResult> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Using(() => function(obj), numOfTry);

    public static Result Using<T>(
        this T obj,
        Func<T, Result> function,
        int numOfTry = 1) where T : IDisposable =>
        obj.Using(() => function(obj), numOfTry);

    public static Result<TResult> Using<TSource, TResult>(
        this TSource obj,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Using(() => function(obj), numOfTry);

    public static Result<TResult> Using<TSource, TResult>(
        this TSource obj,
        Func<TResult> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => {
            using (obj) {
                return Result<TResult>.Ok(function());
            }
        }, numOfTry);

    public static Result Using<TSource>(
        this TSource obj,
        Func<Result> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => {
            using (obj) {
                return function();
            }
        }, numOfTry);

    public static Result<TResult> Using<TSource, TResult>(
        this TSource obj,
        Func<Result<TResult>> function,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => {
            using (obj) {
                return function();
            }
        }, numOfTry);

    public static Result Using<TSource>(
        this TSource obj,
        Action<TSource> action,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Using(() => action(obj), numOfTry);

    public static Result Using<TSource>(
        this TSource obj,
        Action action,
        int numOfTry = 1) where TSource : IDisposable =>
        TryExtensions.Try(() => {
            using (obj) {
                action();
            }
        }, numOfTry);
}