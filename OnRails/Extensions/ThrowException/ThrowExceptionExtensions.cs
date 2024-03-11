using System.Diagnostics;
using System.Text.Json;
using OnRails.ResultDetails;
using OnRails.ResultDetails.Errors;

namespace OnRails.Extensions.ThrowException;

[DebuggerStepThrough]
public static class ThrowExceptionExtensions {
    private static Exception GenerateException(ResultDetail resultDetail) {
        Exception? innerException;
        switch (resultDetail) {
            case ExceptionError { Exception: not null } exceptionError:
                innerException = exceptionError.MainException;
                break;
            case ErrorDetail errorDetail:
                errorDetail.AddDetail(new { MainStackTrace = errorDetail.StackTrace.ToString() });
                innerException = new Exception(JsonSerializer.Serialize(errorDetail));
                break;
            default:
                innerException = new Exception(JsonSerializer.Serialize(resultDetail));
                break;
        }

        return new Exception("Throw Exception Has been requested", innerException);
    }

    #region ThrowException

    public static void ThrowException(this ResultDetail source) =>
        throw GenerateException(source);

    public static void ThrowException<T>(
        this T _,
        ResultDetail resultDetail) => resultDetail.ThrowException();

    #endregion
}