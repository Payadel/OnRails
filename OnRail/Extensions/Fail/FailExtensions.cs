using OnRail.ResultDetails;

namespace OnRail.Extensions.Fail;

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

    //TODO: TeeOnFail
    //TODO: TeeOnFail Async
}