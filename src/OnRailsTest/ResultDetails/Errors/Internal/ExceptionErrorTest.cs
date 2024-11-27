using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails.Errors.Internal;

namespace OnRailTest.ResultDetails.Errors.Internal;

public class ExceptionErrorTest {
    [Fact]
    public void ExceptionError_DefaultValues() {
        // Arrange
        var exception = new Exception("An unexpected error occurred.");
        var exceptionError = new ExceptionError(exception);

        // Act & Assert
        Assert.Equal($"{nameof(ExceptionError)} - An unexpected error occurred.", exceptionError.Title);
        Assert.Equal(exception.Message, exceptionError.Message);
        Assert.Equal(StatusCodes.Status500InternalServerError, exceptionError.StatusCode);
        Assert.Empty(exceptionError.MoreDetails);
        Assert.False(exceptionError.View);
        Assert.Equal(exception, exceptionError.Exception);
    }

    [Fact]
    public void ExceptionError_CustomFieldsToString() {
        // Arrange
        var exception = new Exception("Custom exception message");
        var exceptionError = new ExceptionError(exception);

        // Act
        var result = exceptionError.ToString();

        // Assert
        Assert.Contains(exception.ToString(), result);
    }

    [Fact]
    public void ExceptionError_IsTypeOf_WithType() {
        // Arrange
        var exception = new Exception("Custom exception message");
        var exceptionError = new ExceptionError(exception);

        // Act & Assert
        Assert.True(exceptionError.IsTypeOf(typeof(ExceptionError)));
        Assert.True(exceptionError.IsTypeOf(typeof(Exception)));
    }

    [Fact]
    public void ExceptionError_IsTypeOf_WithGenericType() {
        // Arrange
        var exception = new Exception("Custom exception message");
        var exceptionError = new ExceptionError(exception);

        // Act & Assert
        Assert.True(exceptionError.IsTypeOf<ExceptionError>());
        Assert.True(exceptionError.IsTypeOf<Exception>());
    }
}