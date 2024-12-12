using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using OnRails.Models;

namespace OnRails.ResultDetails.Errors.BadRequest;

[DebuggerStepThrough]
public class BadRequestError : ErrorDetail {
    private const string DefaultTitle = nameof(BadRequestError);
    private const string DefaultMessage = "Bad request. Please check your request parameters.";
    private const int DefaultStatusCode = StatusCodes.Status400BadRequest;

    public Dictionary<string, List<string>> Errors { get; protected init; }

    public BadRequestError(
        string fieldName,
        string fieldMessage,
        bool view = false) : base(DefaultTitle, DefaultMessage, DefaultStatusCode, null, view) {
        Errors = [];
        Errors.Add(fieldName, [fieldMessage]);
    }

    public BadRequestError(
        Dictionary<string, List<string>>? errors = null,
        string title = DefaultTitle,
        string? message = DefaultMessage,
        int? statusCode = DefaultStatusCode,
        object? moreDetails = null,
        bool view = false) : base(title, message, statusCode, moreDetails, view) {
        Errors = errors ?? [];
    }

    public override Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message }, {
                nameof(Errors), Errors.Select(error =>
                    new FieldErrors(error.Key, error.Value)).ToList()
            }
        };

    protected override string CustomFieldsToString() {
        if (Errors.Count == 0) return string.Empty;

        var sb = new StringBuilder();
        sb.AppendLine("Errors: ");
        foreach (var (fieldName, message) in Errors) {
            sb.Append($"- {fieldName}: ");
            if (message.Count <= 1) {
                sb.AppendLine(message.FirstOrDefault() ?? string.Empty);
            }
            else {
                sb.AppendLine($"\n\t{string.Join("\n\t", message)}");
            }
        }

        return sb.ToString();
    }
}