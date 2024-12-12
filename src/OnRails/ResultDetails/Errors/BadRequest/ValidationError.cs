using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Errors.BadRequest;

[DebuggerStepThrough]
public class ValidationError : BadRequestError {
    private const string DefaultTitle = nameof(ValidationError);
    private const int DefaultStatusCode = StatusCodes.Status400BadRequest;

    private const string DefaultMessage =
        "One or more validation errors occurred.";

    public ValidationError(
        string fieldName,
        string fieldMessage,
        bool view = false) : base(title: DefaultTitle, message: DefaultMessage, statusCode: DefaultStatusCode,
        moreDetails: null, view: view) {
        Errors.Add(fieldName, [fieldMessage]);
    }

    public ValidationError(Dictionary<string, string>? errors = null,
        string title = DefaultTitle,
        string? message = DefaultMessage,
        int? statusCode = DefaultStatusCode,
        object? moreDetails = null,
        bool view = false) : base(title: title, message: message, statusCode: statusCode,
        moreDetails: moreDetails, view: view) {
        if (errors is not null) {
            Errors = errors
                .ToDictionary(e => e.Key,
                    e => new List<string> { e.Value });
        }
    }

    public ValidationError(Dictionary<string, List<string>>? errors = null,
        string title = DefaultTitle,
        string? message = DefaultMessage,
        int? statusCode = DefaultStatusCode,
        object? moreDetails = null,
        bool view = false) : base(title: title, message: message, statusCode: statusCode,
        moreDetails: moreDetails, view: view) {
        if (errors is not null) {
            Errors = errors;
        }
    }
}