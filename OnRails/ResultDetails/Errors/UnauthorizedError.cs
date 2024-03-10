namespace OnRails.ResultDetails.Errors;

public class UnauthorizedError(
    string title = nameof(UnauthorizedError),
    string? message = null,
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, 401, exception, moreDetails);