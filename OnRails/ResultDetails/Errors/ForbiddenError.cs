using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Errors;

[DebuggerStepThrough]
public class ForbiddenError(
    string title = nameof(ForbiddenError),
    string? message = "You don't have permission to access the requested resource.",
    object? moreDetails = null,
    bool view = false)
    : ErrorDetail(title, message, StatusCodes.Status403Forbidden, moreDetails, view);