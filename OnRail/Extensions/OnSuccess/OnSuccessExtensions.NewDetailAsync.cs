using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Task<Result> OnSuccess(this Task<Result> source, SuccessDetail newDetail, int numOfTry = 1) =>
        TryExtensions.Try(source, numOfTry)
            .OnSuccess(() => Result.Ok(newDetail));

    public static Task<Result<T>>
        OnSuccess<T>(this Task<Result<T>> source, SuccessDetail newDetail, int numOfTry = 1) =>
        TryExtensions.Try(source, numOfTry)
            .OnSuccess(value => Result<T>.Ok(value, newDetail));
}