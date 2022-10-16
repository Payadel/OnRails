namespace OnRail.ResultDetails.Errors;

public class ForbiddenError : ErrorDetail {
    public ForbiddenError(string title = nameof(ForbiddenError), string? message = null, Exception? exception = null,
        object? moreDetails = null) :
        base(title, message, 403, exception, moreDetails) { }
}