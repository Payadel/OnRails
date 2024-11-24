using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Errors.Internal;

[DebuggerStepThrough]
public class CollectionErrorDetail : ErrorDetail<ErrorDetail> {
    public CollectionErrorDetail(
        ErrorDetail error,
        string title = nameof(CollectionErrorDetail),
        string? message = "One or more error(s) occurred",
        int? statusCode = StatusCodes.Status500InternalServerError,
        object? moreDetails = null,
        bool view = false) : base(error, title, message, statusCode,
        moreDetails, view) { }

    public CollectionErrorDetail(List<ErrorDetail> errors,
        string title = nameof(CollectionErrorDetail),
        string? message = "One or more error(s) occurred",
        int? statusCode = StatusCodes.Status500InternalServerError,
        object? moreDetails = null,
        bool view = false) : base(
        errors, title, message, statusCode, moreDetails, view) { }

    protected override string? ErrorsToString() {
        if (Errors.Count <= 0) return null;

        var sb = new StringBuilder();

        sb.AppendLine($"Errors ({Errors.Count}):");
        for (var i = 0; i < Errors.Count; i++)
            sb.AppendLine($"\t{i + 1}- {Errors[i].ToString()}");

        return sb.ToString();
    }

    public override bool IsTypeOf(Type type) => GetType() == type || Errors.Any(error => error.IsTypeOf(type));

    public override bool IsTypeOf<TType>() where TType : class =>
        this is TType || Errors.Any(error => error.IsTypeOf<TType>());
}