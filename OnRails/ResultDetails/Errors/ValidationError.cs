using OnRails.Utilities;

namespace OnRails.ResultDetails.Errors;

public class ValidationError : BadRequestError {
    public ValidationError(
        string errorKey,
        object? errorValue,
        string title = nameof(ValidationError),
        string? message = "One or more validation errors occurred.",
        int? statusCode = 400,
        object? moreDetails = null,
        bool view = false) : base(errorKey, errorValue, title, message, statusCode, moreDetails,
        view) { }

    public ValidationError(
        List<KeyValue<object?>> errors,
        string title = nameof(ValidationError),
        string? message = "One or more validation errors occurred.",
        int? statusCode = 400,
        object? moreDetails = null,
        bool view = false) : base(errors, title, message, statusCode, moreDetails, view) { }
}