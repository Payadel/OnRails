using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails.Errors;

namespace OnRailTest.ResultDetails.Errors;

public class NotFoundErrorTest {
    [Fact]
    public void NotFoundError_DefaultValues() {
        // Arrange
        var notFoundError = new NotFoundError();

        // Act & Assert
        Assert.Equal(nameof(NotFoundError), notFoundError.Title);
        Assert.Equal("The requested resource(s) could not be found.", notFoundError.Message);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundError.StatusCode);
        Assert.Empty(notFoundError.Keys);
        Assert.Empty(notFoundError.MoreDetails);
        Assert.False(notFoundError.View);
    }

    [Fact]
    public void NotFoundError_CustomValues() {
        // Arrange
        const string title = "Custom Not Found Error";
        const string message = "The specified items could not be located.";
        var keys = new HashSet<string> { "Key1", "Key2" };
        var moreDetails = new { Hint = "Ensure IDs are valid." };
        const bool view = true;

        // Act
        var notFoundError = new NotFoundError(title, message, keys, moreDetails, view);

        // Assert
        Assert.Equal(title, notFoundError.Title);
        Assert.Equal(message, notFoundError.Message);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundError.StatusCode);
        Assert.Equal(keys, notFoundError.Keys);
        Assert.Single(notFoundError.MoreDetails);
        Assert.Equal(moreDetails, notFoundError.MoreDetails.First());
        Assert.True(notFoundError.View);
    }

    [Fact]
    public void NotFoundError_GetViewModel() {
        // Arrange
        const string title = "Custom Not Found Error";
        const string message = "The specified items could not be located.";
        var keys = new HashSet<string> { "Key1", "Key2" };
        var notFoundError = new NotFoundError(title, message, keys);

        // Act
        var viewModel = notFoundError.GetViewModel();

        // Assert
        Assert.Equal(title, viewModel[nameof(NotFoundError.Title)]);
        Assert.Equal(message, viewModel[nameof(NotFoundError.Message)]);
        Assert.Equal(keys.ToList(), viewModel[nameof(NotFoundError.Keys)]);
    }

    [Fact]
    public void NotFoundError_CustomFieldsToString_WithKeys() {
        // Arrange
        var keys = new HashSet<string> { "Key1", "Key2", "Key3" };
        var notFoundError = new NotFoundError(keys: keys);

        // Act
        var result = notFoundError.ToString();

        // Assert
        Assert.Contains("Key1", result);
        Assert.Contains("Key2", result);
        Assert.Contains("Key3", result);
    }

    [Fact]
    public void NotFoundError_CustomFieldsToString_NoKeys() {
        // Arrange
        var notFoundError = new NotFoundError();

        // Act
        var result = notFoundError.ToString();

        // Assert
        Assert.DoesNotContain($"{nameof(NotFoundError.Keys)}:\n", result);
    }
}