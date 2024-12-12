using OnRails.Models;
using OnRails.ResultDetails.Errors.BadRequest;

namespace OnRailTest.ResultDetails.Errors.BadRequest;

public class ConflictErrorTest {
    [Fact]
    public void Constructor_ShouldInitializeErrors_WhenSingleFieldErrorProvided() {
        // Arrange
        var fieldName = "Username";
        var fieldMessage = "Username conflicts with an existing record.";

        // Act
        var error = new ConflictError(fieldName, fieldMessage);

        // Assert
        Assert.Contains(fieldName, error.Errors);
        Assert.Single(error.Errors[fieldName]);
        Assert.Equal(fieldMessage, error.Errors[fieldName].First());
    }

    [Fact]
    public void Constructor_ShouldInitializeErrors_WhenMultipleErrorsProvidedWithStringList() {
        // Arrange
        var errors = new Dictionary<string, string> {
            { "Username", "Username conflicts with an existing record." },
            { "Email", "Email already exists." }
        };

        // Act
        var error = new ConflictError(errors);

        // Assert
        Assert.Equal(2, error.Errors.Count);
        Assert.Contains("Username", error.Errors);
        Assert.Contains("Email", error.Errors);
        Assert.Equal("Username conflicts with an existing record.", error.Errors["Username"].First());
        Assert.Equal("Email already exists.", error.Errors["Email"].First());
    }

    [Fact]
    public void Constructor_ShouldInitializeErrors_WhenMultipleErrorsProvidedWithList() {
        // Arrange
        var errors = new Dictionary<string, List<string>> {
            { "Username", ["Username conflicts with an existing record."] },
            { "Email", ["Email already exists."] }
        };

        // Act
        var error = new ConflictError(errors);

        // Assert
        Assert.Equal(2, error.Errors.Count);
        Assert.Contains("Username", error.Errors);
        Assert.Contains("Email", error.Errors);
        Assert.Equal("Username conflicts with an existing record.", error.Errors["Username"].First());
        Assert.Equal("Email already exists.", error.Errors["Email"].First());
    }

    [Fact]
    public void GetViewModel_ShouldReturnCorrectModel_WhenErrorsPresent() {
        // Arrange
        var errors = new Dictionary<string, List<string>> {
            { "Username", ["Username conflicts with an existing record."] },
            { "Email", ["Email already exists."] }
        };
        var error = new ConflictError(errors);

        // Act
        var viewModel = error.GetViewModel();

        // Assert
        Assert.Contains(nameof(ConflictError.Title), viewModel.Keys);
        Assert.Contains(nameof(ConflictError.Message), viewModel.Keys);
        Assert.Contains(nameof(ConflictError.Errors), viewModel.Keys);
        Assert.Equal(2, ((List<FieldErrors>)viewModel[nameof(ConflictError.Errors)]).Count);
    }

    [Fact]
    public void CustomFieldsToString_ShouldReturnFormattedString_WhenErrorsPresent() {
        // Arrange
        var errors = new Dictionary<string, List<string>> {
            { "Email", ["Email is required."] },
            { "Username", ["Username is too short.", "Username should lowercase."] }
        };
        var error = new ConflictError(errors);

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