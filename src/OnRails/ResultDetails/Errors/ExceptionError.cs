namespace OnRails.ResultDetails.Errors;

public class ExceptionError : InternalError {
    public ExceptionError(Exception exception, string title = nameof(ExceptionError),
        string? message = null, object? moreDetails = null) :
        base(title, message ?? "An exception has occurred.", exception: exception, moreDetails: moreDetails) {
        MainException = exception;
    }

    public Exception MainException { get; }
}