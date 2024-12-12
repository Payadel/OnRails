using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Success;

[DebuggerStepThrough]
public class NotModifiedDetail(
    string title = nameof(NotModifiedDetail),
    string? message = "The resource has not been modified.",
    object? moreDetails = null,
    bool view = true)
    : SuccessDetail(title, message, StatusCodes.Status304NotModified, moreDetails, view);