using System.Text.Json;
using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions;

public static class ThrowExceptionExtensions {
    #region ThrowException

    public static void ThrowException(this ResultDetail @this) {
        throw @this
            switch {
                ExceptionError exceptionError when exceptionError.Exception != null => exceptionError
                    .GetMainException(),
                ErrorDetail errorDetail => new Exception(JsonSerializer.Serialize(errorDetail)),
                _ => new Exception(JsonSerializer.Serialize(@this)),
            };
    }

    public static void ThrowException<T>(
        this T _,
        ResultDetail resultDetail) => resultDetail.ThrowException();

    #endregion

    #region ThrowExceptionOnFail

    public static Result<T> ThrowExceptionOnFail<T>(
        this Result<T> @this,
        Action? exception = null) => @this
        .OnFail(_ => _
            .Tee(exception)
            .Tee(() => ThrowException(@this.Detail)));

    public static Result ThrowExceptionOnFail(
        this Result @this,
        Action? exception = null) => @this
        .OnFail(_ => _
            .Tee(exception)
            .Tee(() => ThrowException(@this.Detail)));

    #endregion
}