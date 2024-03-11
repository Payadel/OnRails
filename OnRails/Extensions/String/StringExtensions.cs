using System.Text.RegularExpressions;
using OnRails.Extensions.Fail;
using OnRails.ResultDetails;
using OnRails.ResultDetails.Errors;

namespace OnRails.Extensions.String;

public static class StringExtensions {
    public static Result<string> MustMatchRegex(
        this string source,
        Regex regex,
        ErrorDetail? errorDetail = null) =>
        source.FailWhen(!regex.IsMatch(source),
            errorDetail ?? new ValidationError().AddError($"{source}", $"({source}) is not match with {regex}"));
}