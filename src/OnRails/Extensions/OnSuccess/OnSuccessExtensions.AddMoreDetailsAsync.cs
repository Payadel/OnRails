using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Task<Result<T>> OnSuccessAddMoreDetails<T>(
        this Task<Result<T>> source,
        object moreDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess((_, result) => {
            result.Detail ??= new ErrorDetail();
            result.Detail.AddDetail(moreDetail);
            return result;
        });

    public static Task<Result> OnSuccessAddMoreDetails(
        this Task<Result> source,
        object moreDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(result => {
            result.Detail ??= new ErrorDetail();
            result.Detail.AddDetail(moreDetail);
            return result;
        });
}