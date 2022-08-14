using OnRail.Extensions.OperateWhen;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test all methods

public static partial class OnSuccessExtensions {
    public static Result OnSuccessFailWhen(
        this Result @this,
        Func<bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        () => OperateWhenExtensions.OperateWhen(predicate, Result.Fail(errorDetail), numOfTry));

    public static Result OnSuccessFailWhen(
        this Result @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        () => OperateWhenExtensions.OperateWhen(predicate, Result.Fail(errorDetail)));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate, Result<T>.Fail(errorDetail), numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate, errorDetailFunc, numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate, errorDetail, numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate, errorDetailFunc, numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate, errorDetail));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate, errorDetailFunc, numOfTry));

    public static Result OnSuccessFailWhen(
        this Result @this,
        Func<Result> predicateFunc,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        () => OperateWhenExtensions.OperateWhen(predicateFunc().IsSuccess, errorDetail));

    public static Result OnSuccessFailWhen(
        this Result @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        () => OperateWhenExtensions.OperateWhen(predicate.IsSuccess, errorDetail));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate(value).IsSuccess, errorDetail));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate(value).IsSuccess, errorDetailFunc, numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicateFunc().IsSuccess, errorDetail));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFunc,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicateFunc().IsSuccess, errorDetailFunc, numOfTry));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate.IsSuccess, errorDetail));

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Result predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.OnSuccess(
        value => value.OperateWhen(predicate.IsSuccess, errorDetailFunc, numOfTry));
}