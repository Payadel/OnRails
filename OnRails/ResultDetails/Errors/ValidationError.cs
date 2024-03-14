using OnRails.Utilities;

namespace OnRails.ResultDetails.Errors;

public class ValidationError : BadRequestError {
    public ValidationError(
        List<KeyValue> errors,
        string title = nameof(ValidationError),
        string? message = "One or more validation errors occurred.",
        int? statusCode = 400,
        object? moreDetails = null,
        bool view = false) : base(errors, title, message, statusCode, moreDetails, view) { }

    public ValidationError(
        KeyValue error,
        string title = nameof(ValidationError),
        string? message = "One or more validation errors occurred.",
        int? statusCode = 400,
        object? moreDetails = null,
        bool view = false) : base(error, title, message, statusCode, moreDetails, view) { }
}