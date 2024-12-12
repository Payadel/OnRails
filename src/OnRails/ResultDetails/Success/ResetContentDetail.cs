using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Success;

[DebuggerStepThrough]
public class ResetContentDetail(
    string title = nameof(ResetContentDetail),
    string? message = null,
    object? moreDetails = null,
    bool view = true)
    : SuccessDetail(title, message, StatusCodes.Status205ResetContent, moreDetails, view);