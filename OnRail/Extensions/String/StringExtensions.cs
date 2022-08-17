using System.Text.RegularExpressions;
using OnRail.Extensions.Fail;
using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions.String;

//TODO: Test

public static class StringExtensions {
    public static Result<string> MustMatchRegex(
        this string @this,
        Regex rgx,
        ErrorDetail? errorDetail = null) =>
        @this.FailWhen(!rgx.IsMatch(@this),
            errorDetail ?? new ArgumentError(message: $"({@this}) is not match with {rgx}"));
}