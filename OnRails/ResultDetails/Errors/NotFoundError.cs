using System.Text;
using OnRails.Utilities;

namespace OnRails.ResultDetails.Errors;

public class NotFoundError : ErrorDetail {
    public NotFoundError(
        string keyName,
        object? keyValue,
        string title = nameof(NotFoundError),
        string? message = "The requested resource(s) could not be found.",
        object? moreDetails = null,
        bool view = false) : base(title, message, 404, moreDetails, view) {
        Keys = [new(keyName, keyValue)];
    }

    public NotFoundError(
        List<KeyValue<object?>> keys,
        string title = nameof(NotFoundError),
        string? message = "The requested resource(s) could not be found.",
        object? moreDetails = null,
        bool view = false) : base(title, message, 404, moreDetails, view) {
        Keys = keys;
    }

    public List<KeyValue<object?>> Keys { get; }

    public override Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message },
            { nameof(Keys), Keys.ToDictionary() },
        };

    protected override string CustomFieldsToString() {
        var sb = new StringBuilder();

        sb.AppendLine($"{nameof(Keys)}:");
        foreach (var key in Keys)
            sb.AppendLine($"\t{key.ToString()}");

        return sb.ToString();
    }
}