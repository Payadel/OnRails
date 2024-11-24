using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Success.Accepted;

[DebuggerStepThrough]
public class AcceptedDetail(
    string? title = null,
    string? message = null,
    object? moreDetail = null,
    bool? view = null)
    : SuccessDetail(title ?? nameof(AcceptedDetail), message, StatusCodes.Status202Accepted, moreDetail,
        view ?? true) { }