using OnRail.Extensions.Fail;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test all methods

public static partial class OnSuccessExtensions {
    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> source,
        Func<bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => source.OnSuccess(() => FailExtensions.FailWhen(predicate, errorDetail, numOfTry));

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> source,
        bool condition,
        ErrorDetail errorDetail
    ) => source.OnSuccess(() => FailExtensions.FailWhen(condition, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetail, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetailFunc, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetail, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetailFunc, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(condition, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(condition, errorDetailFunc, numOfTry));

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> source,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(() => FailExtensions.FailWhen(predicate().IsSuccess, errorDetail));

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> source,
        Result predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(() => FailExtensions.FailWhen(predicate.IsSuccess, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<T, Result> predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetail));

    //TODO: numOfTry
    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<T, Result> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetailFunc));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(predicate().IsSuccess, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<Result> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetailFunc, numOfTry));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Result predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(predicate.IsSuccess, errorDetail));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Result predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate.IsSuccess, errorDetailFunc, numOfTry));
}