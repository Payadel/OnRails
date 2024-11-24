using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Task<Result<T>> OnFailAddMoreDetails<T>(
        this Task<Result<T>> source,
        object moreDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => {
            result.Detail ??= new ErrorDetail();
            result.Detail.AddDetail(moreDetail);
            return result;
        });

    public static Task<Result> OnFailAddMoreDetails(
        this Task<Result> source,
        object moreDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => {
            result.Detail ??= new ErrorDetail();
            result.Detail.AddDetail(moreDetail);
            return result;
        });
}