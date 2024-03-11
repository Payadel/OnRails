using System.Diagnostics;
using System.Text;

namespace OnRails.ResultDetails;

public class ErrorDetail(
    string title = nameof(ErrorDetail),
    string? message = "An error occurred",
    int? statusCode = 500,
    Exception? exception = null,
    object? moreDetails = null)
    : ResultDetail(title, message, statusCode, moreDetails) {
    public List<KeyValuePair<string, string>> Errors { get; } = [];
    public StackTrace StackTrace { get; } = new(1, true);
    public Exception? Exception { get; } = exception;

    public override string ToString() {
        var sb = new StringBuilder(base.ToString());

        if (Errors.Count > 0) {
            sb.AppendLine("Errors:\n");
            foreach (var (key, value) in Errors)
                sb.AppendLine($"\t{key}:\t{value}");
        }

        if (Exception is not null)
            sb.AppendLine($"Exception:\n\t{Exception}");

        sb.AppendLine($"StackTrace:\n\t{StackTrace}");
        return sb.ToString();
    }
}