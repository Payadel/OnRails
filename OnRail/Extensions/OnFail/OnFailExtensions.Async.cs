using OnRail.Extensions.Fail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnFail;

//TODO: Test

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

    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task<Result<TSource>>> onFailTask,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        if (!result.IsSuccess)
            return await TryExtensions.Try(onFailTask, numOfTry);

        return result;
    }

    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>, Result<TSource>> onFailTask,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? result.Try(onFailTask, numOfTry)
            : result;
    }

    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>> onFailTask,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? TryExtensions.Try(onFailTask, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Func<Task<Result>> onFailTask,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? await TryExtensions.Try(onFailTask, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Func<Result, Task<Result>> onFailTask,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? await @this.Try(onFailTask, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Func<Result, Result> onFailTask,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? result.Try(onFailTask, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Func<Result> onFailTask,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? TryExtensions.Try(onFailTask, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Action onFailTask,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        if (!result.IsSuccess)
            TryExtensions.Try(onFailTask, numOfTry);

        return result;
    }

    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> @this,
        Action onFailTask,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        if (!result.IsSuccess)
            TryExtensions.Try(onFailTask, numOfTry);

        return result;
    }

    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, Task<Result<T>>> onFailTask,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        if (!result.IsSuccess)
            await @this.Try(onFailTask, numOfTry);

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
        var t = await TryExtensions.Try(@this, numOfTry);
        if (t.IsSuccess)
            return t;

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

    public static async Task<Result<T>> OnFail<T>(
        this Result<T> @this,
        Func<Result<T>, Task<Result<T>>> fail,
        int numOfTry = 1) =>
        @this.IsSuccess ? @this : await @this.Try(fail, numOfTry);

    public static async Task<Result<T>> OnFail<T>(
        this Result<T> @this,
        Func<Task<Result<T>>> fail,
        int numOfTry = 1) =>
        @this.IsSuccess ? @this : await TryExtensions.Try(fail, numOfTry);

    public static async Task<Result> OnFail(
        this Result @this,
        Func<Result, Task<Result>> fail,
        int numOfTry = 1) =>
        @this.IsSuccess ? @this : await @this.Try(fail, numOfTry);

    public static async Task<Result> OnFail(
        this Result @this,
        Func<Task<Result>> fail,
        int numOfTry = 1) =>
        @this.IsSuccess ? @this : await TryExtensions.Try(fail, numOfTry);

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Action<Result> fail,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            await @this.Try(fail, numOfTry);
        return methodResult;
    }

    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> @this,
        Action<Result<T>> fail,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            await @this.Try(fail, numOfTry);
        return methodResult;
    }
}