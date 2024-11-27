using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails.Errors.Internal;

namespace OnRailTest.ResultDetails.Errors.Internal;

public class NotImplementedErrorTest {
    [Fact]
    public void NotImplementedError_DefaultValues() {
        // Arrange
        var notImplementedError = new NotImplementedError();

        // Act & Assert
        Assert.Equal(nameof(NotImplementedError), notImplementedError.Title);
        Assert.Equal("The requested functionality is not implemented.", notImplementedError.Message);
        Assert.Equal(StatusCodes.Status501NotImplemented, notImplementedError.StatusCode);
        Assert.Empty(notImplementedError.MoreDetails);
        Assert.False(notImplementedError.View);
    }

    [Fact]
    public void NotImplementedError_ToString() {
        // Arrange
        const string customTitle = "Custom Not Implemented Error";
        const string customMessage = "Custom functionality not implemented message.";
        var customDetails = new { ErrorCode = "FUNC001", ErrorDescription = "Feature is under construction" };
        var notImplementedError = new NotImplementedError(
            customTitle, customMessage, customDetails);

        // Act
        var result = notImplementedError.ToString();

        // Assert
        Assert.Contains(customTitle, result);
        Assert.Contains(customMessage, result);
        Assert.Contains($"StackTrace:", result);
    }
}