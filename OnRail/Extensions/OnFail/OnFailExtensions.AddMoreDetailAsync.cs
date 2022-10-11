using OnRail.Extensions.Fail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> source,
        object moreDetail,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (!result.IsSuccess) {
            result.Detail ??= new ErrorDetail();
            result.Detail.AddDetail(moreDetail);
        }

        return result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        object moreDetail,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (!result.IsSuccess) {
            result.Detail ??= new ErrorDetail();
            result.Detail.AddDetail(moreDetail);
        }

        return result;
    }

    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> source,
        ErrorDetail errorDetail,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.IsSuccess ? result : result.Fail(errorDetail);
    }

    public static async Task<Result<T>> OnFail<T>(
        this Result<T> source,
        Func<Task<ErrorDetail>> errorDetailFunc,
        int numOfTry = 1) {
        if (source.IsSuccess)
            return source;

        return await TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(Result<T>.Fail);
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        ErrorDetail errorDetail,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.IsSuccess ? result : result.Fail(errorDetail);
    }

    public static async Task<Result> OnFail(
        this Task<Result> source,
        Func<ErrorDetail> errorDetailFunc,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (result.IsSuccess)
            return result;

        return TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(Result.Fail);
    }


    public static async Task<Result> OnFail(
        this Result source,
        Func<Task<ErrorDetail>> errorDetailFunc,
        int numOfTry = 1) {
        if (source.IsSuccess)
            return source;

        return await TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(Result.Fail);
    }
}