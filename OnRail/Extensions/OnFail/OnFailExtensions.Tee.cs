using OnRail.Extensions.Tee;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> source, Action action, int numOfTry = 1) =>
        source.OnFail(action, numOfTry);

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> source, Action<Result<TSource>> action, int numOfTry = 1) =>
        source.OnFail(result => result.Tee(action, numOfTry));

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.OnFail(() => TeeExtensions.Tee(function, numOfTry));

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> source,
        Func<Result<TSource>, Result<TResult>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Result<TSource> TeeOnFail<TSource, TResult>(
        this Result<TSource> source,
        Func<Result<TResult>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Result<TSource> TeeOnFail<TSource>(
        this Result<TSource> source,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Result<T> TeeOnFail<T>(
        this Result<T> source,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Result<T> TeeOnFail<T>(
        this Result<T> source,
        Func<Result<T>, Task> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry));

    public static Result TeeOnFail(
        this Result source,
        Action action,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : TryExtensions.Try(action, numOfTry);

    public static Result TeeOnFail(
        this Result source,
        Action<Result> action,
        int numOfTry = 1) => source.IsSuccess
        ? source
        : source.Try(action, numOfTry);

    public static async Task<Result> TeeOnFail(
        this Task<Result> source,
        Action action,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.IsSuccess
            ? result
            : TryExtensions.Try(action, numOfTry);
    }

    public static async Task<Result> TeeOnFail(
        this Task<Result> source,
        Task task,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.IsSuccess
            ? result
            : await TryExtensions.Try(task, numOfTry);
    }

    public static async Task<Result> TeeOnFail(
        this Task<Result> source,
        Action<Result> action,
        int numOfTry = 1
    ) {
        var methodResult = await source;
        if (!methodResult.IsSuccess)
            await source.Try(action, numOfTry);
        return methodResult;
    }
}