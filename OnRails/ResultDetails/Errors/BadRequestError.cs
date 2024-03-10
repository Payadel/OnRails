namespace OnRails.ResultDetails.Errors;

public class BadRequestError(
    string title = nameof(BadRequestError),
    string? message = null,
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, 400, exception, moreDetails);