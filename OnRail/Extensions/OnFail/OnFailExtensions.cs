using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result<T> OnFail<T>(
        this Result<T> source,
        ErrorDetail? errorDetail
    ) => source.IsSuccess ? source : source.Fail(errorDetail);

    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : TryExtensions.Try(() => {
            var errorDetail = errorDetailFunc();
            return source.Fail(errorDetail);
        }, numOfTry);

    public static Result OnFail(
        this Result source,
        ErrorDetail? errorDetail
    ) => source.IsSuccess ? source : source.Fail(errorDetail);

    public static Result OnFail(
        this Result source,
        Func<ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : TryExtensions.Try(() => {
            var errorDetail = errorDetailFunc();
            return source.Fail(errorDetail);
        }, numOfTry);

    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<Result<T>, ErrorDetail?> moreDetailFunc,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : TryExtensions.Try(() => {
            var errorDetail = moreDetailFunc(source);
            return source.Fail(errorDetail);
        }, numOfTry);

    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : source.Try(function, numOfTry);

    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<Result<T>> function,
        int numOfTry = 1) => source.IsSuccess
        ? source
        : TryExtensions.Try(function, numOfTry);

    public static Result OnFail(
        this Result source,
        Func<Result, Result> function,
        int numOfTry = 1) => source.IsSuccess
        ? source
        : source.Try(function, numOfTry);

    public static Result OnFail(
        this Result source,
        Func<Result> function,
        int numOfTry = 1) => source.IsSuccess
        ? source
        : TryExtensions.Try(function, numOfTry);

    public static Result OnFail(
        this Result source,
        Action action,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : TryExtensions.Try(action, numOfTry);

    public static Result OnFail(
        this Result source,
        Action<Result> action,
        int numOfTry = 1) => source.IsSuccess
        ? source
        : source.Try(action, numOfTry);
}