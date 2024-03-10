namespace OnRails.ResultDetails.Errors;

public class ForbiddenError(
    string title = nameof(ForbiddenError),
    string? message = null,
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, 403, exception, moreDetails);