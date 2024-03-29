using OnRails.Extensions.Fail;
using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Result<T> OnFail<T>(
        this Result<T> source,
        ErrorDetail? newErrorDetail
    ) => source.Success ? source : source.Fail(newErrorDetail);

    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.Success
        ? source
        : TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(errorDetail => source.Fail(errorDetail));

    public static Result OnFail(
        this Result source,
        ErrorDetail? newErrorDetail
    ) => source.Success ? source : source.Fail(newErrorDetail);

    public static Result OnFail(
        this Result source,
        Func<ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.Success
        ? source
        : TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(errorDetail => source.Fail(errorDetail));

    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<Result<T>, ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => source.Success
        ? source
        : source.Try(errorDetailFunc, numOfTry)
            .OnSuccess(errorDetail => source.Fail(errorDetail));
}