using OnRails.ResultDetails.Success.Accepted;

namespace OnRailTest.ResultDetails.Success.Accepted;

public class AcceptedAtActionDetailTest {
    [Fact]
    public void AcceptedAtActionDetail_ActionOnly() {
        // Arrange
        const string actionName = "Create";

        // Act
        var acceptedAtActionDetail = new AcceptedAtActionDetail(actionName);

        // Assert
        Assert.Equal(actionName, acceptedAtActionDetail.ActionName);
        Assert.Null(acceptedAtActionDetail.ControllerName);
        Assert.Null(acceptedAtActionDetail.RouteValues);
    }

    [Fact]
    public void AcceptedAtActionDetail_ActionAndController() {
        // Arrange
        const string actionName = "Create";
        const string controllerName = "ProductController";

        // Act
        var acceptedAtActionDetail = new AcceptedAtActionDetail(actionName, controllerName);

        // Assert
        Assert.Equal(actionName, acceptedAtActionDetail.ActionName);
        Assert.Equal(controllerName, acceptedAtActionDetail.ControllerName);
        Assert.Null(acceptedAtActionDetail.RouteValues);
    }

    [Fact]
    public void AcceptedAtActionDetail_ActionControllerAndRouteValues() {
        // Arrange
        const string actionName = "Create";
        const string controllerName = "ProductController";
        var routeValues = new { id = 1, name = "Product1" };

        // Act
        var acceptedAtActionDetail = new AcceptedAtActionDetail(actionName, controllerName, routeValues);

        // Assert
        Assert.Equal(actionName, acceptedAtActionDetail.ActionName);
        Assert.Equal(controllerName, acceptedAtActionDetail.ControllerName);
        Assert.Equal(routeValues, acceptedAtActionDetail.RouteValues);
    }

    [Fact]
    public void AcceptedAtActionDetail_ActionAndRouteValues() {
        // Arrange
        const string actionName = "Create";
        var routeValues = new { id = 1, name = "Product1" };

        // Act
        var acceptedAtActionDetail = new AcceptedAtActionDetail(actionName, routeValues);

        // Assert
        Assert.Equal(actionName, acceptedAtActionDetail.ActionName);
        Assert.Null(acceptedAtActionDetail.ControllerName);
        Assert.Equal(routeValues, acceptedAtActionDetail.RouteValues);
    }

    [Fact]
    public void AcceptedAtActionDetail_ToStringTest() {
        // Arrange
        const string actionName = "Create";
        const string controllerName = "ProductController";
        var routeValues = new { id = 1, name = "Product1" };
        var acceptedAtActionDetail = new AcceptedAtActionDetail(actionName, controllerName, routeValues);

        // Act
        var result = acceptedAtActionDetail.ToString();

        // Assert
        Assert.Contains($"Action Name: {actionName}", result);
        Assert.Contains($"Controller Name: {controllerName}", result);
        Assert.Contains($"Route Values: {routeValues}", result);
    }
}