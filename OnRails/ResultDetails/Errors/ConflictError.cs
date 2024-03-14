namespace OnRails.ResultDetails.Errors;

public class ConflictError(
    List<ConflictItem>? errors = null,
    string title = nameof(ConflictError),
    string? message =
        "The request could not be completed due to a conflict with the current state of the target resource.",
    object? moreDetails = null,
    bool view = false)
    : ErrorDetail<ConflictItem>(errors ?? [], title, message, 409, moreDetails, view) {
    public override bool IsTypeOf(Type type) => GetType() == type;
    public override bool IsTypeOf<TType>() where TType : class => this is TType;
}

public record ConflictItem(
    string PropertyName,
    object? CurrentDatabaseValue,
    object? OriginalValue,
    object? ValueToBeSaved);