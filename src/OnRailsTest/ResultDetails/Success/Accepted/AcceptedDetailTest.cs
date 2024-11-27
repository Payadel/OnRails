using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails.Success.Accepted;

namespace OnRailTest.ResultDetails.Success.Accepted;

public class AcceptedDetailTest {
    [Fact]
    public void AcceptedDetail_DefaultConstructor() {
        // Act
        var acceptedDetail = new AcceptedDetail();

        // Assert
        Assert.Equal(nameof(AcceptedDetail), acceptedDetail.Title);
        Assert.Equal("Request has been accepted for processing, but the processing is not yet complete.",
            acceptedDetail.Message);
        Assert.Equal(StatusCodes.Status202Accepted, acceptedDetail.StatusCode);
        Assert.True(acceptedDetail.View);
    }

    [Fact]
    public void AcceptedDetail_CustomTitle() {
        // Arrange
        const string title = "Custom Title";

        // Act
        var acceptedDetail = new AcceptedDetail(title: title);

        // Assert
        Assert.Equal(title, acceptedDetail.Title);
    }

    [Fact]
    public void AcceptedDetail_CustomMessage() {
        // Arrange
        const string message = "Request has been accepted.";

        // Act
        var acceptedDetail = new AcceptedDetail(message: message);

        // Assert
        Assert.Equal(message, acceptedDetail.Message);
    }

    [Fact]
    public void AcceptedDetail_CustomView() {
        // Act
        var acceptedDetail = new AcceptedDetail(view: false);

        // Assert
        Assert.False(acceptedDetail.View);
    }
}