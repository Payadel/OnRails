using System.Text.RegularExpressions;
using OnRails.Extensions.String;
using OnRails.ResultDetails.Errors.BadRequest;

namespace OnRailTest.Extensions;

public static class StringExtensionsTest {
    private const string SampleEmail = "test@test.com";
    private const string InvalidEmail = "test.com";
    private static readonly Regex EmailRegex = new(@"^[\w-\.]+@([\w-]+\.)+[\w-]+");

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
}