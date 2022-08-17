using OnRail.Extensions.Try;

namespace OnRail.Extensions.Tee;

public static partial class TeeExtensions {
    public static T Tee<T>(
        this T @this,
        Action<T> action,
        int numOfTry = 1) {
        @this.Try(action, numOfTry);
        return @this;
    }

    public static T Tee<T>(
        this T @this,
        Action action,
        int numOfTry = 1) {
        TryExtensions.Try(action, numOfTry);
        return @this;
    }

    public static void Tee(
        Action action,
        int numOfTry = 1) {
        TryExtensions.Try(action, numOfTry);
    }

    public static TSource Tee<TSource, TResult>(
        this TSource @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        @this.Try(function, numOfTry);
        return @this;
    }

    public static TSource Tee<TSource, TResult>(
        this TSource @this,
        Func<TResult> function,
        int numOfTry = 1) {
        TryExtensions.Try(function, numOfTry);
        return @this;
    }

    public static void Tee<TResult>(
        Func<TResult> function,
        int numOfTry = 1) {
        TryExtensions.Try(function, numOfTry);
    }
}