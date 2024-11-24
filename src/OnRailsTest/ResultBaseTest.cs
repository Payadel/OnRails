using OnRails;
using OnRails.ResultDetails;

namespace OnRailTest;

public class TestResult(bool success, ResultDetail? detail = null) : ResultBase(success, detail);

public class ResultBaseTests {
    [Fact]
    public void HasStatusCode_ShouldReturnTrue_WhenDetailHasStatusCode() {
        // Arrange
        var detail = new ResultDetail("title", statusCode: 200);
        var result = new TestResult(true, detail);

        // Act
        var hasStatusCode = result.HasStatusCode;

        // Assert
        Assert.True(hasStatusCode);
    }

    [Fact]
    public void HasStatusCode_ShouldReturnFalse_WhenStatusCodeIsNull() {
        // Arrange
        var detail = new ResultDetail("title");
        var result = new TestResult(true, detail);

        // Act
        var hasStatusCode = result.HasStatusCode;

        // Assert
        Assert.False(hasStatusCode);
    }

    [Fact]
    public void HasStatusCode_ShouldReturnFalse_WhenDetailIsNull() {
        // Arrange
        var result = new TestResult(true);

        // Act
        var hasStatusCode = result.HasStatusCode;

        // Assert
        Assert.False(hasStatusCode);
    }

    [Fact]
    public void GetStatusCodeOrDefault_ShouldReturnStatusCode_WhenDetailHasStatusCode() {
        // Arrange
        var detail = new ResultDetail("title", statusCode: 200);
        var result = new TestResult(true, detail);

        // Act
        var statusCode = result.GetStatusCodeOrDefault(202, 400);

        // Assert
        Assert.Equal(200, statusCode);
    }

    [Fact]
    public void GetStatusCodeOrDefault_ShouldReturnDefaultSuccessCode_WhenNoDetail() {
        // Arrange
        var result = new TestResult(true);

        // Act
        var statusCode = result.GetStatusCodeOrDefault(200, 400);

        // Assert
        Assert.Equal(200, statusCode);
    }

    [Fact]
    public void GetStatusCodeOrDefault_ShouldReturnDefaultFailCode_WhenSuccessIsFalseAndNoDetail() {
        // Arrange
        var result = new TestResult(false, null);

        // Act
        var statusCode = result.GetStatusCodeOrDefault(200, 400);

        // Assert
        Assert.Equal(400, statusCode);
    }

    [Fact]
    public void HasDetail_ShouldReturnTrue_WhenDetailIsNotNull() {
        // Arrange
        var detail = new ResultDetail("title");
        var result = new TestResult(true, detail);

        // Act
        var hasDetail = result.HasDetail;

        // Assert
        Assert.True(hasDetail);
    }

    [Fact]
    public void HasDetail_ShouldReturnFalse_WhenDetailIsNull() {
        // Arrange
        var result = new TestResult(true, null);

        // Act
        var hasDetail = result.HasDetail;

        // Assert
        Assert.False(hasDetail);
    }

    [Fact]
    public void RemoveDetail_ShouldSetDetailToNull() {
        // Arrange
        var detail = new ResultDetail("title");
        var result = new TestResult(true, detail);

        // Act
        result.RemoveDetail();

        // Assert
        Assert.Null(result.Detail);
    }

    [Fact]
    public void IsDetailTypeOf_ShouldReturnTrue_WhenDetailIsOfType() {
        // Arrange
        var detail = new ResultDetail("title");
        var result = new TestResult(true, detail);

        // Act
        var isDetailTypeOf = result.IsDetailTypeOf(typeof(ResultDetail));

        // Assert
        Assert.True(isDetailTypeOf);
    }

    [Fact]
    public void IsDetailTypeOf_ShouldReturnFalse_WhenDetailIsNotOfType() {
        // Arrange
        var detail = new ResultDetail("title");
        var result = new TestResult(true, detail);

        // Act
        var isDetailTypeOf = result.IsDetailTypeOf(typeof(string));

        // Assert
        Assert.False(isDetailTypeOf);
    }

    [Fact]
    public void ToString_ShouldContainsSuccess_WhenDetailIsNull() {
        // Arrange
        var result = new TestResult(true);

        // Act
        var resultString = result.ToString();

        // Assert
        Assert.Contains("Success: True", resultString);
        Assert.DoesNotContain("Title", resultString);
    }

    [Fact]
    public void ToString_ShouldContainsDetail_WhenDetailIsNotNull() {
        // Arrange
        var detail = new ResultDetail("title");
        var result = new TestResult(true, detail);

        // Act
        var resultString = result.ToString();

        // Assert
        Assert.Contains("Success: True", resultString);
        Assert.Contains("Title: title", resultString); // Ensure there's no detail string
    }
}