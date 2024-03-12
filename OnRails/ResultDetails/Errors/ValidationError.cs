using System.Text;
using OnRails.Utilities;

namespace OnRails.ResultDetails.Errors;

public sealed class ValidationError(
    List<KeyValue> errors,
    string title = nameof(ValidationError),
    string? message = "One or more validation errors occurred.",
    int? statusCode = 400,
    object? moreDetails = null,
    bool view = false)
    : ErrorDetail(title, message, statusCode, moreDetails, view) {
    public new List<KeyValue> Errors { get; } = errors;

    public ValidationError AddError(string parameterName, string description) {
        Errors.Add(new KeyValue(parameterName, description));
        return this;
    }

    public override object GetViewModel() => new {
        Title,
        Message,
        Errors
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