namespace OnRail.Extensions.ThrowException;

public static partial class ThrowExceptionExtensions {
    public static Result<T> ThrowExceptionOnFail<T>(
        this Result<T> @this,
        Exception? exception = null) => @this
        .OnFail(result => {
            if (exception is not null)
                throw exception;

            result.Detail.ThrowException();
        });

    public static Result ThrowExceptionOnFail(
        this Result @this,
        Exception? exception = null) => @this
        .OnFail(result => {
            if (exception is not null)
                throw exception;

            result.Detail.ThrowException();
        });
}