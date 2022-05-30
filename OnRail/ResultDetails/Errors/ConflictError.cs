namespace OnRail.ResultDetails.Errors;

public class ConflictError : ErrorDetail {
    public ConflictError(string? title = null, string? message = null, Exception? exception = null,
        object? moreDetails = null) :
        base(title ?? nameof(ConflictError),
            message, 409, exception, moreDetails) { }
}