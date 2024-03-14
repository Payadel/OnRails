namespace OnRails.ResultDetails.Errors;

public class NotFoundError(
    object? id,
    string title = nameof(NotFoundError),
    string? message = "The requested resource(s) could not be found.",
    object? moreDetails = null,
    bool view = false)
    : ErrorDetail(title, message, 404, moreDetails, view) {
    public object? Id { get; } = id;
    
    public override Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message },
            { nameof(Id), Id },
        };
    
    public override bool IsTypeOf(Type type) => GetType() == type && Id is not null && Id.GetType() == type;
    public override bool IsTypeOf<T>() where T : class => this is T  && Id is T;
    
    protected override string CustomFieldsToString() {
        return $"{nameof(Id)}: {Id}";
    }
}