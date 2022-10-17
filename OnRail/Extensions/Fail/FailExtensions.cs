using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.Fail;

//TODO: Test

public static partial class FailExtensions {
    public static Result Fail(
        this Result source,
        ErrorDetail? errorDetail
    ) {
        var failResult = Result.Fail(errorDetail);
        if (!source.IsSuccess && source.Detail is not null)
            failResult.Detail!.AddDetail(source.Detail);
        return failResult;
    }

    public static Result<T> Fail<T>(
        this Result<T> source,
        ErrorDetail? errorDetail
    ) {
        var failResult = Result<T>.Fail(errorDetail);
        if (!source.IsSuccess && source.Detail is not null)
            failResult.Detail!.AddDetail(source.Detail);
        return failResult;
    }

    public static Result<T> Fail<T>(this T _, ErrorDetail? errorDetail)
        => Result<T>.Fail(errorDetail);

    public static Result<T> Fail<T>(this T source,
        Func<T, ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => TryExtensions.Try(() => {
        var errorDetail = errorDetailFunc(source);
        return source.Fail(errorDetail);
    }, numOfTry);
}