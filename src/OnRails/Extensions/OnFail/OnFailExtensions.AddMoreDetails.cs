using OnRails.ResultDetails;

namespace OnRails.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Result<T> OnFailAddMoreDetails<T>(
        this Result<T> source,
        object moreDetail
    ) => source.OnFail(() => {
        source.Detail ??= new ErrorDetail();
        source.Detail.AddDetail(moreDetail);
        return source;
    });

    public static Result OnFailAddMoreDetails(
        this Result source,
        object moreDetail) => source.OnFail(() => {
            source.Detail ??= new ErrorDetail();
            source.Detail.AddDetail(moreDetail);
            return source;
        });
}