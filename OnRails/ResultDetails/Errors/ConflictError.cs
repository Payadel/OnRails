namespace OnRails.ResultDetails.Errors;

public class ConflictError(
    string title = nameof(ConflictError),
    string? message =
        "The request could not be completed due to a conflict with the current state of the target resource.",
    string? objectIdentity = null,
    object? moreDetails = null,
    bool view = false)
    : ErrorDetail(title, message, 409, moreDetails, view) {
    public string? ObjectIdentity { get; } = objectIdentity;

    protected override string? CustomFieldsToString() {
        return ObjectIdentity is null
            ? null
            : $"Object Identity: {ObjectIdentity}";
    }

    public override object GetViewModel() => new {
        Title,
        Message,
        ObjectIdentity
    };
}