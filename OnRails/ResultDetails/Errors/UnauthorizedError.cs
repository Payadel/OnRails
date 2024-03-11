namespace OnRails.ResultDetails.Errors;

public class UnauthorizedError(
    string title = nameof(UnauthorizedError),
    string? message = "Authentication is required to access the requested resource.",
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, 401, exception, moreDetails);