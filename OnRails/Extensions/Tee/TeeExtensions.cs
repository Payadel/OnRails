using OnRails.Extensions.Try;

namespace OnRails.Extensions.Tee;

public static partial class TeeExtensions {
    public static T Tee<T>(
        this T source,
        Action<T> action,
        int numOfTry = 1
    ) {
        source.Try(action, numOfTry);
        return source;
    }

    public static T Tee<T>(
        this T source,
        Action action,
        int numOfTry = 1
    ) {
        TryExtensions.Try(action, numOfTry);
        return source;
    }

    public static void Tee(
        Action action,
        int numOfTry = 1
    ) {
        TryExtensions.Try(action, numOfTry);
    }

    public static TSource Tee<TSource, TResult>(
        this TSource source,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) {
        source.Try(function, numOfTry);
        return source;
    }

    public static TSource Tee<TSource, TResult>(
        this TSource source,
        Func<TResult> function,
        int numOfTry = 1
    ) {
        TryExtensions.Try(function, numOfTry);
        return source;
    }

    public static void Tee<TResult>(
        Func<TResult> function,
        int numOfTry = 1
    ) {
        TryExtensions.Try(function, numOfTry);
    }
}