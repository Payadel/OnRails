using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails;

[DebuggerStepThrough]
public class WarningDetail : ResultDetail {
    public WarningDetail(
        string message,
        string title = nameof(WarningDetail),
        int? statusCode = StatusCodes.Status200OK,
        object? moreDetails = null,
        bool view = false) : base(title, message, statusCode, moreDetails, view) {
        ArgumentNullException.ThrowIfNull(message);
    }
}