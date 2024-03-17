using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Success.Created;

[DebuggerStepThrough]
public class CreatedDetail(
    string? title = null,
    string? message = null,
    object? moreDetail = null,
    bool? view = null)
    : SuccessDetail(title ?? nameof(CreatedDetail), message, StatusCodes.Status201Created, moreDetail, view ?? true) {
    public override Dictionary<string, object?> GetViewModel() => new();
}