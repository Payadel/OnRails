namespace OnRail.ResultDetails.Errors;

public class NotImplementedError : ErrorDetail {
    public NotImplementedError(string title = nameof(NotImplementedError), string? message = null,
        Exception? exception = null, object? moreDetails = null) :
        base(title, message, 501, exception, moreDetails) { }
}