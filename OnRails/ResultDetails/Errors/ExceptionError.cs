namespace OnRails.ResultDetails.Errors;

public class ExceptionError(
    Exception exception,
    string title = $"{nameof(ExceptionError)} - An unexpected error occurred.",
    string? message = null,
    object? moreDetails = null)
    : InternalError(title, message ?? exception.Message, exception: exception, moreDetails: moreDetails) {
    public Exception MainException { get; } = exception;
}