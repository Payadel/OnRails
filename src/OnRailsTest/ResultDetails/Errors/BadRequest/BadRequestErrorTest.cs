using OnRails.Models;
using OnRails.ResultDetails.Errors.BadRequest;

namespace OnRailTest.ResultDetails.Errors.BadRequest;

public class BadRequestErrorTest {
    [Fact]
    public void Constructor_ShouldInitializeErrors_WhenSingleFieldErrorProvided() {
        // Arrange
        const string fieldName = "Username";
        const string fieldMessage = "Username is required.";

        // Act
        var error = new BadRequestError(fieldName, fieldMessage);

        // Assert
        Assert.Contains(fieldName, error.Errors);
        Assert.Single(error.Errors[fieldName]);
        Assert.Equal(fieldMessage, error.Errors[fieldName].First());
    }

    [Fact]
    public void Constructor_ShouldInitializeErrors_WhenMultipleErrorsProvided() {
        // Arrange
        var errors = new Dictionary<string, List<string>> {
            { "Username", ["Username is required."] },
            { "Email", ["Email is invalid."] }
        };

        // Act
        var error = new BadRequestError(errors);

        // Assert
        Assert.Equal(2, error.Errors.Count);
        Assert.Contains("Username", error.Errors);
        Assert.Contains("Email", error.Errors);
        Assert.Equal("Username is required.", error.Errors["Username"].First());
        Assert.Equal("Email is invalid.", error.Errors["Email"].First());
    }

    [Fact]
    public void GetViewModel_ShouldReturnCorrectModel_WhenErrorsPresent() {
        // Arrange
        var errors = new Dictionary<string, List<string>> {
            { "Username", ["Username is required."] },
            { "Email", ["Email is invalid."] }
        };
        var error = new BadRequestError(errors);

        // Act
        var viewModel = error.GetViewModel();

        // Assert
        Assert.Contains(nameof(BadRequestError.Title), viewModel.Keys);
        Assert.Contains(nameof(BadRequestError.Message), viewModel.Keys);
        Assert.Contains(nameof(BadRequestError.Errors), viewModel.Keys);
        Assert.Equal(2, ((List<FieldErrors>)viewModel[nameof(BadRequestError.Errors)]).Count);
    }

    [Fact]
    public void CustomFieldsToString_ShouldReturnFormattedString_WhenErrorsPresent() {
        // Arrange
        var errors = new Dictionary<string, List<string>> {
            { "Email", ["Email is required."] },
            { "Username", ["Username is too short.", "Username should lowercase."] }
        };
        var error = new BadRequestError(errors);

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