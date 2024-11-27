using OnRails.ResultDetails.Success.Created;

namespace OnRailTest.ResultDetails.Success.Created;

public class CreatedAtActionDetailTest {
    [Fact]
    public void CreatedAtActionDetail_ConstructorWithActionName() {
        // Arrange
        const string actionName = "Create";

        // Act
        var createdAtActionDetail = new CreatedAtActionDetail(actionName);

        // Assert
        Assert.Equal(nameof(CreatedAtActionDetail), createdAtActionDetail.Title);
        Assert.Equal(actionName, createdAtActionDetail.ActionName);
        Assert.Null(createdAtActionDetail.ControllerName);
        Assert.Null(createdAtActionDetail.RouteValues);
    }

    [Fact]
    public void CreatedAtActionDetail_ConstructorWithActionNameAndControllerName() {
        // Arrange
        const string actionName = "Create";
        const string controllerName = "Resources";

        // Act
        var createdAtActionDetail = new CreatedAtActionDetail(actionName, controllerName);

        // Assert
        Assert.Equal(nameof(CreatedAtActionDetail), createdAtActionDetail.Title);
        Assert.Equal(actionName, createdAtActionDetail.ActionName);
        Assert.Equal(controllerName, createdAtActionDetail.ControllerName);
        Assert.Null(createdAtActionDetail.RouteValues);
    }

    [Fact]
    public void CreatedAtActionDetail_ConstructorWithActionNameControllerNameAndRouteValues() {
        // Arrange
        const string actionName = "Create";
        const string controllerName = "Resources";
        var routeValues = new { id = 1 };

        // Act
        var createdAtActionDetail = new CreatedAtActionDetail(actionName, controllerName, routeValues);

        // Assert
        Assert.Equal(nameof(CreatedAtActionDetail), createdAtActionDetail.Title);
        Assert.Equal(actionName, createdAtActionDetail.ActionName);
        Assert.Equal(controllerName, createdAtActionDetail.ControllerName);
        Assert.Equal(routeValues, createdAtActionDetail.RouteValues);
    }

    [Fact]
    public void CreatedAtActionDetail_ConstructorWithActionNameAndRouteValues() {
        // Arrange
        const string actionName = "Create";
        var routeValues = new { id = 1 };

        // Act
        var createdAtActionDetail = new CreatedAtActionDetail(actionName, routeValues);

        // Assert
        Assert.Equal(nameof(CreatedAtActionDetail), createdAtActionDetail.Title);
        Assert.Equal(actionName, createdAtActionDetail.ActionName);
        Assert.Null(createdAtActionDetail.ControllerName);
        Assert.Equal(routeValues, createdAtActionDetail.RouteValues);
    }

    [Fact]
    public void CreatedAtActionDetail_CustomFieldsToString() {
        // Arrange
        const string actionName = "Create";
        const string controllerName = "Resources";
        var routeValues = new { id = 1 };
        var createdAtActionDetail = new CreatedAtActionDetail(actionName, controllerName, routeValues);

        // Act
        var result = createdAtActionDetail.ToString();

        // Assert
        Assert.Contains($"Action Name: {actionName}", result);
        Assert.Contains($"Controller Name: {controllerName}", result);
        Assert.Contains($"Route Values: {routeValues}", result);
    }

    [Fact]
    public void CreatedAtActionDetail_CustomFieldsToString_WithNoControllerName() {
        // Arrange
        const string actionName = "Create";
        var routeValues = new { id = 1 };
        var createdAtActionDetail = new CreatedAtActionDetail(actionName, routeValues);

        // Act
        var result = createdAtActionDetail.ToString();

        // Assert
        Assert.Contains($"Action Name: {actionName}", result);
        Assert.Contains("Controller Name: ", result);
        Assert.Contains($"Route Values: {routeValues}", result);
    }

    [Fact]
    public void CustomFieldsToString_ShouldReturnLocation_WhenLocationIsSet() {
        // Arrange
        const string location = "/api/resource/123";
        var detail = new CreatedAtLocationDetail(location);

        // Act
        var result = detail.ToString();

        // Assert
        Assert.Contains($"Location: {location}", result);
    }

    [Fact]
    public void CustomFieldsToString_ShouldReturnLocationUri_WhenLocationUriIsSet() {
        // Arrange
        var locationUri = new Uri("https://example.com/api/resource/123");
        var detail = new CreatedAtLocationDetail(locationUri);

        // Act
        var result = detail.ToString();

        // Assert
        Assert.Contains($"Location: {locationUri}", result);
    }
}