using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Errors.Internal;

[DebuggerStepThrough]
public class ErrorDetailList : InternalError {
    public List<ErrorDetail> Errors { get; } = [];

    public ErrorDetailList(
        List<ErrorDetail> errors,
        string title = nameof(ErrorDetailList),
        string? message = "One or more error(s) occurred",
        int? statusCode = StatusCodes.Status500InternalServerError,
        object? moreDetails = null,
        bool view = false) : base(
        title, message, statusCode, moreDetails, view) {
        if (errors.Count > 0)
            Errors.AddRange(errors);
    }

    protected override string CustomFieldsToString() {
        if (Errors.Count == 0) return string.Empty;

        var sb = new StringBuilder();
        sb.AppendLine("Errors:");
        foreach (var error in Errors) {
            sb.AppendLine($"\t{error.ToString()}");
        }

        return sb.ToString();
    }

    public override bool IsTypeOf(Type type) =>
        GetType() == type || Errors.Any(error => error.IsTypeOf(type));

    public override bool IsTypeOf<TType>() where TType : class =>
        this is TType || Errors.Any(error => error is TType);
}