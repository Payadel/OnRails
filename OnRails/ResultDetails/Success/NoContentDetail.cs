using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Success;

[DebuggerStepThrough]
public class NoContentDetail(
    string title = nameof(NoContentDetail),
    string? message = null,
    object? moreDetails = null,
    bool view = true)
    : SuccessDetail(title, message, StatusCodes.Status204NoContent, moreDetails, view);