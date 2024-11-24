namespace OnRails.ResultDetails.Errors;

public class InternalError : ErrorDetail {
    public InternalError(string title = nameof(InternalError), string? message = null,
        Exception? exception = null,
        object? moreDetails = null) : base(
        title, message, 500, exception, moreDetails) { }
}