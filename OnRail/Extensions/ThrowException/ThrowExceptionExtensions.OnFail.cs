using OnRail.ResultDetails;

namespace OnRail.Extensions.ThrowException;

public static partial class ThrowExceptionExtensions {
    public static Result<T> ThrowExceptionOnFail<T>(this Result<T> source) {
        if (!source.IsSuccess) {
            source.Detail ??= new ErrorDetail();
            source.Detail.ThrowException();
        }

        return source;
    }

    public static Result ThrowExceptionOnFail(this Result source) {
        if (!source.IsSuccess) {
            source.Detail ??= new ErrorDetail();
            source.Detail.ThrowException();
        }

        return source;
    }
}