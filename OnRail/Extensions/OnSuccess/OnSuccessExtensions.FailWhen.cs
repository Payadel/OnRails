using OnRail.Extensions.Fail;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test all methods

public static partial class OnSuccessExtensions {
    public static Result OnSuccessFailWhen(
        this Result source,
        Func<bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => source.OnSuccess(() => FailExtensions.FailWhen(predicate, errorDetail, numOfTry), numOfTry: 1);

    public static Result OnSuccessFailWhen(
        this Result source,
        bool condition,
        ErrorDetail errorDetail
    ) => source.OnSuccess(() => FailExtensions.FailWhen(condition, errorDetail), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        Func<T, bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetail, numOfTry), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        Func<T, bool> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetailFunc, numOfTry), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetail, numOfTry), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetailFunc, numOfTry), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        bool condition,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(condition, errorDetail), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        bool condition,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(condition, errorDetailFunc, numOfTry), numOfTry: 1);

    public static Result OnSuccessFailWhen(
        this Result source,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(() => FailExtensions.FailWhen(predicate().IsSuccess, errorDetail), numOfTry: 1);

    public static Result OnSuccessFailWhen(
        this Result source,
        Result predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(() => FailExtensions.FailWhen(predicate.IsSuccess, errorDetail), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        Func<T, Result> predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(predicate(t).IsSuccess, errorDetail), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        Func<T, Result> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate(t).IsSuccess, errorDetailFunc, numOfTry), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(predicate().IsSuccess, errorDetail), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        Func<Result> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate().IsSuccess, errorDetailFunc, numOfTry), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        Result predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(predicate.IsSuccess, errorDetail), numOfTry: 1);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> source,
        Result predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate.IsSuccess, errorDetailFunc, numOfTry), numOfTry: 1);
}