using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails.Errors.Internal;

namespace OnRailTest.ResultDetails.Errors.Internal;

public class InternalErrorTest {
    [Fact]
    public void InternalError_DefaultValues() {
        // Arrange
        var internalError = new InternalError();

        // Act & Assert
        Assert.Equal(nameof(InternalError), internalError.Title);
        Assert.Equal("An unexpected condition was encountered while processing the request.", internalError.Message);
        Assert.Equal(StatusCodes.Status500InternalServerError, internalError.StatusCode);
        Assert.Empty(internalError.MoreDetails);
        Assert.False(internalError.View);
    }

    [Fact]
    public void InternalError_ToString() {
        // Arrange
        const string customTitle = "Custom Internal Error";
        const string customMessage = "A custom error message occurred.";
        var customDetails = new { Resource = "Payment", Error = "Service unavailable" };
        var internalError = new InternalError(
            customTitle, customMessage, moreDetails: customDetails);

        // Act
        var result = internalError.ToString();

        // Assert
        Assert.Contains(customTitle, result);
        Assert.Contains(customMessage, result);
        Assert.Contains($"StackTrace:", result);
    }
}