using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test

public static partial class OnSuccessExtensions {
    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> source,
        TResult successResult
    ) => source.IsSuccess
        ? Result<TResult>.Ok(successResult)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static Result<TResult> OnSuccess<TResult>(
        this Result source,
        TResult successResult
    ) => source.IsSuccess
        ? Result<TResult>.Ok(successResult)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source.Value!.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> source,
        Func<Result<TResult>> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static Result<TResult> OnSuccess<TResult>(
        this Result source,
        Func<Result<TResult>> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);


    public static Result OnSuccess<TSource>(
        this Result<TSource> source,
        Func<TSource, Result> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source.Value!.Try(function, numOfTry)
        : Result.Fail(source.Detail as ErrorDetail);


    public static Result OnSuccess<TSource>(
        this Result<TSource> source,
        Func<Result> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? TryExtensions.Try(function, numOfTry)
        : Result.Fail(source.Detail as ErrorDetail);


    public static Result OnSuccess(
        this Result source,
        Func<Result> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? TryExtensions.Try(function, numOfTry)
        : Result.Fail(source.Detail as ErrorDetail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source.Value!.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> source,
        Func<TResult> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);


    public static Result<TResult> OnSuccess<TResult>(
        this Result source,
        Func<TResult> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? TryExtensions.Try(function, numOfTry)
        : Result<TResult>.Fail(source.Detail as ErrorDetail);


    public static Result OnSuccess<TSource>(
        this Result<TSource> source,
        Action<TSource> action,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source.Value!.Try(action, numOfTry)
        : Result.Fail(source.Detail as ErrorDetail);

    public static Result OnSuccess<TSource>(
        this Result<TSource> source,
        Action action,
        int numOfTry = 1) =>
        source.IsSuccess
            ? TryExtensions.Try(action, numOfTry)
            : Result.Fail(source.Detail as ErrorDetail);

    public static Result OnSuccess(
        this Result source,
        Action action,
        int numOfTry = 1) =>
        source.IsSuccess
            ? TryExtensions.Try(action, numOfTry)
            : Result.Fail(source.Detail as ErrorDetail);
}