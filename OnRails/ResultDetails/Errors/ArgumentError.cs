namespace OnRails.ResultDetails.Errors;

[Obsolete($"Use {nameof(ValidationError)}")]
public class ArgumentError(
    string title = nameof(ArgumentError),
    string? message = null,
    int? statusCode = null,
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title,
        message ?? "one or more arguments are not valid.", statusCode ?? 400, exception, moreDetails);