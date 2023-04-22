using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Fail;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> source,
        ErrorDetail? newErrorDetail,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.IsSuccess ? result : result.Fail(newErrorDetail);
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
        ErrorDetail? newErrorDetail,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.IsSuccess ? result : Result.Fail(newErrorDetail);
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