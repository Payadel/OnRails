using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Errors;

[DebuggerStepThrough]
public class NotFoundError : ErrorDetail {
    private const string DefaultTitle = nameof(NotFoundError);
    private const string DefaultMessage = "The requested resource(s) could not be found.";
    private const int DefaultStatusCode = StatusCodes.Status404NotFound;

    public NotFoundError(string key, bool view = false) : base(DefaultTitle, DefaultMessage, DefaultStatusCode, null,
        view) {
        Keys = [key];
    }

    public NotFoundError(string title = DefaultTitle,
        string? message = DefaultMessage,
        HashSet<string>? keys = null,
        object? moreDetails = null,
        bool view = false) : base(title, message, StatusCodes.Status404NotFound, moreDetails, view) {
        Keys = keys ?? [];
    }

    public HashSet<string> Keys { get; }

    public override Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message },
            { nameof(Keys), Keys.ToList() }
        };

    protected override string CustomFieldsToString() =>
        Keys.Count == 0
            ? string.Empty
            : $"{nameof(Keys)}:\n{string.Join("\n\t", Keys)}";
}