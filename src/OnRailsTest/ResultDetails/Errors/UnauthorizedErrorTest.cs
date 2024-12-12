using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails.Errors;

namespace OnRailTest.ResultDetails.Errors;

public class UnauthorizedErrorTest {
    [Fact]
    public void UnauthorizedError_DefaultValues() {
        // Arrange
        var unauthorizedError = new UnauthorizedError();

        // Act & Assert
        Assert.Equal(nameof(UnauthorizedError), unauthorizedError.Title);
        Assert.Equal("Authentication is required to access the requested resource.", unauthorizedError.Message);
        Assert.Equal(StatusCodes.Status401Unauthorized, unauthorizedError.StatusCode);
        Assert.Empty(unauthorizedError.MoreDetails);
        Assert.False(unauthorizedError.View);
    }

    [Fact]
    public void UnauthorizedError_ToString() {
        // Arrange
        const string customTitle = "Custom Unauthorized Error";
        const string customMessage = "Custom authentication required message.";
        var customDetails = new { ErrorCode = "AUTH001", ErrorDescription = "Invalid credentials" };
        var unauthorizedError = new UnauthorizedError(
            customTitle, customMessage, customDetails);

        // Act
        var result = unauthorizedError.ToString();

        // Assert
        Assert.Contains(customTitle, result);
        Assert.Contains(customMessage, result);
        Assert.Contains($"StackTrace:", result);
    }
}