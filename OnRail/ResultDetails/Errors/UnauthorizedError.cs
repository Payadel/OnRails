namespace OnRail.ResultDetails.Errors;

public class UnauthorizedError : ErrorDetail {
    public UnauthorizedError(string? title = null, string? message = null, Exception? exception = null,
        object? moreDetails = null) :
        base(title ?? nameof(UnauthorizedError),
            message, 401, exception, moreDetails) { }
}