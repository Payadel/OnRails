using System.Diagnostics;
using System.Text.RegularExpressions;
using OnRails.Extensions.Fail;
using OnRails.ResultDetails;
using OnRails.ResultDetails.Errors;

namespace OnRails.Extensions.String;

[DebuggerStepThrough]
public static class StringExtensions {
    public static Result<string> MustMatchRegex(
        this string source,
        Regex regex,
        ErrorDetail? errorDetail = null) =>
        source.FailWhen(!regex.IsMatch(source),
            errorDetail ?? new ValidationError([
                    new(source, $"is not match with {regex}")
                ]
            ));
}