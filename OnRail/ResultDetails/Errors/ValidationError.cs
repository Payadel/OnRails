using Microsoft.AspNetCore.Http;

namespace OnRail.ResultDetails.Errors;

public class ValidationError : ErrorDetail {
    public ValidationError(string? title = nameof(ValidationError),
        string? message = "One or more validation errors occurred.", int? statusCode = StatusCodes.Status400BadRequest,
        Exception? exception = null, object? moreDetails = null)
        : base(title, message, statusCode, exception, moreDetails) { }

    public List<KeyValuePair<string, string>> Errors { get; set; } = new();

    public void AddError(string parameterName, string description) {
        Errors.Add(new KeyValuePair<string, string>(parameterName, description));
    }
}