using OnRail.Extensions.OnFail;

namespace OnRail.Extensions.ThrowException;

public static partial class ThrowExceptionExtensions {
    public static Result<T> ThrowExceptionOnFail<T>(
        this Result<T> @this) => @this
        .OnFail(result => result.Detail.ThrowException());

    public static Result ThrowExceptionOnFail(
        this Result @this) => @this
        .OnFail(result => result.Detail.ThrowException());
}