namespace OnRails.ResultDetails.Errors;

public class ConflictError(
    string title = nameof(ConflictError),
    string? message = null,
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, 409, exception, moreDetails);