using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.AddMoreDetails;

public static partial class AddMoreDetails {
    public static async Task<Result<T>> OnFailAddMoreDetails<T>(
        this Task<Result<T>> source,
        object moreDetail,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (!result.IsSuccess) {
            result.Detail ??= new ErrorDetail();
            result.Detail.AddDetail(moreDetail);
        }

        return result;
    }

    public static async Task<Result> OnFailAddMoreDetails(
        this Task<Result> source,
        object moreDetail,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        if (!result.IsSuccess) {
            result.Detail ??= new ErrorDetail();
            result.Detail.AddDetail(moreDetail);
        }

        return result;
    }
}