using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using OnRails.Models;

namespace OnRails.ResultDetails.Errors.BadRequest;

[DebuggerStepThrough]
public class ValidationError : BadRequestError {
    public ValidationError(
        string errorKey,
        object? errorValue,
        string title = nameof(ValidationError),
        string? message = "One or more validation errors occurred.",
        int? statusCode = StatusCodes.Status400BadRequest,
        object? moreDetails = null,
        bool view = false) : base(errorKey, errorValue, title, message, statusCode, moreDetails,
        view) { }

    public ValidationError(
        List<KeyValue<object?>> errors,
        string title = nameof(ValidationError),
        string? message = "One or more validation errors occurred.",
        int? statusCode = StatusCodes.Status400BadRequest,
        object? moreDetails = null,
        bool view = false) : base(errors, title, message, statusCode, moreDetails, view) { }
}