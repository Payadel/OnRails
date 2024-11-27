using OnRails.Models;

namespace OnRailTest.Models;

public class FieldErrorsTests {
    [Fact]
    public void Constructor_SingleMessage_ValidParameters_ShouldInitializeProperties() {
        // Arrange
        const string name = "FieldName";
        const string message = "Field is required.";

        // Act
        var fieldErrors = new FieldErrors(name, message);

        // Assert
        Assert.Equal(name, fieldErrors.Name);
        Assert.Single(fieldErrors.Messages);
        Assert.Contains(message, fieldErrors.Messages);
    }

    [Fact]
    public void Constructor_ListMessage_ValidParameters_ShouldInitializeProperties() {
        // Arrange
        const string name = "FieldName";
        var messages = new List<string> { "Error 1", "Error 2" };

        // Act
        var fieldErrors = new FieldErrors(name, messages);

        // Assert
        Assert.Equal(name, fieldErrors.Name);
        Assert.Equal(messages, fieldErrors.Messages);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_SingleMessage_InvalidName_ShouldThrowArgumentNullException(string? invalidName) {
        // Arrange
        const string message = "Field is required.";

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new FieldErrors(invalidName!, message));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_ListMessage_InvalidName_ShouldThrowArgumentNullException(string? invalidName) {
        // Arrange
        var messages = new List<string> { "Error 1" };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new FieldErrors(invalidName!, messages));
    }

    [Fact]
    public void Equality_SameName_ShouldBeEqual() {
        // Arrange
        var errors1 = new FieldErrors("FieldName", "Field is required.");
        var errors2 = new FieldErrors("FieldName", ["Another error."]);

        // Act & Assert
        Assert.Equal(errors1, errors2);
        Assert.True(errors1.Equals(errors2));
    }

    [Fact]
    public void Equality_DifferentName_ShouldNotBeEqual() {
        // Arrange
        var errors1 = new FieldErrors("FieldName1", "Field is required.");
        var errors2 = new FieldErrors("FieldName2", "Field is required.");

        // Act & Assert
        Assert.NotEqual(errors1, errors2);
        Assert.False(errors1.Equals(errors2));
    }

    [Fact]
    public void ToString_ShouldReturnExpectedFormat() {
        // Arrange
        const string name = "FieldName";
        var messages = new List<string> { "Error 1", "Error 2" };
        var fieldErrors = new FieldErrors(name, messages);

        // Act
        var result = fieldErrors.ToString();

        // Assert
        Assert.Equal("FieldName:\n\tError 1\n\tError 2",
            result);
    }
}