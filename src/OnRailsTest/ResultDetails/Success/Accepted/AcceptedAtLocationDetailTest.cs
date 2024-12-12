using OnRails.ResultDetails.Success.Accepted;

namespace OnRailTest.ResultDetails.Success.Accepted;

public class AcceptedAtLocationDetailTest {
    [Fact]
    public void AcceptedAtLocationDetail_StringLocation() {
        // Arrange
        const string location = "http://example.com";

        // Act
        var acceptedAtLocationDetail = new AcceptedAtLocationDetail(location);

        // Assert
        Assert.Equal(location, acceptedAtLocationDetail.Location);
        Assert.Null(acceptedAtLocationDetail.LocationUri);
    }

    [Fact]
    public void AcceptedAtLocationDetail_UriLocation() {
        // Arrange
        var locationUri = new Uri("http://example.com");

        // Act
        var acceptedAtLocationDetail = new AcceptedAtLocationDetail(locationUri);

        // Assert
        Assert.Equal(locationUri, acceptedAtLocationDetail.LocationUri);
        Assert.Null(acceptedAtLocationDetail.Location);
    }

    [Fact]
    public void AcceptedAtLocationDetail_ToStringTest_StringLocation() {
        // Arrange
        const string location = "http://example.com";
        var acceptedAtLocationDetail = new AcceptedAtLocationDetail(location);

        // Act
        var result = acceptedAtLocationDetail.ToString();

        // Assert
        Assert.Contains($"Location: {location}", result);
    }

    [Fact]
    public void AcceptedAtLocationDetail_ToStringTest_UriLocation() {
        // Arrange
        var locationUri = new Uri("http://example.com");
        var acceptedAtLocationDetail = new AcceptedAtLocationDetail(locationUri);

        // Act
        var result = acceptedAtLocationDetail.ToString();

        // Assert
        Assert.Contains($"Location: {locationUri}", result);
    }
}