using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using OnRails.Models;
using OnRails.Utilities;

namespace OnRails.ResultDetails.Errors.BadRequest;

[DebuggerStepThrough]
public class BadRequestError : ErrorDetail<KeyValue<object?>> {
    public BadRequestError(
        string errorKey,
        object? errorValue,
        string title = nameof(BadRequestError),
        string? message = "Bad request. Please check your request parameters.",
        int? statusCode = StatusCodes.Status400BadRequest,
        object? moreDetails = null,
        bool view = false) : base(new KeyValue<object?>(errorKey, errorValue), title, message, statusCode, moreDetails,
        view) { }

    public BadRequestError(
        List<KeyValue<object?>> errors,
        string title = nameof(BadRequestError),
        string? message = "Bad request. Please check your request parameters.",
        int? statusCode = StatusCodes.Status400BadRequest,
        object? moreDetails = null,
        bool view = false) : base(errors, title, message, statusCode, moreDetails, view) { }


    public override bool IsTypeOf(Type type) => GetType() == type;
    public override bool IsTypeOf<TType>() where TType : class => this is TType;

    public override Dictionary<string, object?> GetViewModel() =>
        new() {
            { nameof(Title), Title },
            { nameof(Message), Message },
            { nameof(Errors), Errors.ToDictionary() }
        };
}