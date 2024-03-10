namespace OnRails.ResultDetails.Success;

public class NotModifiedDetail(
    string title = nameof(NotModifiedDetail),
    string? message = null,
    object? moreDetails = null)
    : SuccessDetail(title, message, 304, moreDetails);