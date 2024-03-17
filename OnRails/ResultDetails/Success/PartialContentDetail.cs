using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Success;

[DebuggerStepThrough]
public class PartialContentDetail(
    string title = nameof(PartialContentDetail),
    string? message = "Partial content is returned successfully.",
    object? moreDetails = null,
    bool view = true)
    : SuccessDetail(title, message, StatusCodes.Status206PartialContent, moreDetails, view);