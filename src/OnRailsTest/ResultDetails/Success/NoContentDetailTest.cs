using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails.Success;

namespace OnRailTest.ResultDetails.Success;

public class NoContentDetailTest {
    [Fact]
    public void NoContentDetail_DefaultValues() {
        // Arrange
        const string expectedTitle = nameof(NoContentDetail);
        const int expectedStatusCode = StatusCodes.Status204NoContent;

        // Act
        var noContentDetail = new NoContentDetail();

        // Assert
        Assert.Equal(expectedTitle, noContentDetail.Title);
        Assert.Null(noContentDetail.Message);
        Assert.Equal(expectedStatusCode, noContentDetail.StatusCode);
        Assert.Empty(noContentDetail.MoreDetails);
        Assert.True(noContentDetail.View);
    }

    [Fact]
    public void NoContentDetail_CustomValues() {
        // Arrange
        const string title = "CustomTitle";
        const string message = "CustomMessage";
        var moreDetails = new { Key = "Value" };

        // Act
        var noContentDetail = new NoContentDetail(title, message, moreDetails, false);

        // Assert
        Assert.Equal(title, noContentDetail.Title);
        Assert.Equal(message, noContentDetail.Message);
        Assert.Equal(StatusCodes.Status204NoContent, noContentDetail.StatusCode);
        Assert.Single(noContentDetail.MoreDetails);
        Assert.Contains(moreDetails, noContentDetail.MoreDetails);
        Assert.False(noContentDetail.View);
    }

    [Fact]
    public void NoContentDetail_NullMoreDetails_DefaultsToEmpty() {
        // Arrange & Act
        var noContentDetail = new NoContentDetail("Title", "Message");

        // Assert
        Assert.Empty(noContentDetail.MoreDetails);
    }

    [Fact]
    public void NoContentDetail_MessageIsSetCorrectly() {
        // Arrange
        const string message = "Custom no content message";

        // Act
        var noContentDetail = new NoContentDetail(message: message);

        // Assert
        Assert.Equal(message, noContentDetail.Message);
    }
}