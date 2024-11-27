using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails;

[DebuggerStepThrough]
public class WarningDetail : ResultDetail {
    private const string DefaultTitle = nameof(WarningDetail);
    private const int DefaultStatusCode = StatusCodes.Status200OK;

    public WarningDetail(string message) : base(title: DefaultTitle, message: message, statusCode: DefaultStatusCode) {
        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentNullException(nameof(message));
    }

    public WarningDetail(
        string message,
        string? title = DefaultTitle,
        int? statusCode = DefaultStatusCode,
        object? moreDetails = null,
        bool view = false) : base(title ?? DefaultTitle, message, statusCode, moreDetails, view) {
        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentNullException(nameof(message));
    }
}