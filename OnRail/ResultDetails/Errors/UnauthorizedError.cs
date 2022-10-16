namespace OnRail.ResultDetails.Errors;

public class UnauthorizedError : ErrorDetail {
    public UnauthorizedError(string title = nameof(UnauthorizedError), string? message = null,
        Exception? exception = null,
        object? moreDetails = null) :
        base(title, message, 401, exception, moreDetails) { }
}