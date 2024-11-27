using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Errors.Internal;

[DebuggerStepThrough]
public class InternalError(
    string title = nameof(InternalError),
    string? message = "An unexpected condition was encountered while processing the request.",
    int? statusCode = StatusCodes.Status500InternalServerError,
    object? moreDetails = null,
    bool view = false)
    : ErrorDetail(title, message, statusCode, moreDetails, view);