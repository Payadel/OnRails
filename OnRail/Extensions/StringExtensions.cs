namespace OnRail.Extensions;

public static class StringExtensions {
    // public static Result<string> MustMatchRegex(
    //     this string @this, Regex rgx,
    //     ErrorDetail? errorDetail = null, ) =>
    //     @this.FailWhen(!rgx.IsMatch(@this),
    //         errorDetail ??
    //         new BadRequestError(message: $"({@this}) is not match with {rgx}"));
}