using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails;

namespace OnRailTest.ResultDetails;

public class WarningDetailTests {
    [Fact]
    public void Constructor_ShouldInitializeProperties_WhenValidArgumentsProvided() {
        // Arrange
        const string message = "This is a warning message.";
        const string title = "CustomWarningTitle";
        const int statusCode = StatusCodes.Status400BadRequest;
        var moreDetails = new { Info = "Additional details" };
        const bool view = true;

        // Act
        var warningDetail = new WarningDetail(message, title, statusCode, moreDetails, view);

        // Assert
        Assert.Equal(title, warningDetail.Title);
        Assert.Equal(message, warningDetail.Message);
        Assert.Equal(statusCode, warningDetail.StatusCode);
        Assert.Single(warningDetail.MoreDetails, moreDetails);
        Assert.Equal(view, warningDetail.View);
    }

    [Fact]
    public void Constructor_ShouldUseDefaultValues_WhenOptionalArgumentsNotProvided() {
        // Arrange
        const string message = "Default warning message.";

        // Act
        var warningDetail = new WarningDetail(message);

        // Assert
        Assert.Equal(nameof(WarningDetail), warningDetail.Title);
        Assert.Equal(message, warningDetail.Message);
        Assert.Equal(StatusCodes.Status200OK, warningDetail.StatusCode);
        Assert.Empty(warningDetail.MoreDetails);
        Assert.False(warningDetail.View);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenMessageIsNull() {
        // Arrange
        string? message = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new WarningDetail(message!));
    }
}