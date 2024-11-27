using OnRails.ResultDetails.Success.Created;

namespace OnRailTest.ResultDetails.Success.Created;

public class CreatedAtLocationDetailTest {
    [Fact]
    public void CreatedAtLocationDetail_ConstructorWithLocationString() {
        // Arrange
        const string location = "/api/v1/resources/1";

        // Act
        var createdAtLocationDetail = new CreatedAtLocationDetail(location);

        // Assert
        Assert.Equal(nameof(CreatedAtLocationDetail), createdAtLocationDetail.Title);
        Assert.Equal(location, createdAtLocationDetail.Location);
        Assert.Null(createdAtLocationDetail.LocationUri);
    }

    [Fact]
    public void CreatedAtLocationDetail_ConstructorWithLocationUri() {
        // Arrange
        var locationUri = new Uri("http://example.com/api/v1/resources/1");

        // Act
        var createdAtLocationDetail = new CreatedAtLocationDetail(locationUri);

        // Assert
        Assert.Equal(nameof(CreatedAtLocationDetail), createdAtLocationDetail.Title);
        Assert.Equal(locationUri, createdAtLocationDetail.LocationUri);
        Assert.Null(createdAtLocationDetail.Location);
    }

    [Fact]
    public void CreatedAtLocationDetail_CustomFieldsToString_WithLocationString() {
        // Arrange
        const string location = "/api/v1/resources/1";
        var createdAtLocationDetail = new CreatedAtLocationDetail(location);

        // Act
        var result = createdAtLocationDetail.ToString();

        // Assert
        Assert.Contains($"Location: {location}", result);
    }

    [Fact]
    public void CreatedAtLocationDetail_CustomFieldsToString_WithLocationUri() {
        // Arrange
        var locationUri = new Uri("http://example.com/api/v1/resources/1");
        var createdAtLocationDetail = new CreatedAtLocationDetail(locationUri);

        // Act
        var result = createdAtLocationDetail.ToString();

        // Assert
        Assert.Contains($"Location: {locationUri}", result);
    }
}