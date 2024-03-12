namespace OnRails.ResultDetails.Errors;

public class ExceptionError : InternalError {
    public ExceptionError(
        Exception exception,
        string title = $"{nameof(ExceptionError)} - An unexpected error occurred.",
        string? message = null,
        object? moreDetails = null) : base(title, message ?? exception.Message, moreDetails: moreDetails) {
        Errors.Add(exception);
    }
}