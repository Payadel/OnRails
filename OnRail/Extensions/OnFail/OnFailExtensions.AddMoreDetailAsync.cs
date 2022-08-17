using OnRail.Extensions.Fail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> @this,
        object moreDetail,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        if (!result.IsSuccess)
            result.Detail.AddDetail(moreDetail);
        return result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        object moreDetail,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        if (!result.IsSuccess)
            result.Detail.AddDetail(moreDetail);
        return result;
    }

    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> @this,
        ErrorDetail errorDetail,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess ? result : result.Fail(errorDetail);
    }

    public static async Task<Result<T>> OnFail<T>(
        this Result<T> @this,
        Func<Task<ErrorDetail>> errorDetailFunc,
        int numOfTry = 1) {
        if (@this.IsSuccess)
            return @this;

        return await TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(Result<T>.Fail);
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        ErrorDetail errorDetail,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess ? result : result.Fail(errorDetail);
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Func<ErrorDetail> errorDetailFunc,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        if (result.IsSuccess)
            return result;

        return TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(Result.Fail);
    }

    public static async Task<Result> OnFail(
        this Result @this,
        Func<Task<ErrorDetail>> errorDetailFunc,
        int numOfTry = 1) {
        if (@this.IsSuccess)
            return @this;

        return await TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(Result.Fail);
    }
}