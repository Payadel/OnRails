using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Errors;

[DebuggerStepThrough]
public class UnauthorizedError(
    string title = nameof(UnauthorizedError),
    string? message = "Authentication is required to access the requested resource.",
    object? moreDetails = null,
    bool view = false)
    : ErrorDetail(title, message, StatusCodes.Status401Unauthorized, moreDetails, view);