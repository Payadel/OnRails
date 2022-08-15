using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.Fail;

//TODO: Test

public static partial class FailExtensions {
    public static Result Fail(
        this Result @this,
        ErrorDetail errorDetail
    ) {
        var failResult = Result.Fail(errorDetail);
        if (!@this.IsSuccess)
            failResult.Detail.AddDetail(@this.Detail);
        return failResult;
    }

    public static Result<T> Fail<T>(
        this Result<T> @this,
        ErrorDetail errorDetail
    ) {
        var failResult = Result<T>.Fail(errorDetail);
        if (!@this.IsSuccess)
            failResult.Detail.AddDetail(@this.Detail);
        return failResult;
    }

    public static Result<T> Fail<T>(this T @this,
        ErrorDetail errorDetail) => Result<T>.Fail(errorDetail);

    public static Result<T> Fail<T>(this T @this,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1) => @this.Try(errorDetailFunc, numOfTry)
        .OnSuccess(errorDetail => @this.Fail(errorDetail));
}