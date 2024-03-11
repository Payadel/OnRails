namespace OnRails.ResultDetails.Errors;

public class NotFoundError(
    string title = nameof(NotFoundError),
    string? message = "The requested resource could not be found.",
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, 404, exception, moreDetails);