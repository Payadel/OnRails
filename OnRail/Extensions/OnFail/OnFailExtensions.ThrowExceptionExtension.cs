using OnRail.Extensions.ThrowException;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Result<T> OnFailThrowException<T>(this Result<T> source) {
        if (!source.IsSuccess) {
            source.Detail ??= new ErrorDetail();
            source.Detail.ThrowException();
        }

        return source;
    }

    public static Result OnFailThrowException(this Result source) {
        if (!source.IsSuccess) {
            source.Detail ??= new ErrorDetail();
            source.Detail.ThrowException();
        }

        return source;
    }
}