using OnRail.Extensions.Fail;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test all methods

public static partial class OnSuccessExtensions {
    public static Result OnSuccessFailWhen(
        this Result @this,
        Func<bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(() => FailExtensions.FailWhen(predicateFunc, errorDetail, numOfTry));

    public static Result OnSuccessFailWhen(
        this Result @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => FailExtensions.FailWhen(predicate, errorDetail));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetail, numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicateFunc,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetailFunc, numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetail, numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFunc,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc, errorDetailFunc, numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(t => t.FailWhen(predicate, errorDetail));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicate, errorDetailFunc, numOfTry));

    public static Result OnSuccessFailWhen(
        this Result @this,
        Func<Result> predicateFunc,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => FailExtensions.FailWhen(predicateFunc().IsSuccess, errorDetail));

    public static Result OnSuccessFailWhen(
        this Result @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => FailExtensions.FailWhen(predicate.IsSuccess, errorDetail));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicateFunc,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc(t).IsSuccess, errorDetail));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicateFunc,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc(t).IsSuccess, errorDetailFunc, numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFunc,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc().IsSuccess, errorDetail));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFunc,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicateFunc().IsSuccess, errorDetailFunc, numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(t => t.FailWhen(predicate.IsSuccess, errorDetail));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Result predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(t => t.FailWhen(predicate.IsSuccess, errorDetailFunc, numOfTry));
}