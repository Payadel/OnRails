using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Success.Created;

[DebuggerStepThrough]
public class CreatedDetail(
    string? title = nameof(CreatedDetail),
    string? message = "Resource successfully created.",
    object? moreDetail = null,
    bool? view = null)
    : SuccessDetail(title ?? nameof(CreatedDetail), message, StatusCodes.Status201Created, moreDetail, view ?? true) {
    public override Dictionary<string, object?> GetViewModel() => new();
}