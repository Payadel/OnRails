using OnRails.ResultDetails.Success.Accepted;

namespace OnRailTest.ResultDetails.Success.Accepted;

public class AcceptedAtRouteDetailTest {
    [Fact]
    public void AcceptedAtRouteDetail_DefaultConstructor() {
        // Arrange
        var routeValues = new { key = "value" };

        // Act
        var acceptedAtRouteDetail = new AcceptedAtRouteDetail(routeValues);

        // Assert
        Assert.Equal(nameof(AcceptedAtRouteDetail), acceptedAtRouteDetail.Title);
        Assert.Equal(routeValues, acceptedAtRouteDetail.RouteValues);
        Assert.Null(acceptedAtRouteDetail.RouteName);
    }

    [Fact]
    public void AcceptedAtRouteDetail_CustomRouteName() {
        // Arrange
        const string routeName = "RouteName";
        var routeValues = new { key = "value" };

        // Act
        var acceptedAtRouteDetail = new AcceptedAtRouteDetail(routeName, routeValues);

        // Assert
        Assert.Equal(routeName, acceptedAtRouteDetail.RouteName);
    }

    [Fact]
    public void AcceptedAtRouteDetail_CustomRouteValues() {
        // Arrange
        var routeValues = new { id = 1, name = "Test" };

        // Act
        var acceptedAtRouteDetail = new AcceptedAtRouteDetail(routeValues);

        // Assert
        Assert.Equal(routeValues, acceptedAtRouteDetail.RouteValues);
    }

    [Fact]
    public void AcceptedAtRouteDetail_ToStringTest() {
        // Arrange
        const string routeName = "TestRoute";
        var routeValues = new { key = "value" };
        var acceptedAtRouteDetail = new AcceptedAtRouteDetail(routeName, routeValues);

        // Act
        var result = acceptedAtRouteDetail.ToString();

        // Assert
        Assert.Contains($"Route Name: {routeName}", result);
        Assert.Contains($"Route Values: {routeValues}", result);
    }
}