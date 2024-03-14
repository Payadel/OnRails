using OnRails.Utilities;

namespace OnRails.ResultDetails.Errors;

public class BadRequestError : ErrorDetail<KeyValue<string>> {
    public BadRequestError(
        List<KeyValue<string>> errors,
        string title = nameof(BadRequestError),
        string? message = "Bad request. Please check your request parameters.",
        int? statusCode = 400,
        object? moreDetails = null,
        bool view = false) : base(errors, title, message, statusCode, moreDetails, view) { }

    public BadRequestError(
        string errorKey,
        string errorValue,
        string title = nameof(BadRequestError),
        string? message = "Bad request. Please check your request parameters.",
        int? statusCode = 400,
        object? moreDetails = null,
        bool view = false) : base(new KeyValue<string>(errorKey, errorValue), title, message, statusCode, moreDetails,
        view) { }


    public override bool IsTypeOf(Type type) => GetType() == type;
    public override bool IsTypeOf<TType>() where TType : class => this is TType;

    public override Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message },
            { nameof(Errors), Errors.ToDictionary() }
        };
}