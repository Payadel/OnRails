using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    #region Async<T>

    public static Task<Result<T>>
        OnSuccess<T>(this Task<Result<T>> source, SuccessDetail newDetail, int numOfTry = 1) =>
        TryExtensions.Try(async () => {
            var result = await source;
            return result.OnSuccess(newDetail);
        }, numOfTry);

    public static Task<Result<T>>
        OnSuccess<T>(this Task<Result<T>> source, Func<SuccessDetail> func, int numOfTry = 1) =>
        TryExtensions.Try(async () => {
            var result = await source;
            return result.OnSuccess(func());
        }, numOfTry);

    public static Task<Result<T>> OnSuccess<T>(this Task<Result<T>> source, Func<SuccessDetail, SuccessDetail> func,
        int numOfTry = 1) =>
        TryExtensions.Try(async () => {
            var result = await source;
            return result.OnSuccess(() => func((SuccessDetail) result.Detail!));
        }, numOfTry);

    #endregion
}