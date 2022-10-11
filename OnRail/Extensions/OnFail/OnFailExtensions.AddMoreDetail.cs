using OnRail.Extensions.Fail;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Result<T> OnFail<T>(
        this Result<T> source,
        ErrorDetail errorDetail
    ) => source.IsSuccess ? source : source.Fail(errorDetail);

    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : TryExtensions.Try(() => {
            var errorDetail = errorDetailFunc();
            return source.Fail(errorDetail);
        }, numOfTry);

    public static Result<T> OnFail<T>(
        this Result<T> source,
        object moreDetail
    ) {
        if (!source.IsSuccess) {
            source.Detail ??= new ErrorDetail();
            source.Detail.AddDetail(moreDetail);
        }

        return source;
    }

    public static Result OnFail(
        this Result source,
        ErrorDetail errorDetail
    ) => source.IsSuccess ? source : source.Fail(errorDetail);

    public static Result OnFail(
        this Result source,
        Func<ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : TryExtensions.Try(() => {
            var errorDetail = errorDetailFunc();
            return source.Fail(errorDetail);
        }, numOfTry);

    public static Result OnFail(
        this Result source,
        object moreDetail) {
        if (!source.IsSuccess) {
            source.Detail ??= new ErrorDetail();
            source.Detail.AddDetail(moreDetail);
        }

        return source;
    }

    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<ResultDetail?, ErrorDetail> moreDetailFunc,
        int numOfTry = 1
    ) => source.IsSuccess
        ? source
        : TryExtensions.Try(() => source.Fail(moreDetailFunc(source.Detail)), numOfTry);
}