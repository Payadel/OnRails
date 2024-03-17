using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Errors;

[DebuggerStepThrough]
public class ConflictError(
    List<ConflictItem>? errors = null,
    string title = nameof(ConflictError),
    string? message =
        "The request could not be completed due to a conflict with the current state of the target resource.",
    object? moreDetails = null,
    bool view = false)
    : ErrorDetail<ConflictItem>(errors ?? [], title, message, StatusCodes.Status409Conflict, moreDetails, view) {
    public override bool IsTypeOf(Type type) => GetType() == type;
    public override bool IsTypeOf<TType>() where TType : class => this is TType;
}

public record ConflictItem(
    string PropertyName,
    object? CurrentDatabaseValue,
    object? OriginalValue,
    object? ValueToBeSaved);