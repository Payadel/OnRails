using System.Diagnostics;
using System.Text;
using OnRails.Utilities;

namespace OnRails.ResultDetails;

public class ErrorDetail(
    string title = nameof(ErrorDetail),
    string? message = "An error occurred",
    int? statusCode = 500,
    object? moreDetails = null,
    bool view = false)
    : ResultDetail(title, message, statusCode, moreDetails, view) {
    public List<object> Errors { get; } = [];

    public StackTrace StackTrace { get; } = new StackTrace(1, true)
        .RemoveFrames(Constants.AppNamespace);

    public bool HasErrorTypeOf(Type type) => Errors.Any(error => error.GetType() == type);

    public override string ToString() {
        var sb = new StringBuilder(base.ToString());

        var customFields = CustomFieldsToString();
        if (!string.IsNullOrEmpty(customFields))
            sb.AppendLine(customFields);

        var errors = ErrorsToString();
        if (!string.IsNullOrEmpty(errors))
            sb.AppendLine(errors);

        sb.AppendLine($"StackTrace:\n\t{StackTrace.ToString().Trim()}");

        return sb.ToString();
    }

    protected virtual string? ErrorsToString() {
        if (Errors.Count <= 0) return null;

        var sb = new StringBuilder();

        sb.AppendLine($"Errors ({Errors.Count}):");
        for (var i = 0; i < Errors.Count; i++) {
            if (Errors.Count > 1)
                sb.AppendLine($"\tError {i + 1}:");
            sb.AppendLine($"\t{Errors[i].ToString()?.Trim()}");
        }

        return sb.ToString();
    }

    protected virtual string? CustomFieldsToString() {
        return null;
    }
}