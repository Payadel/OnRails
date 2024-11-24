namespace OnRails.ResultDetails.Errors;

public class ConflictError : ErrorDetail {
    public ConflictError(string title = nameof(ConflictError), string? message = null, Exception? exception = null,
        object? moreDetails = null) :
        base(title, message, 409, exception, moreDetails) { }
}