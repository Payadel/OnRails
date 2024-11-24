namespace OnRails.ResultDetails.Errors;

public class NotFoundError : ErrorDetail {
    public NotFoundError(string title = nameof(NotFoundError), string? message = null, Exception? exception = null,
        object? moreDetails = null) :
        base(title, message, 404,
            exception, moreDetails) { }
}