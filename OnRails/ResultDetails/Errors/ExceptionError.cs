namespace OnRails.ResultDetails.Errors;

public class ExceptionError(
    Exception exception,
    string title = $"{nameof(ExceptionError)} - An unexpected error occurred.",
    string? message = null,
    object? moreDetails = null,
    bool view = false)
    : InternalError(title, message ?? exception.Message, moreDetails: moreDetails, view) {
    public Exception Exception { get; } = exception;

    protected override string? CustomFieldsToString() {
        return Exception.ToString();
    }

    public override bool IsTypeOf(Type type) => GetType() == type || Exception.GetType() == type;
    public override bool IsTypeOf<TType>() where TType : class => this is TType || Exception is TType;
}