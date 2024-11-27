using Microsoft.AspNetCore.Http;
using OnRails.ResultDetails;

namespace OnRailTest.ResultDetails;

public class ErrorDetailTest {
    [Fact]
    public void ErrorDetail_DefaultValues() {
        // Arrange
        const string expectedTitle = nameof(ErrorDetail);
        const string expectedMessage = "An error occurred";
        const int expectedStatusCode = StatusCodes.Status500InternalServerError;

        // Act
        var errorDetail = new ErrorDetail();

        // Assert
        Assert.Equal(expectedTitle, errorDetail.Title);
        Assert.Equal(expectedMessage, errorDetail.Message);
        Assert.Equal(expectedStatusCode, errorDetail.StatusCode);
        Assert.Empty(errorDetail.MoreDetails);
    }

    [Fact]
    public void ErrorDetail_StackTrace_GeneratedCorrectly() {
        // Act
        var fail = TestHelpers.FailResult();
        var errorDetail = (ErrorDetail)fail.Detail!;
        var stackTrace = errorDetail.StackTrace.ToString();

        // Assert
        Assert.NotNull(stackTrace);
        Assert.Contains(nameof(ErrorDetailTest), stackTrace);
    }

    [Fact]
    public void ErrorDetail_ToString_IncludesBaseDetailsAndStackTrace() {
        // Arrange
        var errorDetail = new ErrorDetail("CustomTitle", "CustomMessage", 500);

        // Act
        var toStringResult = errorDetail.ToString();

        // Assert
        Assert.Contains("CustomTitle", toStringResult);
        Assert.Contains("CustomMessage", toStringResult);
        Assert.Contains("Status Code: 500", toStringResult);
        Assert.Contains("View: False", toStringResult);
        Assert.Contains("StackTrace:", toStringResult);
        Assert.Contains(nameof(ErrorDetailTest), toStringResult); // Ensure stack trace includes the test class
    }

    [Fact]
    public void ErrorDetail_CustomDetails_AreIncluded() {
        // Arrange
        var customDetails = new { Detail = "AdditionalInfo" };
        var errorDetail = new ErrorDetail("Title", "Message", 400, customDetails);

        // Assert
        Assert.Single(errorDetail.MoreDetails);
        Assert.Contains(customDetails, errorDetail.MoreDetails);
    }
}