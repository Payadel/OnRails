using OnRails.ResultDetails.Success.Created;

namespace OnRailTest.ResultDetails.Success.Created;

public class CreatedAtRouteDetailTest {
    [Fact]
    public void CreatedAtRouteDetail_DefaultConstructor() {
        // Arrange
        var routeValues = new { Id = 1, Name = "Test" };

        // Act
        var createdAtRouteDetail = new CreatedAtRouteDetail(routeValues);

        // Assert
        Assert.Equal(nameof(CreatedAtRouteDetail), createdAtRouteDetail.Title);
        Assert.Equal(routeValues, createdAtRouteDetail.RouteValues);
        Assert.Null(createdAtRouteDetail.RouteName);
    }

    [Fact]
    public void CreatedAtRouteDetail_ConstructorWithRouteName() {
        // Arrange
        const string routeName = "TestRoute";
        var routeValues = new { Id = 1, Name = "Test" };

        // Act
        var createdAtRouteDetail = new CreatedAtRouteDetail(routeName, routeValues);

        // Assert
        Assert.Equal(nameof(CreatedAtRouteDetail), createdAtRouteDetail.Title);
        Assert.Equal(routeName, createdAtRouteDetail.RouteName);
        Assert.Equal(routeValues, createdAtRouteDetail.RouteValues);
    }


    [Fact]
    public void CreatedAtRouteDetail_CustomFieldsToString_WithRouteName() {
        // Arrange
        const string routeName = "TestRoute";
        var routeValues = new { Id = 1, Name = "Test" };
        var createdAtRouteDetail = new CreatedAtRouteDetail(routeName, routeValues);

        // Act
        var result = createdAtRouteDetail.ToString();

        // Assert
        Assert.Contains("Route Name: TestRoute", result);
        Assert.Contains("Route Values: { Id = 1, Name = Test }", result);
    }
}