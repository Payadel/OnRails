namespace OnRails.ResultDetails.Errors;

public sealed class ValidationError(
    string title = nameof(ValidationError),
    string? message = "One or more validation errors occurred.",
    int? statusCode = 400,
    Exception? exception = null,
    object? moreDetails = null)
    : ErrorDetail(title, message, statusCode, exception, moreDetails) {
    public ValidationError AddError(string parameterName, string description) {
        Errors.Add(new KeyValuePair<string, string>(parameterName, description));
        return this;
    }

    public override object GetViewModel() => new {
        Title,
        Message,
        Errors
    };
}