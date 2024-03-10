namespace OnRails.ResultDetails.Errors;

public class ExceptionError(
    Exception exception,
    string title = nameof(ExceptionError),
    string? message = null,
    object? moreDetails = null)
    : InternalError(title, message ?? "An exception has occurred.", exception: exception, moreDetails: moreDetails) {
    public Exception MainException { get; } = exception;
}