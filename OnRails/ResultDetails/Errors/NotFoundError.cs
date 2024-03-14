namespace OnRails.ResultDetails.Errors;

public class NotFoundError : ErrorDetail<object> {
    public NotFoundError(
        object itemId,
        string title = nameof(NotFoundError),
        string? message = "The requested resource(s) could not be found.",
        object? moreDetails = null,
        bool view = false) : base(itemId, title, message, 404, moreDetails, view) { }

    public NotFoundError(
        List<object> itemIds,
        string title = nameof(NotFoundError),
        string? message = "The requested resource(s) could not be found.",
        object? moreDetails = null,
        bool view = false) : base(itemIds, title, message, 404, moreDetails, view) { }
}