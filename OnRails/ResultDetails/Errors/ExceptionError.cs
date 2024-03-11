namespace OnRails.ResultDetails.Errors;

public class ExceptionError(
    Exception exception,
    string title = nameof(ExceptionError),
    string? message = "An unexpected error occurred.",
    object? moreDetails = null)
    : InternalError(title, message, exception: exception, moreDetails: moreDetails) {
    public Exception MainException { get; } = exception;
}