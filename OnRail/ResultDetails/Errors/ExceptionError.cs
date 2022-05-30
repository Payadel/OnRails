namespace OnRail.ResultDetails.Errors;

public class ExceptionError : InternalError {
    public ExceptionError(Exception exception, string? title = null,
        string? message = null, object? moreDetails = null) :
        base(title ?? nameof(ExceptionError),
            message ?? "An exception has occurred.", exception: exception, moreDetails: moreDetails) {
        MainException = exception;
    }

    private Exception MainException { get; }

    public Exception GetMainException() => MainException;
}