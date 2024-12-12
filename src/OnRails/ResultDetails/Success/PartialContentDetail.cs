using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using OnRails.Models;

namespace OnRails.ResultDetails.Success;

[DebuggerStepThrough]
public class PartialContentDetail(
    RangeData? range = null,
    string title = nameof(PartialContentDetail),
    string? message = "Partial content is returned successfully.",
    int? statusCode = StatusCodes.Status206PartialContent,
    object? moreDetails = null,
    bool view = true)
    : SuccessDetail(title, message, statusCode, moreDetails, view) {
    public RangeData? Range { get; } = range;

    public override Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message },
            { nameof(Range), Range }
        };

    protected override string CustomFieldsToString() =>
        Range is null
            ? string.Empty
            : Range.ToString();
}