using OnRail.Extensions.Tee;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Task<Result<TSource>> TeeOnFail<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<Result<TResult>>> onFail,
        int numOfTry = 1) => @this.OnFail(() => TeeExtensions.Tee(onFail, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource>(
        this Task<Result<TSource>> @this, Action onFail,
        int numOfTry = 1) => @this.OnFail(() => TeeExtensions.Tee(onFail, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource>(
        this Task<Result<TSource>> @this, Action<Result<TSource>> onFail,
        int numOfTry = 1) => @this.OnFail(result => result.Tee(onFail, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task<Result>> onFail,
        int numOfTry = 1) => @this.OnFail(() => TeeExtensions.Tee(onFail, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>, Task<Result<TResult>>> onFail,
        int numOfTry = 1) => @this.OnFail(result => result.Tee(onFail, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>, Result<TResult>> onFail,
        int numOfTry = 1) => @this.OnFail(result => result.Tee(onFail, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TResult>> onFail,
        int numOfTry = 1
    ) => @this.OnFail(() => TeeExtensions.Tee(onFail, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result> onFail,
        int numOfTry = 1
    ) => @this.OnFail(() => TeeExtensions.Tee(onFail, numOfTry));

    public static Task<Result<T>> TeeOnFail<T>(
        this Task<Result<T>> @this,
        Func<Task> onFail,
        int numOfTry = 1
    ) => @this.OnFail(() => TeeExtensions.Tee(onFail, numOfTry));

    public static Task<Result<T>> TeeOnFail<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, Task> onFailTask,
        int numOfTry = 1
    ) => @this.OnFail(result => result.Tee(onFailTask, numOfTry));
}