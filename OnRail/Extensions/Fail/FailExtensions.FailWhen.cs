using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.Fail;

//TODO: Test

public static partial class FailExtensions {
    public static Result FailWhen(
        bool condition,
        ErrorDetail? errorDetail
    ) => condition ? Result.Fail(errorDetail) : Result.Ok();

    public static Result FailWhen(
        Func<bool> predicate,
        ErrorDetail? errorDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => FailWhen(condition, errorDetail));

    public static Result FailWhen(
        Result predicate,
        ErrorDetail? errorDetail
    ) => predicate.IsSuccess ? Result.Fail(errorDetail) : Result.Ok();

    public static Result FailWhen(
        Func<Result> predicate,
        ErrorDetail? errorDetail
    ) => FailWhen(predicate().IsSuccess, errorDetail);

    public static Result<T> FailWhen<T>(
        this T source,
        bool condition,
        ErrorDetail? errorDetail
    ) => condition ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source);

    public static Result<T> FailWhen<T>(
        this T source,
        bool condition,
        Func<T, ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => condition
        ? source.Fail(errorDetailFunc, numOfTry)
        : Result<T>.Ok(source);

    public static Result<T> FailWhen<T>(
        this T source,
        Func<T, bool> predicate,
        ErrorDetail? errorDetail,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.FailWhen(condition, errorDetail));

    public static Result<T> FailWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<T, ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.FailWhen(condition, errorDetailFunc));

    public static Result<T> FailWhen<T>(
        this T source,
        Func<bool> predicate,
        ErrorDetail? errorDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.FailWhen(condition, errorDetail));

    public static Result<T> FailWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<T, ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.FailWhen(condition, errorDetailFunc));

    public static Result<T> FailWhen<T>(
        this T source,
        Result predicate,
        ErrorDetail? errorDetail
    ) => predicate.IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source);

    public static Result<T> FailWhen<T>(
        this T source,
        Result predicate,
        Func<T, ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.FailWhen(predicate.IsSuccess, errorDetailFunc, numOfTry);

    public static Result<T> FailWhen<T>(
        this T source,
        Func<Result> predicate,
        ErrorDetail? errorDetail
    ) => source.FailWhen(predicate().IsSuccess, errorDetail);

    public static Result<T> FailWhen<T>(
        this T source,
        Func<Result> predicate,
        Func<T, ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.FailWhen(predicate().IsSuccess, errorDetailFunc, numOfTry);

    public static Result<T> FailWhen<T>(
        this T source,
        Func<T, Result> predicate,
        ErrorDetail? errorDetail
    ) => source.FailWhen(predicate(source), errorDetail);

    public static Result<T> FailWhen<T>(
        this T source,
        Func<T, Result> predicate,
        Func<T, ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.FailWhen(predicate(source).IsSuccess, errorDetailFunc, numOfTry);
}