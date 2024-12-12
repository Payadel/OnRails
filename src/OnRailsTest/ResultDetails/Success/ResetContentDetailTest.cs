using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails.Success;

namespace OnRailTest.ResultDetails.Success;

public class ResetContentDetailTest {
    [Fact]
    public void ResetContentDetail_DefaultValues() {
        // Arrange
        const string expectedTitle = nameof(ResetContentDetail);
        const int expectedStatusCode = StatusCodes.Status205ResetContent;

        // Act
        var resetContentDetail = new ResetContentDetail();

        // Assert
        Assert.Equal(expectedTitle, resetContentDetail.Title);
        Assert.Null(resetContentDetail.Message);
        Assert.Equal(expectedStatusCode, resetContentDetail.StatusCode);
        Assert.Empty(resetContentDetail.MoreDetails);
        Assert.True(resetContentDetail.View);
    }

    [Fact]
    public void ResetContentDetail_CustomValues() {
        // Arrange
        const string title = "CustomTitle";
        const string message = "CustomMessage";
        var moreDetails = new { Detail = "AdditionalInfo" };

        // Act
        var resetContentDetail = new ResetContentDetail(title, message, moreDetails, false);

        // Assert
        Assert.Equal(title, resetContentDetail.Title);
        Assert.Equal(message, resetContentDetail.Message);
        Assert.Equal(StatusCodes.Status205ResetContent, resetContentDetail.StatusCode);
        Assert.Single(resetContentDetail.MoreDetails);
        Assert.Contains(moreDetails, resetContentDetail.MoreDetails);
        Assert.False(resetContentDetail.View);
    }

    [Fact]
    public void ResetContentDetail_NullMoreDetails_DefaultsToEmpty() {
        // Arrange & Act
        var resetContentDetail = new ResetContentDetail("Title", "Message");

        // Assert
        Assert.Empty(resetContentDetail.MoreDetails);
    }

    [Fact]
    public void ResetContentDetail_MessageIsSetCorrectly() {
        // Arrange
        const string message = "Operation successfully reset";

        // Act
        var resetContentDetail = new ResetContentDetail(message: message);

        // Assert
        Assert.Equal(message, resetContentDetail.Message);
    }
}