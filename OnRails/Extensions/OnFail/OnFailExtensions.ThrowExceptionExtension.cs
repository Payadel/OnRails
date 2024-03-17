using OnRails.Extensions.ThrowException;
using OnRails.ResultDetails;

namespace OnRails.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Result<T> OnFailThrowException<T>(this Result<T> source) {
        if (!source.Success) {
            source.Detail ??= new ErrorDetail();
            source.Detail.ThrowException();
        }

        return source;
    }

    public static Result OnFailThrowException(this Result source) {
        if (!source.Success) {
            source.Detail ??= new ErrorDetail();
            source.Detail.ThrowException();
        }

        return source;
    }

    public static Task<Result<T>> OnFailThrowException<T>(this Task<Result<T>> source) =>
        source.OnFail(result => {
            if (!result.Success) {
                result.Detail ??= new ErrorDetail();
                result.Detail.ThrowException();
            }

            return result;
        });

    public static Task<Result> OnFailThrowException(this Task<Result> source) =>
        source.OnFail(result => {
            if (!result.Success) {
                result.Detail ??= new ErrorDetail();
                result.Detail.ThrowException();
            }

            return result;
        });
}