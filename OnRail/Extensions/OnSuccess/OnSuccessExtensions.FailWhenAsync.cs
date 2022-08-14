using OnRail.Extensions.OperateWhen;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test all methods

public static partial class OnSuccessExtensions {
    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Func<bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        () => OperateWhenExtensions.OperateWhen(predicate, Result.Fail(errorDetail), numOfTry));

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        () => OperateWhenExtensions.OperateWhen(predicate, Result.Fail(errorDetail)));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicateFunc, Result<T>.Fail(errorDetail), numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicateFunc,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicateFunc, errorDetail, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicateFunc, errorDetail, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicateFunc, errorDetail, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate, errorDetail, numOfTry));

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Func<Result> predicateFunc,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        () => OperateWhenExtensions.OperateWhen(predicateFunc().IsSuccess, errorDetail));

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        () => OperateWhenExtensions.OperateWhen(predicate.IsSuccess, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, Result> predicateFunc,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicateFunc(value).IsSuccess, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, Result> predicateFunc,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicateFunc(value).IsSuccess, errorDetail, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<Result> predicateFunc,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicateFunc().IsSuccess, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<Result> predicateFunc,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicateFunc().IsSuccess, errorDetail, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate.IsSuccess, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Result predicate,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate.IsSuccess, errorDetail));
}