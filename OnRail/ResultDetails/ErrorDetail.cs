using System.Diagnostics;
using System.Text;

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

    public override string ToString() {
        var sb = new StringBuilder(base.ToString());
        if (Exception is not null)
            sb.AppendLine($"Exception:\n\t{Exception}");
        sb.AppendLine($"StackTrace:\n\t{StackTrace}");
        return sb.ToString();
    }
}