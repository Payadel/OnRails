namespace OnRails.ResultDetails.Errors;

public class ForbiddenError(
    string title = nameof(ForbiddenError),
    string? message = "You don't have permission to access the requested resource.",
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, 403, exception, moreDetails);