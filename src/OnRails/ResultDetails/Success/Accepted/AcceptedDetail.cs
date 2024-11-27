using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Success.Accepted;

[DebuggerStepThrough]
public class AcceptedDetail(
    string? title = nameof(AcceptedDetail),
    string? message = "Request has been accepted for processing, but the processing is not yet complete.",
    object? moreDetail = null,
    bool? view = null)
    : SuccessDetail(title ?? nameof(AcceptedDetail), message, StatusCodes.Status202Accepted, moreDetail,
        view ?? true);