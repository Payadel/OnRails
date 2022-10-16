using OnRail.ResultDetails;

namespace OnRail.Extensions.OnFail;

public static partial class OnFail {
    public static Result<T> OnFailAddMoreDetails<T>(
        this Result<T> source,
        object moreDetail
    ) {
        if (!source.IsSuccess) {
            source.Detail ??= new ErrorDetail();
            source.Detail.AddDetail(moreDetail);
        }

        return source;
    }

    public static Result OnFailAddMoreDetails(
        this Result source,
        object moreDetail) {
        if (!source.IsSuccess) {
            source.Detail ??= new ErrorDetail();
            source.Detail.AddDetail(moreDetail);
        }

        return source;
    }
}