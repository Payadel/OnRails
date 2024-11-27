using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails.Success.Created;

namespace OnRailTest.ResultDetails.Success.Created;

public class CreatedDetailTest {
    [Fact]
    public void CreatedDetail_DefaultValues() {
        // Arrange
        const string expectedTitle = nameof(CreatedDetail);
        const int expectedStatusCode = StatusCodes.Status201Created;

        // Act
        var createdDetail = new CreatedDetail();

        // Assert
        Assert.Equal(expectedTitle, createdDetail.Title);
        Assert.Equal("Resource successfully created.", createdDetail.Message);
        Assert.Equal(expectedStatusCode, createdDetail.StatusCode);
        Assert.Empty(createdDetail.MoreDetails);
        Assert.True(createdDetail.View);
    }

    [Fact]
    public void CreatedDetail_CustomValues() {
        // Arrange
        const string title = "CustomTitle";
        const string message = "CustomMessage";
        var moreDetails = new { Key = "Value" };

        // Act
        var createdDetail = new CreatedDetail(title, message, moreDetails, false);

        // Assert
        Assert.Equal(title, createdDetail.Title);
        Assert.Equal(message, createdDetail.Message);
        Assert.Equal(StatusCodes.Status201Created, createdDetail.StatusCode);
        Assert.Single(createdDetail.MoreDetails);
        Assert.Contains(moreDetails, createdDetail.MoreDetails);
        Assert.False(createdDetail.View);
    }

    [Fact]
    public void CreatedDetail_NullMoreDetails_DefaultsToEmpty() {
        // Arrange & Act
        var createdDetail = new CreatedDetail("Title", "Message");

        // Assert
        Assert.Empty(createdDetail.MoreDetails);
    }

    [Fact]
    public void CreatedDetail_MessageIsSetCorrectly() {
        // Arrange
        const string message = "Resource created successfully";

        // Act
        var createdDetail = new CreatedDetail(message: message);

        // Assert
        Assert.Equal(message, createdDetail.Message);
    }

    [Fact]
    public void CreatedDetail_GetViewModel_ReturnsEmptyDictionary() {
        // Arrange
        var createdDetail = new CreatedDetail();

        // Act
        var viewModel = createdDetail.GetViewModel();

        // Assert
        Assert.NotNull(viewModel);
        Assert.Empty(viewModel);
    }
}