using System.Text;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Errors;

public class ValidationError : ErrorDetail {
    public ValidationError(string title = nameof(ValidationError),
        string? message = "One or more validation errors occurred.", int? statusCode = StatusCodes.Status400BadRequest,
        Exception? exception = null, object? moreDetails = null)
        : base(title, message, statusCode, exception, moreDetails) { }

    public List<KeyValuePair<string, string>>? Errors { get; set; }

    public ValidationError AddError(string parameterName, string description) {
        Errors ??= new List<KeyValuePair<string, string>>();
        Errors.Add(new KeyValuePair<string, string>(parameterName, description));
        return this;
    }

    public override object GetViewModel() => new {
        Title,
        Message,
        Errors
    };

    public override string ToString() {
        var sb = new StringBuilder(base.ToString());
        if (Errors is not null) {
            sb.AppendLine("Errors:\n");
            foreach (var (key, value) in Errors)
                sb.AppendLine($"\t{key}:\t{value}");
        }

        return sb.ToString();
    }
}