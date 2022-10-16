using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> source,
        Func<Task<Result<TSource>>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (!result.IsSuccess)
            return await TryExtensions.Try(function, numOfTry);

        return result;
    }

    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> source,
        Func<Result<TSource>, Result<TSource>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.IsSuccess
            ? result.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> source,
        Func<Result<TSource>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.IsSuccess
            ? await TryExtensions.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.IsSuccess
            ? await source.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Func<Result, Result> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.IsSuccess
            ? result.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Func<Result> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return !result.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Action action,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.IsSuccess
            ? result
            : TryExtensions.Try(action, numOfTry);
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Task task,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.IsSuccess
            ? result
            : await TryExtensions.Try(task, numOfTry);
    }

    //TODO: https://github.com/Payadel/OnRail/issues/9
    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> source,
        Action action,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (!result.IsSuccess)
            TryExtensions.Try(action, numOfTry);

        return result;
    }

    //TODO: https://github.com/Payadel/OnRail/issues/9
    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> source,
        Func<Task> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (!result.IsSuccess)
            await TryExtensions.Try(function, numOfTry);

        return result;
    }

    //TODO: https://github.com/Payadel/OnRail/issues/9
    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> source,
        Func<Result<T>, Task<Result<T>>> function,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (!result.IsSuccess)
            await source.Try(function, numOfTry);

        return result;
    }

    public static async Task<Result<T>> OnFail<T>(
        this Result<T> source,
        Func<Result<T>, Task<Result<T>>> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : await source.Try(function, numOfTry);

    public static async Task<Result<T>> OnFail<T>(
        this Result<T> source,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) =>
        source.IsSuccess ? source : await TryExtensions.Try(function, numOfTry);

    public static async Task<Result> OnFail(
        this Result source,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : await source.Try(function, numOfTry);

    public static async Task<Result> OnFail(
        this Result source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : await TryExtensions.Try(function, numOfTry);

    //TODO: https://github.com/Payadel/OnRail/issues/9
    public static async Task<Result> OnFail(
        this Task<Result> source,
        Action<Result> action,
        int numOfTry = 1
    ) {
        var methodResult = await source;
        if (!methodResult.IsSuccess)
            await source.Try(action, numOfTry);
        return methodResult;
    }

    //TODO: https://github.com/Payadel/OnRail/issues/9
    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> source,
        Action<Result<T>> action,
        int numOfTry = 1
    ) {
        var methodResult = await source;
        if (!methodResult.IsSuccess)
            await source.Try(action, numOfTry);
        return methodResult;
    }


    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> source,
        ErrorDetail? errorDetail,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.IsSuccess ? result : result.Fail(errorDetail);
    }

    public static async Task<Result<T>> OnFail<T>(
        this Result<T> source,
        Func<Task<ErrorDetail?>> errorDetailFunc,
        int numOfTry = 1) {
        if (source.IsSuccess)
            return source;

        return await TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(Result<T>.Fail);
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        ErrorDetail? errorDetail,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.IsSuccess ? result : result.Fail(errorDetail);
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Func<ErrorDetail?> errorDetailFunc,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (result.IsSuccess)
            return result;

        return TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(Result.Fail);
    }


    public static async Task<Result> OnFail(
        this Result source,
        Func<Task<ErrorDetail?>> errorDetailFunc,
        int numOfTry = 1) {
        if (source.IsSuccess)
            return source;

        return await TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(Result.Fail);
    }
}