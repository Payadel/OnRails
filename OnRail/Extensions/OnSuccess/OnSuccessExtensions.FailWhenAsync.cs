using OnRail.Extensions.Fail;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test all methods

public static partial class OnSuccessExtensions {
    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Func<bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(() => FailExtensions.FailWhen(predicateFunc, errorDetail, numOfTry));

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => FailExtensions.FailWhen(predicate, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetail, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicateFunc,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetail, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetail, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetail, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(t => t.FailWhen(predicate, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicate, errorDetail, numOfTry));

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Func<Result> predicateFunc,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => FailExtensions.FailWhen(predicateFunc().IsSuccess, errorDetail));

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => FailExtensions.FailWhen(predicate.IsSuccess, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, Result> predicateFunc,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, Result> predicateFunc,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<Result> predicateFunc,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<Result> predicateFunc,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(t => t.FailWhen(predicate.IsSuccess, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Result predicate,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicate.IsSuccess, errorDetail));
}