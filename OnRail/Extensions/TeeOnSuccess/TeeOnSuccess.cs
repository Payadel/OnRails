using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Tee;

namespace OnRail.Extensions.TeeOnSuccess;

public static partial class TeeOnSuccessExtensions {
    public static Result<T> TeeOnSuccess<T>(
        this Result<T> @this,
        Action<T> action,
        int numOfTry = 1) {
        @this.OnSuccess(() => action(@this.Value!));
        return @this;
    }

    public static Result<T> TeeOnSuccess<T>(
        this Result<T> @this,
        Action action,
        int numOfTry = 1) => @this
        .OnSuccess(() => @this.Tee(action));

    public static Result TeeOnSuccess(
        this Result @this,
        Action action,
        int numOfTry = 1) =>
        @this.OnSuccess(() => @this.Tee(action));

    public static Result<TSource> TeeOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        @this.OnSuccess(() => function(@this.Value!));
        return @this;
    }

    public static Result<TSource> TeeOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> function,
        int numOfTry = 1) => @this
        .OnSuccess(() => @this.Tee(function));

    public static Result TeeOnSuccess<TResult>(
        this Result @this,
        Func<TResult> function,
        int numOfTry = 1) =>
        @this.OnSuccess(() => @this.Tee(function));
}