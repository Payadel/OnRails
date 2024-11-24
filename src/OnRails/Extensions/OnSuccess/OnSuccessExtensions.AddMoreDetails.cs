using OnRails.ResultDetails;

namespace OnRails.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Result<T> OnSuccessAddMoreDetails<T>(
        this Result<T> source,
        object moreDetail
    ) => source.OnSuccess(() => {
        source.Detail ??= new SuccessDetail();
        source.Detail.AddDetail(moreDetail);
        return source;
    });

    public static Result OnSuccessAddMoreDetails(
        this Result source,
        object moreDetail) => source.OnSuccess(() => {
        source.Detail ??= new SuccessDetail();
        source.Detail.AddDetail(moreDetail);
        return source;
    });
}