using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails.Errors;

namespace OnRailTest.ResultDetails.Errors;

public class ForbiddenErrorTest {
    [Fact]
    public void ForbiddenError_DefaultValues() {
        // Arrange
        var forbiddenError = new ForbiddenError();

        // Act & Assert
        Assert.Equal(nameof(ForbiddenError), forbiddenError.Title);
        Assert.Equal("You don't have permission to access the requested resource.", forbiddenError.Message);
        Assert.Equal(StatusCodes.Status403Forbidden, forbiddenError.StatusCode);
        Assert.Empty(forbiddenError.MoreDetails);
        Assert.False(forbiddenError.View);
    }

    [Fact]
    public void ForbiddenError_ToString() {
        // Arrange
        const string customTitle = "Custom Forbidden Error";
        const string customMessage = "Custom permission error message.";
        var customDetails = new { ErrorCode = "PERM001", ErrorDescription = "User lacks necessary permissions" };
        var forbiddenError = new ForbiddenError(
            customTitle, customMessage, customDetails);

        // Act
        var result = forbiddenError.ToString();

        // Assert
        Assert.Contains(customTitle, result);
        Assert.Contains(customMessage, result);
        Assert.Contains($"StackTrace:", result);
    }
}