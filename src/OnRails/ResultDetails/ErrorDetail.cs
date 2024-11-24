using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using OnRails.Utilities;

namespace OnRails.ResultDetails;

[DebuggerStepThrough]
public class ErrorDetail(
    string title = nameof(ErrorDetail),
    string? message = "An error occurred",
    int? statusCode = StatusCodes.Status500InternalServerError,
    object? moreDetails = null,
    bool view = false)
    : ResultDetail(title, message, statusCode, moreDetails, view) {
    public StackTrace StackTrace { get; } = new StackTrace(1, true)
        .RemoveFrames(Constants.AppNamespace);

    public override string ToString() {
        var sb = new StringBuilder(base.ToString());

        sb.AppendLine($"StackTrace:\n\t{StackTrace.ToString().Trim()}");
        return sb.ToString();
    }

    public override Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message },
        };
}

public abstract class ErrorDetail<T> : ErrorDetail where T : class {
    protected ErrorDetail(
        T error,
        string title = nameof(ErrorDetail),
        string? message = "An error occurred",
        int? statusCode = StatusCodes.Status500InternalServerError,
        object? moreDetails = null,
        bool view = false) : base(title, message, statusCode, moreDetails, view) {
        Errors ??= [];
        Errors.Add(error);
    }

    protected ErrorDetail(
        List<T> errors,
        string title = nameof(ErrorDetail),
        string? message = "An error occurred",
        int? statusCode = StatusCodes.Status500InternalServerError,
        object? moreDetails = null,
        bool view = false) : base(title, message, statusCode, moreDetails, view) {
        Errors = errors;
    }

    public List<T> Errors { get; }

    protected override string? CustomFieldsToString() => ErrorsToString();

    protected virtual string? ErrorsToString() {
        if (Errors.Count <= 0) return null;

        var sb = new StringBuilder();

        sb.AppendLine($"Errors ({Errors.Count}):");
        foreach (var error in Errors)
            sb.AppendLine($"\t{error.ToString()}");

        return sb.ToString();
    }

    public override Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message },
            { nameof(Errors), Errors }
        };

    public override bool IsTypeOf(Type type) => GetType() == type || Errors.Any(error => error.GetType() == type);
    public override bool IsTypeOf<TType>() where TType : class => this is TType || Errors.Any(error => error is TType);
}