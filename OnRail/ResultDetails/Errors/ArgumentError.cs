namespace OnRail.ResultDetails.Errors;

public class ArgumentError : ErrorDetail {
    public ArgumentError(string title = nameof(ArgumentError), string? message = null, int? statusCode = null,
        Exception? exception = null, object? moreDetails = null) : base(title,
        message ?? "one or more arguments are not valid.", statusCode ?? 400, exception, moreDetails) { }
}