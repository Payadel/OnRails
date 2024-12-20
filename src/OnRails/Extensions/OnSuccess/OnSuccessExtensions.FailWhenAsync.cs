using OnRails.Extensions.Fail;
using OnRails.ResultDetails;

namespace OnRails.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> source,
        Func<bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => source.OnSuccess(() => FailExtensions.FailWhen(predicate, errorDetail, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> source,
        bool condition,
        ErrorDetail errorDetail
    ) => source.OnSuccess(() => FailExtensions.FailWhen(condition, errorDetail), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetail, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<T, bool> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetailFunc, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetail, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetailFunc, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(condition, errorDetail), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(condition, errorDetailFunc, numOfTry), numOfTry: 1);

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> source,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(() => FailExtensions.FailWhen(predicate().Success, errorDetail), numOfTry: 1);

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> source,
        Result predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(() => FailExtensions.FailWhen(predicate.Success, errorDetail), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<T, Result> predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetail), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<T, Result> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetailFunc, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(predicate().Success, errorDetail), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Func<Result> predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate, errorDetailFunc, numOfTry), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Result predicate,
        ErrorDetail errorDetail
    ) => source.OnSuccess(t => t.FailWhen(predicate.Success, errorDetail), numOfTry: 1);

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> source,
        Result predicate,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.OnSuccess(t => t.FailWhen(predicate.Success, errorDetailFunc, numOfTry), numOfTry: 1);
}