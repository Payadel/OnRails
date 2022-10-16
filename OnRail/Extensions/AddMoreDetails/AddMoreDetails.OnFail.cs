using OnRail.ResultDetails;

namespace OnRail.Extensions.AddMoreDetails;

public static partial class AddMoreDetails {
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