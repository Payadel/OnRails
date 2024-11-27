using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using OnRails.Helpers;

namespace OnRails.ResultDetails;

[DebuggerStepThrough]
public class ErrorDetail(
    string title = nameof(ErrorDetail),
    string? message = "An error occurred",
    int? statusCode = StatusCodes.Status500InternalServerError,
    object? moreDetails = null,
    bool view = false)
    : ResultDetail(title, message, statusCode, moreDetails, view) {
    public StackTrace StackTrace { get; } = new StackTrace(1, true)
        .RemoveFrames(AppNamespace.GetLibraryNamespace());

    public override string ToString() {
        var sb = new StringBuilder(base.ToString());

        sb.AppendLine($"StackTrace:\n\t{StackTrace.ToString().Trim()}");
        return sb.ToString();
    }
}