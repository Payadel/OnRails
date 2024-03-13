using System.Text;
using OnRails.Utilities;

namespace OnRails.ResultDetails.Errors;

public class ValidationError : ErrorDetail {
    public ValidationError(
        List<KeyValue> errors,
        string title = nameof(ValidationError),
        string? message = "One or more validation errors occurred.",
        int? statusCode = 400,
        object? moreDetails = null,
        bool view = false) : base(title, message, statusCode, moreDetails, view) {
        Errors = errors;
    }

    public ValidationError(
        KeyValue error,
        string title = nameof(ValidationError),
        string? message = "One or more validation errors occurred.",
        int? statusCode = 400,
        object? moreDetails = null,
        bool view = false) : base(title, message, statusCode, moreDetails, view) {
        Errors = [error];
    }

    public new List<KeyValue> Errors { get; }

    public override Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message },
            { nameof(Errors), Errors.ToDictionary() }
        };

    protected override string? ErrorsToString() {
        if (Errors.Count <= 0) return null;

        var sb = new StringBuilder();

        sb.AppendLine("Errors:");
        foreach (var error in Errors)
            sb.AppendLine($"\t{error.ToString()}");

        return sb.ToString();
    }
}