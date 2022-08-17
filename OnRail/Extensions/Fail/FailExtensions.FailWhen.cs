using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.Fail;

//TODO: Test

public static partial class FailExtensions {
    public static Result FailWhen(
        bool predicate,
        ErrorDetail errorDetail
    ) => predicate ? Result.Fail(errorDetail) : Result.Ok();

    public static Result FailWhen(
        Func<bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFunc, numOfTry)
        .OnSuccess(predicate => FailWhen(predicate, errorDetail));

    public static Result FailWhen(
        Result predicate,
        ErrorDetail errorDetail
    ) => predicate.IsSuccess ? Result.Fail(errorDetail) : Result.Ok();

    public static Result FailWhen(
        Func<Result> predicateFunc,
        ErrorDetail errorDetail
    ) => FailWhen(predicateFunc().IsSuccess, errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => predicate ? Result<T>.Fail(errorDetail) : Result<T>.Ok(@this);

    public static Result<T> FailWhen<T>(
        this T @this,
        bool predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => predicate
        ? @this.Fail(errorDetailFunc, numOfTry)
        : Result<T>.Ok(@this);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<T, bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.Try(predicateFunc, numOfTry)
        .OnSuccess(predicate => @this.FailWhen(predicate, errorDetail));

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<T, bool> predicateFunc,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.Try(predicateFunc, numOfTry)
        .OnSuccess(predicate => @this.FailWhen(predicate, errorDetail, numOfTry), numOfTry: 1);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFunc, numOfTry)
        .OnSuccess(predicate => @this.FailWhen(predicate, errorDetail), numOfTry: 1);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<bool> predicateFunc,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFunc, numOfTry)
        .OnSuccess(predicate => @this.FailWhen(predicate, errorDetail), numOfTry: 1);

    public static Result<T> FailWhen<T>(
        this T @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => predicate.IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(@this);

    public static Result<T> FailWhen<T>(
        this T @this,
        Result predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.FailWhen(predicate.IsSuccess, errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.FailWhen(predicate().IsSuccess, errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<Result> predicate,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.FailWhen(predicate().IsSuccess, errorDetail, numOfTry);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        ErrorDetail errorDetail
    ) => @this.FailWhen(predicate(@this), errorDetail);

    public static Result<T> FailWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.FailWhen(predicate(@this).IsSuccess, errorDetail);
}