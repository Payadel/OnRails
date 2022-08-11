using OnRail.ResultDetails;

namespace OnRail.Extensions;

public static class FailExtensions {
    #region FailWhen

    public static Result FailWhen(
        bool predicate,
        ErrorDetail errorDetail
    ) => predicate ? Result.Fail(errorDetail) : Result.Ok();

    public static Result FailWhen(
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => FailWhen(predicate(), errorDetail);

    public static Result FailWhen(
        Result predicate,
        ErrorDetail errorDetail
    ) => predicate.IsSuccess ? Result.Fail(errorDetail) : Result.Ok();

    public static Result FailWhen(
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => FailWhen(predicate(), errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => predicate ? Result<T>.Fail(errorDetail) : Result<T>.Ok(@this);

    public static Result<T> FailWhen<T>(
        this T @this,
        bool predicate,
        Func<T, ErrorDetail> errorDetail
    ) => predicate ? Result<T>.Fail(errorDetail(@this)) : Result<T>.Ok(@this);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        ErrorDetail errorDetail
    ) => @this.FailWhen(predicate(@this), errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.FailWhen(predicate(@this), errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => @this.FailWhen(predicate(), errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.FailWhen(predicate(), errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => predicate.IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(@this);

    public static Result<T> FailWhen<T>(
        this T @this,
        Result predicate,
        Func<T, ErrorDetail> errorDetail
    ) => predicate.IsSuccess ? Result<T>.Fail(errorDetail(@this)) : Result<T>.Ok(@this);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.FailWhen(predicate().IsSuccess, errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.FailWhen(predicate().IsSuccess, errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        ErrorDetail errorDetail
    ) => @this.FailWhen(predicate(@this), errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.FailWhen(predicate(@this), errorDetail);

    #endregion

    #region Fail

    public static Result Fail(
        this Result _,
        ErrorDetail errorDetail
    ) => Result.Fail(errorDetail);

    public static Result<T> Fail<T>(
        this Result<T> _,
        ErrorDetail errorDetail
    ) => Result<T>.Fail(errorDetail);

    #endregion

    //TODO: TeeOnFail
    //TODO: TeeOnFail Async
}