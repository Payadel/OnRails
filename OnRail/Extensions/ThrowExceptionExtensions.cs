using System.Text.Json;
using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions;

public static class ThrowExceptionExtensions {
    private static Exception GenerateException(ResultDetail resultDetail) {
        Exception? innerException;
        switch (resultDetail) {
            case ExceptionError {Exception: { }} exceptionError:
                innerException = exceptionError.MainException;
                break;
            case ErrorDetail errorDetail:
                errorDetail.AddDetail(new {MainStackTrace = errorDetail.StackTrace.ToString()});
                innerException = new Exception(JsonSerializer.Serialize(errorDetail));
                break;
            default:
                innerException = new Exception(JsonSerializer.Serialize(resultDetail));
                break;
        }

        return new Exception("Throw Exception Has been requested", innerException);
    }

    #region ThrowException

    public static void ThrowException(this ResultDetail @this) =>
        throw GenerateException(@this);

    public static void ThrowException<T>(
        this T _,
        ResultDetail resultDetail) => resultDetail.ThrowException();

    #endregion

    #region ThrowExceptionOnFail

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

    #endregion
}