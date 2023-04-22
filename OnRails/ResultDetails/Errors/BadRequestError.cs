namespace OnRails.ResultDetails.Errors;

public class BadRequestError : ErrorDetail {
    public BadRequestError(string title = nameof(BadRequestError), string? message = null, Exception? exception = null,
        object? moreDetails = null) :
        base(title, message, 400, exception, moreDetails) { }
}