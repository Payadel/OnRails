using OnRail.Extensions.Tee;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Task<Result<TSource>> TeeOnFail<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Task<Result<TResult>>> onFailTask,
        int numOfTry = 1) => @this.OnFail(TeeExtensions.Tee(onFailTask, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource>(
        this Task<Result<TSource>> @this, Action onFailTask,
        int numOfTry = 1) => @this.OnFail(() => TeeExtensions.Tee(onFailTask, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource>(
        this Task<Result<TSource>> @this, Action<Result<TSource>> onFailTask,
        int numOfTry = 1) => @this.OnFail(result => result.Try(onFailTask, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task<Result>> onFailTask,
        int numOfTry = 1) => @this.OnFail(TeeExtensions.Tee(onFailTask, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>, Task<Result<TResult>>> onFailTask,
        int numOfTry = 1) => @this.OnFail(result => result.Tee(onFailTask, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>, Result<TResult>> onFailTask,
        int numOfTry = 1) => @this.OnFail(result => result.Tee(onFailTask, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<Result<TResult>> onFailTask,
        int numOfTry = 1
    ) => @this.OnFail(() => TeeExtensions.Tee(onFailTask, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource, TResult>(
        this Task<Result<TSource>> @this, Action onFailTask,
        int numOfTry = 1
    ) => @this.OnFail(() => TeeExtensions.Tee(onFailTask, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource, TResult>(
        this Task<Result<TSource>> @this, Action<Result<TSource>> onFailTask,
        int numOfTry = 1
    ) => @this.OnFail(result => result.Tee(onFailTask, numOfTry));

    public static Task<Result<TSource>> TeeOnFail<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result> onFailTask,
        int numOfTry = 1
    ) => @this.OnFail(() => TeeExtensions.Tee(onFailTask, numOfTry));

    public static Task<Result<T>> TeeOnFail<T>(
        this Task<Result<T>> @this,
        Func<Task> onFailTask,
        int numOfTry = 1
    ) => @this.OnFail(() => TeeExtensions.Tee(onFailTask, numOfTry));

    public static Task<Result<T>> TeeOnFail<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, Task> onFailTask,
        int numOfTry = 1
    ) => @this.OnFail(result => result.Tee(onFailTask, numOfTry));
}