namespace OnRails.ResultDetails.Success;

public class PartialContentDetail(
    string title = nameof(PartialContentDetail),
    string? message = null,
    object? moreDetails = null)
    : SuccessDetail(title, message, 206, moreDetails);