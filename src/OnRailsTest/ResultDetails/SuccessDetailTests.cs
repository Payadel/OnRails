using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails;

namespace OnRailTest.ResultDetails;

public class SuccessDetailTests {
    [Fact]
    public void Constructor_ShouldInitializeProperties_WhenValidArgumentsProvided() {
        // Arrange
        const string title = "CustomSuccessTitle";
        const string message = "The operation was completed successfully.";
        const int statusCode = StatusCodes.Status201Created;
        var moreDetails = new { Info = "Additional details" };
        const bool view = true;

        // Act
        var successDetail = new SuccessDetail(title, message, statusCode, moreDetails, view);

        // Assert
        Assert.Equal(title, successDetail.Title);
        Assert.Equal(message, successDetail.Message);
        Assert.Equal(statusCode, successDetail.StatusCode);
        Assert.Single(successDetail.MoreDetails, moreDetails);
        Assert.Equal(view, successDetail.View);
    }

    [Fact]
    public void Constructor_ShouldUseDefaultValues_WhenOptionalArgumentsNotProvided() {
        // Act
        var successDetail = new SuccessDetail();

        // Assert
        Assert.Equal(nameof(SuccessDetail), successDetail.Title);
        Assert.Equal("Operation was successful", successDetail.Message);
        Assert.Equal(StatusCodes.Status200OK, successDetail.StatusCode);
        Assert.Empty(successDetail.MoreDetails);
        Assert.False(successDetail.View);
    }

    [Fact]
    public void Constructor_ShouldInitializeWithDefaultTitle_WhenOnlyMessageIsProvided() {
        // Arrange
        const string message = "Custom success message.";

        // Act
        var successDetail = new SuccessDetail(message: message);

        // Assert
        Assert.Equal(nameof(SuccessDetail), successDetail.Title);
        Assert.Equal(message, successDetail.Message);
        Assert.Equal(StatusCodes.Status200OK, successDetail.StatusCode);
        Assert.Empty(successDetail.MoreDetails);
        Assert.False(successDetail.View);
    }
}