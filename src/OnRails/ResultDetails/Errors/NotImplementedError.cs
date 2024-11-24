using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Errors;

[DebuggerStepThrough]
public class NotImplementedError(
    string title = nameof(NotImplementedError),
    string? message = "The requested functionality is not implemented.",
    object? moreDetails = null,
    bool view = false)
    : ErrorDetail(title, message, StatusCodes.Status501NotImplemented, moreDetails, view);