namespace OnRails.ResultDetails.Errors;

public class NotFoundError : ErrorDetail<string> {
    public NotFoundError(
        string itemId,
        string title = nameof(NotFoundError),
        string? message = "The requested resource could not be found.",
        object? moreDetails = null,
        bool view = false) : base(itemId, title, message, 404, moreDetails, view) { }

    public NotFoundError(
        List<string> itemIds,
        string title = nameof(NotFoundError),
        string? message = "The requested resource could not be found.",
        object? moreDetails = null,
        bool view = false) : base(itemIds, title, message, 404, moreDetails, view) { }

    public override bool IsTypeOf(Type type) => GetType() == type;
    public override bool IsTypeOf<TType>() where TType : class => this is TType;
}