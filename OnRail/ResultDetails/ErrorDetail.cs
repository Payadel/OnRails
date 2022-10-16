using System.Diagnostics;

namespace OnRail.ResultDetails;

public class ErrorDetail : ResultDetail {
    public ErrorDetail(string title = nameof(ErrorDetail), string? message = null, int? statusCode = null,
        Exception? exception = null, object? moreDetails = null) : base(
        title, message, statusCode, moreDetails) {
        if (exception != null)
            Exception = new ExceptionData(exception);
    }

    public StackTrace StackTrace { get; } = new(1, true);
    public ExceptionData? Exception { get; }
}