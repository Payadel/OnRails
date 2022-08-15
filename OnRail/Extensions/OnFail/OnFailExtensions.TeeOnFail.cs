using OnRail.Extensions.Tee;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> @this, Action onFail, int numOfTry = 1) =>
        @this.OnFail(() => TeeExtensions.Tee(onFail, numOfTry));

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> @this, Action<Result<TSource>> onFail, int numOfTry = 1) =>
        @this.OnFail(result => result.Tee(onFail, numOfTry));

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> @this,
        Func<Task<Result>> onFail,
        int numOfTry = 1) => @this.OnFail(() => TeeExtensions.Tee(onFail, numOfTry));

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TSource>, Result<TResult>> onFail,
        int numOfTry = 1) =>
        @this.OnFail(result => result.Tee(onFail, numOfTry));

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> onFail,
        int numOfTry = 1
    ) => @this.OnFail(result => result.Tee(onFail, numOfTry));

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> @this, Action onFail,
        int numOfTry = 1
    ) => @this.OnFail(result => result.Tee(onFail, numOfTry));

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> @this, Action<Result<TSource>> onFail,
        int numOfTry = 1
    ) => @this.OnFail(result => result.Tee(onFail, numOfTry));

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> @this,
        Func<Result> onFail,
        int numOfTry = 1
    ) => @this.OnFail(result => result.Tee(onFail, numOfTry));

    public static Result<T> TeeOnFail<T>(
        this Result<T> @this,
        Func<Task> onFail,
        int numOfTry = 1
    ) => @this.OnFail(result => result.Tee(onFail, numOfTry));

    public static Result<T> TeeOnFail<T>(
        this Result<T> @this,
        Func<Result<T>, Task> onFail,
        int numOfTry = 1
    ) => @this.OnFail(result => result.Tee(onFail, numOfTry));
}