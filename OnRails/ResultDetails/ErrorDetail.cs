using System.Diagnostics;
using System.Text;
using OnRails.Utilities;

namespace OnRails.ResultDetails;

public class ErrorDetail(
    string title = nameof(ErrorDetail),
    string? message = "An error occurred",
    int? statusCode = 500,
    Exception? exception = null,
    object? moreDetails = null)
    : ResultDetail(title, message, statusCode, moreDetails) {
    public List<object> Errors { get; } = [];

    public StackTrace StackTrace { get; } = new StackTrace(1, true)
        .RemoveFrames(Constants.AppNamespace);

    public Exception? Exception { get; } = exception;

    public override string ToString() {
        var sb = new StringBuilder(base.ToString());
        sb.AppendLine();

        var customFields = CustomFieldsToString();
        if (!string.IsNullOrEmpty(customFields))
            sb.AppendLine(customFields);

        var errors = ErrorsToString();
        if (!string.IsNullOrEmpty(errors))
            sb.AppendLine(errors);

        if (Exception is not null)
            sb.AppendLine($"Exception:\n\t{Exception}");

        sb.AppendLine($"StackTrace:\n\t{StackTrace}");
        return sb.ToString();
    }

    protected virtual string ErrorsToString() {
        if (Errors.Count <= 0) return "";

        var sb = new StringBuilder();

        sb.AppendLine($"Errors ({Errors.Count}):");
        for (var i = 0; i < Errors.Count; i++) {
            if (Errors.Count > 1)
                sb.AppendLine($"\tError {i + 1}:");
            sb.AppendLine($"\t\t{Errors[i].ToString()}");
            sb.AppendLine();
        }
        
        return sb.ToString();
    }

    protected virtual string CustomFieldsToString() {
        return "";
    }
}