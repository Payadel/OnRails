using OnRails.ResultDetails;

namespace OnRails.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Result OnSuccess(this Result source, SuccessDetail newDetail) =>
        source.IsSuccess ? Result.Ok(newDetail) : source;

    public static Result<T> OnSuccess<T>(this Result<T> source, SuccessDetail newDetail) =>
        source.IsSuccess ? Result<T>.Ok(source.Value!, newDetail) : source;
}