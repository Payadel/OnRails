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
        : TryExtensions.Try(() => {
            var errorDetail = errorDetailFunc();
            return source.Fail(errorDetail);
        }, numOfTry);

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
}