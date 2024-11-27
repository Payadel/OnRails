using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Errors.BadRequest;

[DebuggerStepThrough]
public class ConflictError : BadRequestError {
    private const string DefaultTitle = nameof(ConflictError);
    private const int DefaultStatusCode = StatusCodes.Status409Conflict;

    private const string DefaultMessage =
        "The request could not be completed due to a conflict with the current state of the target resource.";


    public ConflictError(
        string fieldName,
        string fieldMessage,
        bool view = false) : base(title: DefaultTitle, message: DefaultMessage, statusCode: DefaultStatusCode,
        moreDetails: null, view: view) {
        Errors.Add(fieldName, [fieldMessage]);
    }

    public ConflictError(Dictionary<string, string>? errors = null,
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

    public ConflictError(Dictionary<string, List<string>>? errors = null,
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