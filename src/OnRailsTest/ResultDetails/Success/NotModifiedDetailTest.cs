using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails.Success;

namespace OnRailTest.ResultDetails.Success;

public class NotModifiedDetailTest {
    [Fact]
    public void NotModifiedDetail_DefaultValues() {
        // Arrange
        const string expectedTitle = nameof(NotModifiedDetail);
        const string expectedMessage = "The resource has not been modified.";
        const int expectedStatusCode = StatusCodes.Status304NotModified;

        // Act
        var notModifiedDetail = new NotModifiedDetail();

        // Assert
        Assert.Equal(expectedTitle, notModifiedDetail.Title);
        Assert.Equal(expectedMessage, notModifiedDetail.Message);
        Assert.Equal(expectedStatusCode, notModifiedDetail.StatusCode);
        Assert.Empty(notModifiedDetail.MoreDetails);
        Assert.True(notModifiedDetail.View);
    }

    [Fact]
    public void NotModifiedDetail_CustomValues() {
        // Arrange
        const string title = "CustomTitle";
        const string message = "CustomMessage";
        var moreDetails = new { Key = "Value" };

        // Act
        var notModifiedDetail = new NotModifiedDetail(title, message, moreDetails, false);

        // Assert
        Assert.Equal(title, notModifiedDetail.Title);
        Assert.Equal(message, notModifiedDetail.Message);
        Assert.Equal(StatusCodes.Status304NotModified, notModifiedDetail.StatusCode);
        Assert.Single(notModifiedDetail.MoreDetails);
        Assert.Contains(moreDetails, notModifiedDetail.MoreDetails);
        Assert.False(notModifiedDetail.View);
    }

    [Fact]
    public void NotModifiedDetail_NullMoreDetails_DefaultsToEmpty() {
        // Arrange & Act
        var notModifiedDetail = new NotModifiedDetail("Title", "Message");

        // Assert
        Assert.Empty(notModifiedDetail.MoreDetails);
    }

    [Fact]
    public void NotModifiedDetail_MessageIsSetCorrectly() {
        // Arrange
        const string message = "Custom not modified message";

        // Act
        var notModifiedDetail = new NotModifiedDetail(message: message);

        // Assert
        Assert.Equal(message, notModifiedDetail.Message);
    }
}