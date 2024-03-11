namespace OnRails.ResultDetails.Errors;

public class NotImplementedError(
    string title = nameof(NotImplementedError),
    string? message = "The requested functionality is not implemented.",
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, 501, exception, moreDetails);