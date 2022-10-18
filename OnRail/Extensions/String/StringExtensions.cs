using System.Text.RegularExpressions;
using OnRail.Extensions.Fail;
using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions.String;

//TODO: Test

public static class StringExtensions {
    public static Result<string> MustMatchRegex(
        this string source,
        Regex regex,
        ErrorDetail? errorDetail = null) =>
        source.FailWhen(!regex.IsMatch(source),
            errorDetail ??
            new ValidationError().AddError($"{source}", $"({source}) is not match with {regex}"));
}