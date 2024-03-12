using System.Text;

namespace OnRails.ResultDetails.Errors;

public sealed class ValidationError(
    string title = nameof(ValidationError),
    string? message = "One or more validation errors occurred.",
    int? statusCode = 400,
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, statusCode, exception, moreDetails) {
    public new List<KeyValuePair<string, string>> Errors { get; } = [];

    public ValidationError AddError(string parameterName, string description) {
        Errors.Add(new KeyValuePair<string, string>(parameterName, description));
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

        sb.AppendLine("Errors:\n");
        foreach (var (key, value) in Errors)
            sb.AppendLine($"\t{key}: {value}");

        return sb.ToString();
    }
}