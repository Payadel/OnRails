using System.Text.RegularExpressions;
using OnRails.Extensions.String;
using OnRails.ResultDetails.Errors.BadRequest;

namespace OnRailTest.Extensions;

public static partial class StringExtensionsTest {
    private const string SampleEmail = "test@test.com";
    private const string InvalidEmail = "test.com";
    private static readonly Regex EmailRegex = MyRegex();

    [Fact]
    public static void MustMatchRegex_MatchRegex_SuccessResult() {
        var result = SampleEmail.MustMatchRegex(EmailRegex);

        Assert.True(result.Success);
    }

    [Fact]
    public static void MustMatchRegex_NoMatchRegexWithoutErrorDetail_ReturnDefaultErrorDetail() {
        var result = InvalidEmail.MustMatchRegex(EmailRegex);

        Assert.False(result.Success);
        Assert.IsType<ValidationError>(result.Detail);
    }

    [Fact]
    public static void MustMatchRegex_NoMatchRegexWithErrorDetail_ReturnErrorDetail() {
        var result = InvalidEmail.MustMatchRegex(EmailRegex, new BadRequestError([]));

        Assert.False(result.Success);
        Assert.IsType<BadRequestError>(result.Detail);
    }

    [GeneratedRegex(@"^[\w-\.]+@([\w-]+\.)+[\w-]+")]
    private static partial Regex MyRegex();
}