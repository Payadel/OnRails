using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    #region OnSuccess

    public static Result OnSuccess(this Result source, SuccessDetail newDetail) =>
        source.IsSuccess ? Result.Ok(newDetail) : source;

    public static Result OnSuccess(this Result source, Func<SuccessDetail> func, int numOfTry = 1) =>
        source.IsSuccess
            ? TryExtensions.Try(func, numOfTry)
                .OnSuccess(newDetail => Result.Ok(newDetail))
            : source;

    public static Result OnSuccess(this Result source, Func<SuccessDetail, SuccessDetail> func, int numOfTry = 1) =>
        source.IsSuccess
            ? TryExtensions.Try(() => func((SuccessDetail) source.Detail!), numOfTry)
                .OnSuccess(newDetail => Result.Ok(newDetail))
            : source;

    #endregion

    #region OnSuccess<T>

    public static Result<T> OnSuccess<T>(this Result<T> source, SuccessDetail newDetail) =>
        source.IsSuccess ? Result<T>.Ok(source.Value!, newDetail) : source;

    public static Result<T> OnSuccess<T>(this Result<T> source, Func<SuccessDetail> func, int numOfTry = 1) =>
        source.IsSuccess
            ? TryExtensions.Try(func, numOfTry)
                .OnSuccess(detail => Result<T>.Ok(source.Value!, detail))
            : source;

    public static Result<T> OnSuccess<T>(this Result<T> source, Func<SuccessDetail, SuccessDetail> func,
        int numOfTry = 1) => source.IsSuccess
        ? TryExtensions.Try(() => func((SuccessDetail) source.Detail!), numOfTry)
            .OnSuccess(detail => Result<T>.Ok(source.Value!, detail))
        : source;

    #endregion

    #region Async

    public static Task<Result> OnSuccess(this Task<Result> source, SuccessDetail newDetail, int numOfTry = 1) =>
        TryExtensions.Try(async () => {
            var result = await source;
            return result.OnSuccess(newDetail);
        }, numOfTry);

    public static Task<Result> OnSuccess(this Task<Result> source, Func<SuccessDetail> func, int numOfTry = 1) =>
        TryExtensions.Try(async () => {
            var result = await source;
            return result.OnSuccess(func());
        }, numOfTry);

    public static Task<Result> OnSuccess(this Task<Result> source, Func<SuccessDetail, SuccessDetail> func,
        int numOfTry = 1) =>
        TryExtensions.Try(async () => {
            var result = await source;
            return result.OnSuccess(() => func((result.Detail as SuccessDetail)!));
        }, numOfTry);

    #endregion

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