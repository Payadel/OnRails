using OnRail.ResultDetails;
using OnRail.Extensions.Fail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Result<T> OnFail<T>(
        this Result<T> source,
        ErrorDetail? newErrorDetail
    ) => source.IsSuccess ? source : source.Fail(newErrorDetail);

    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(errorDetail => source.Fail(errorDetail));

    public static Result OnFail(
        this Result source,
        ErrorDetail? newErrorDetail
    ) => source.IsSuccess ? source : source.Fail(newErrorDetail);

    public static Result OnFail(
        this Result source,
        Func<ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(errorDetail => source.Fail(errorDetail));

    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<Result<T>, ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : source.Try(errorDetailFunc, numOfTry)
            .OnSuccess(errorDetail => source.Fail(errorDetail));
}