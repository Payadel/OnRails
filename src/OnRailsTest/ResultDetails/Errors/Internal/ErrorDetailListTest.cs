using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails;
using OnRails.ResultDetails.Errors;
using OnRails.ResultDetails.Errors.Internal;

namespace OnRailTest.ResultDetails.Errors.Internal;

public class ErrorDetailListTest {
    [Fact]
    public void ErrorDetailList_DefaultValues() {
        // Arrange
        var errorList = new ErrorDetailList([]);

        // Act & Assert
        Assert.Equal(nameof(ErrorDetailList), errorList.Title);
        Assert.Equal("One or more error(s) occurred", errorList.Message);
        Assert.Equal(StatusCodes.Status500InternalServerError, errorList.StatusCode);
        Assert.Empty(errorList.Errors);
    }

    [Fact]
    public void ErrorDetailList_WithErrors() {
        // Arrange
        var error1 = new ErrorDetail("Error 1", "First error occurred", StatusCodes.Status400BadRequest);
        var error2 = new ErrorDetail("Error 2", "Second error occurred", StatusCodes.Status404NotFound);
        var errorList = new ErrorDetailList([error1, error2]);

        // Act & Assert
        Assert.Equal(2, errorList.Errors.Count);
        Assert.Contains(error1, errorList.Errors);
        Assert.Contains(error2, errorList.Errors);
    }

    [Fact]
    public void ErrorDetailList_CustomFieldsToString_WithErrors() {
        // Arrange
        var error1 = new ErrorDetail("Error 1", "First error occurred", StatusCodes.Status400BadRequest);
        var error2 = new ErrorDetail("Error 2", "Second error occurred", StatusCodes.Status404NotFound);
        var errorList = new ErrorDetailList([error1, error2]);

        // Act
        var result = errorList.ToString();

        // Assert
        Assert.Contains("Errors:", result);
        Assert.Contains(error1.ToString(), result);
        Assert.Contains(error2.ToString(), result);
    }

    [Fact]
    public void ErrorDetailList_IsTypeOf() {
        // Arrange
        var error1 = new ErrorDetail("Error 1", "First error occurred", StatusCodes.Status400BadRequest);
        var errorList = new ErrorDetailList([error1]);

        // Act & Assert
        Assert.True(errorList.IsTypeOf<ErrorDetail>());
        Assert.False(errorList.IsTypeOf<UnauthorizedError>());
    }

    [Fact]
    public void ErrorDetailList_GetViewModel() {
        // Arrange
        var error1 = new ErrorDetail("Error 1", "First error occurred", StatusCodes.Status400BadRequest);
        var error2 = new ErrorDetail("Error 2", "Second error occurred", StatusCodes.Status404NotFound);
        var errorList = new ErrorDetailList([error1, error2]);

        // Act
        var viewModel = errorList.GetViewModel();

        // Assert
        Assert.Equal(nameof(ErrorDetailList), viewModel[nameof(ErrorDetailList.Title)]);
        Assert.Equal("One or more error(s) occurred", viewModel[nameof(ErrorDetailList.Message)]);
    }
}