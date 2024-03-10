using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails.Extensions.Fail;

public static partial class FailExtensions {
    public static Result Fail(
        this Result source,
        ErrorDetail? errorDetail,
        int numOfTry = 1
    ) {
        var failResult = Result.Fail(errorDetail);
        if (source is { Success: false, Detail: not null }) {
            return TryExtensions.Try(() => {
                failResult.Detail!.AddDetail(source.Detail);
                return failResult;
            }, numOfTry);
        }

        return failResult;
    }

    public static Result<T> Fail<T>(
        this Result<T> source,
        ErrorDetail? errorDetail,
        int numOfTry = 1
    ) {
        var failResult = Result<T>.Fail(errorDetail);
        if (source is { Success: false, Detail: not null }) {
            return TryExtensions.Try(() => {
                failResult.Detail!.AddDetail(source.Detail);
                return failResult;
            }, numOfTry);
        }

        return failResult;
    }

    public static Result<T> Fail<T>(this T source,
        Func<T, ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => TryExtensions.Try(() => errorDetailFunc(source), numOfTry)
        .OnSuccess(Result<T>.Fail);
}