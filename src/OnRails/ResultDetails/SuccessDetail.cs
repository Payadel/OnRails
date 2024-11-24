using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails;

[DebuggerStepThrough]
public class SuccessDetail(
    string title = nameof(SuccessDetail),
    string? message = "Operation was successful",
    int? statusCode = StatusCodes.Status200OK,
    object? moreDetails = null,
    bool view = false)
    : ResultDetail(title, message, statusCode, moreDetails, view);