namespace OnRails.ResultDetails.Errors;

public class InternalError(
    string title = nameof(InternalError),
    string? message = "An unexpected condition was encountered while processing the request.",
    object? moreDetails = null,
    bool view = false)
    : ErrorDetail(title, message, 500, moreDetails, view);