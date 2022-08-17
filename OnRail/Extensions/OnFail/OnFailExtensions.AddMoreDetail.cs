using OnRail.Extensions.Fail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Result<T> OnFail<T>(
        this Result<T> @this,
        ErrorDetail errorDetail) =>
        @this.IsSuccess ? @this : @this.Fail(errorDetail);

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Func<ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? @this
        : TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(@this.Fail, numOfTry: 1);

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        object moreDetail
    ) {
        if (!@this.IsSuccess)
            @this.Detail.AddDetail(moreDetail);
        return @this;
    }

    public static Result OnFail(
        this Result @this,
        ErrorDetail errorDetail) =>
        @this.IsSuccess ? @this : @this.Fail(errorDetail);

    public static Result OnFail(
        this Result @this,
        Func<ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? @this
        : TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(@this.Fail, numOfTry: 1);

    public static Result OnFail(
        this Result @this,
        object moreDetail) {
        if (!@this.IsSuccess)
            @this.Detail.AddDetail(moreDetail);
        return @this;
    }

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Func<ResultDetail, ErrorDetail> moreDetail,
        int numOfTry = 1) => @this.IsSuccess
        ? @this
        : TryExtensions.Try(() => moreDetail(@this.Detail), numOfTry)
            .OnSuccess(@this.Fail);
}