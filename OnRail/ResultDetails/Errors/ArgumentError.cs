namespace OnRail.ResultDetails.Errors;

public class ArgumentError : ErrorDetail {
    public ArgumentError(string? title = null, string? message = null, int? statusCode = null,
        Exception? exception = null, object? moreDetails = null) : base(title ?? nameof(ArgumentError),
        message ?? "one or more arguments are not valid.", statusCode ?? 400, exception, moreDetails) { }
}