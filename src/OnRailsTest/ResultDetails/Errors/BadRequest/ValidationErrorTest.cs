using OnRails.Models;
using OnRails.ResultDetails.Errors.BadRequest;

namespace OnRailTest.ResultDetails.Errors.BadRequest;

public class ValidationErrorTest {
    [Fact]
    public void Constructor_ShouldInitializeErrors_WhenSingleFieldErrorProvided() {
        // Arrange
        const string fieldName = "Email";
        const string fieldMessage = "Email is required.";

        // Act
        var error = new ValidationError(fieldName, fieldMessage);

        // Assert
        Assert.Contains(fieldName, error.Errors);
        Assert.Single(error.Errors[fieldName]);
        Assert.Equal(fieldMessage, error.Errors[fieldName].First());
    }

    [Fact]
    public void Constructor_ShouldInitializeErrors_WhenMultipleErrorsProvidedWithStringList() {
        // Arrange
        var errors = new Dictionary<string, string> {
            { "Email", "Email is required." },
            { "Username", "Username is too short." }
        };

        // Act
        var error = new ValidationError(errors);

        // Assert
        Assert.Equal(2, error.Errors.Count);
        Assert.Contains("Email", error.Errors);
        Assert.Contains("Username", error.Errors);
        Assert.Equal("Email is required.", error.Errors["Email"].First());
        Assert.Equal("Username is too short.", error.Errors["Username"].First());
    }

    [Fact]
    public void Constructor_ShouldInitializeErrors_WhenMultipleErrorsProvidedWithList() {
        // Arrange
        var errors = new Dictionary<string, List<string>> {
            { "Email", ["Email is required."] },
            { "Username", ["Username is too short."] }
        };

        // Act
        var error = new ValidationError(errors);

        // Assert
        Assert.Equal(2, error.Errors.Count);
        Assert.Contains("Email", error.Errors);
        Assert.Contains("Username", error.Errors);
        Assert.Equal("Email is required.", error.Errors["Email"].First());
        Assert.Equal("Username is too short.", error.Errors["Username"].First());
    }

    [Fact]
    public void GetViewModel_ShouldReturnCorrectModel_WhenErrorsPresent() {
        // Arrange
        var errors = new Dictionary<string, List<string>> {
            { "Email", ["Email is required."] },
            { "Username", ["Username is too short."] }
        };
        var error = new ValidationError(errors);

        // Act
        var viewModel = error.GetViewModel();

        // Assert
        Assert.Contains(nameof(ValidationError.Title), viewModel.Keys);
        Assert.Contains(nameof(ValidationError.Message), viewModel.Keys);
        Assert.Contains(nameof(ValidationError.Errors), viewModel.Keys);
        Assert.Equal(2, ((List<FieldErrors>)viewModel[nameof(ValidationError.Errors)]).Count);
    }

    [Fact]
    public void CustomFieldsToString_ShouldReturnFormattedString_WhenErrorsPresent() {
        // Arrange
        var errors = new Dictionary<string, List<string>> {
            { "Email", ["Email is required."] },
            { "Username", ["Username is too short.", "Username should lowercase."] }
        };
        var error = new ValidationError(errors);

        // Act
        var result = error.ToString();

        // Assert
        Assert.Contains("Errors: \n", result);
        Assert.Contains("- Email: Email is required.", result);
        Assert.Contains("- Username:", result);
        Assert.Contains("\tUsername is too short.", result);
        Assert.Contains("\tUsername should lowercase.", result);
    }
}