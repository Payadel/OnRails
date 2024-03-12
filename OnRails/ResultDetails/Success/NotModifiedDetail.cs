namespace OnRails.ResultDetails.Success;

public class NotModifiedDetail(
    string title = nameof(NotModifiedDetail),
    string? message = "The resource has not been modified.",
    object? moreDetails = null,
    bool view = false)
    : SuccessDetail(title, message, 304, moreDetails, view);