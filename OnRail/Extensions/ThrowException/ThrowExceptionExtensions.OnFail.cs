namespace OnRail.Extensions.ThrowException;

public static partial class ThrowExceptionExtensions {
    public static Result<T> ThrowExceptionOnFail<T>(this Result<T> @this) {
        if (!@this.IsSuccess)
            @this.Detail.ThrowException();
        return @this;
    }

    public static Result ThrowExceptionOnFail(this Result @this) {
        if (!@this.IsSuccess)
            @this.Detail.ThrowException();
        return @this;
    }
}