using Microsoft.AspNetCore.Http;
using OnRails;
using OnRails.ResultDetails;

namespace OnRailTest;

public class ResultTests {
    [Fact]
    public void Ok_ShouldCreateResultWithSuccessTrue() {
        // Act
        var result = Result.Ok();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Null(result.Detail);
    }

    [Fact]
    public void Ok_WithDetail_ShouldCreateResultWithSuccessTrueAndDetail() {
        // Arrange
        var detail = new SuccessDetail(view: true);

        // Act
        var result = Result.Ok(detail);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(detail, result.Detail);
    }

    [Fact]
    public void Fail_ShouldCreateResultWithSuccessFalse() {
        // Act
        var result = Result.Fail();

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
        Assert.Null(result.Detail);
    }

    [Fact]
    public void Fail_WithDetail_ShouldCreateResultWithSuccessFalseAndDetail() {
        // Arrange
        var detail = new ErrorDetail();

        // Act
        var result = Result.Fail(detail);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
        Assert.Equal(detail, result.Detail);
    }

    [Fact]
    public void GetViewValue_ShouldReturnNull_IfNoDetailExists() {
        // Arrange
        var result = Result.Ok();

        // Act
        var viewValue = result.GetViewValue();

        // Assert
        Assert.Null(viewValue);
    }

    [Fact]
    public void GetViewValue_ShouldReturnViewModel_IfDetailExistsWithViewAccess() {
        // Arrange
        var detail = new SuccessDetail(view: true);
        var result = Result.Ok(detail);

        // Act
        var viewValue = result.GetViewValue();

        // Assert
        Assert.NotNull(viewValue);
        Assert.Equal(detail.GetViewModel(), viewValue);
    }

    [Fact]
    public void GetViewValue_ShouldReturnNull_IfDetailExistsWithoutViewAccess() {
        // Arrange
        var detail = new SuccessDetail(view: false);
        var result = Result.Ok(detail);

        // Act
        var viewValue = result.GetViewValue();

        // Assert
        Assert.Null(viewValue);
    }

    [Fact]
    public void GetViewStatusCode_ShouldReturn204_WhenNoDetailExistsAndSuccessIsTrue() {
        // Arrange
        var result = Result.Ok();

        // Act
        var statusCode = result.GetViewStatusCode();

        // Assert
        Assert.Equal(StatusCodes.Status204NoContent, statusCode);
    }

    [Fact]
    public void GetViewStatusCode_ShouldReturn500_WhenNoDetailExistsAndSuccessIsFalse() {
        // Arrange
        var result = Result.Fail();

        // Act
        var statusCode = result.GetViewStatusCode();

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCode);
    }

    [Fact]
    public void GetViewStatusCode_ShouldReturnStatusCodeFromDetail_WhenDetailHasViewAccess() {
        // Arrange
        var detail = new SuccessDetail(view: true, statusCode: StatusCodes.Status201Created);
        var result = Result.Ok(detail);

        // Act
        var statusCode = result.GetViewStatusCode();

        // Assert
        Assert.Equal(StatusCodes.Status201Created, statusCode);
    }

    [Fact]
    public void GetViewStatusCode_ShouldReturn500_WhenDetailExistsWithoutViewAccess() {
        // Arrange
        var detail = new ErrorDetail(view: false, statusCode: 505);
        var result = Result.Fail(detail);

        // Act
        var statusCode = result.GetViewStatusCode();

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCode);
    }
}

public class ResultWithValueTest {
    [Fact]
    public void Ok_ShouldCreateResultWithSuccessTrueAndValue() {
        // Arrange
        const string value = "TestValue";

        // Act
        var result = Result<string>.Ok(value);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(value, result.Value);
        Assert.Null(result.Detail);
    }

    [Fact]
    public void Ok_WithDetail_ShouldCreateResultWithSuccessTrueValueAndDetail() {
        // Arrange
        const string value = "TestValue";
        var detail = new SuccessDetail(view: true);

        // Act
        var result = Result<string>.Ok(value, detail);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(value, result.Value);
        Assert.Equal(detail, result.Detail);
    }

    [Fact]
    public void Fail_ShouldCreateResultWithSuccessFalseAndNullValue() {
        // Act
        var result = Result<string>.Fail();

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
        Assert.Null(result.Value);
        Assert.Null(result.Detail);
    }

    [Fact]
    public void Fail_WithDetail_ShouldCreateResultWithSuccessFalseAndDetail() {
        // Arrange
        var detail = new ErrorDetail();

        // Act
        var result = Result<string>.Fail(detail);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
        Assert.Null(result.Value);
        Assert.Equal(detail, result.Detail);
    }

    [Fact]
    public void GetViewValue_ShouldReturnValue_WhenSuccessIsTrue() {
        // Arrange
        const string value = "TestValue";
        var result = Result<string>.Ok(value);

        // Act
        var viewValue = result.GetViewValue();

        // Assert
        Assert.Equal(value, viewValue);
    }

    [Fact]
    public void GetViewValue_ShouldReturnNull_WhenNoDetailExistsAndSuccessIsFalse() {
        // Arrange
        var result = Result<string>.Fail();

        // Act
        var viewValue = result.GetViewValue();

        // Assert
        Assert.Null(viewValue);
    }

    [Fact]
    public void GetViewValue_ShouldReturnViewModel_WhenDetailExistsWithViewAccessAndSuccessIsFalse() {
        // Arrange
        var detail = new ErrorDetail(view: true);
        var result = Result<string>.Fail(detail);

        // Act
        var viewValue = result.GetViewValue();

        // Assert
        Assert.NotNull(viewValue);
        Assert.Equal(detail.GetViewModel(), viewValue);
    }

    [Fact]
    public void GetViewStatusCode_ShouldReturn200_WhenValueExistsAndSuccessIsTrue() {
        // Arrange
        const string value = "TestValue";
        var result = Result<string>.Ok(value);

        // Act
        var statusCode = result.GetViewStatusCode();

        // Assert
        Assert.Equal(StatusCodes.Status200OK, statusCode);
    }

    [Fact]
    public void GetViewStatusCode_ShouldReturn204_WhenValueIsNullAndSuccessIsTrue() {
        // Arrange
        var result = Result<string?>.Ok(null);

        // Act
        var statusCode = result.GetViewStatusCode();

        // Assert
        Assert.Equal(StatusCodes.Status204NoContent, statusCode);
    }

    [Fact]
    public void GetViewStatusCode_ShouldReturn500_WhenSuccessIsFalse() {
        // Arrange
        var result = Result<string>.Fail();

        // Act
        var statusCode = result.GetViewStatusCode();

        // Assert
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCode);
    }

    [Fact]
    public void GetViewStatusCode_ShouldReturnDetailStatusCode_WhenDetailExistsWithViewAccess() {
        // Arrange
        var detail = new ErrorDetail(view: true, statusCode: StatusCodes.Status404NotFound);
        var result = Result<string>.Fail(detail);

        // Act
        var statusCode = result.GetViewStatusCode();

        // Assert
        Assert.Equal(StatusCodes.Status404NotFound, statusCode);
    }

    [Fact]
    public void ToString_ShouldIncludeSuccessAndValue_WhenSuccessIsTrue() {
        // Arrange
        const string value = "TestValue";
        var result = Result<string>.Ok(value);

        // Act
        var resultString = result.ToString();

        // Assert
        Assert.Contains("Success: True", resultString);
        Assert.Contains($"Value: {value}", resultString);
    }

    [Fact]
    public void ToString_ShouldIncludeSuccessAndDetail_WhenSuccessIsFalse() {
        // Arrange
        var detail = new ErrorDetail(view: true, statusCode: StatusCodes.Status404NotFound);
        var result = Result<string>.Fail(detail);

        // Act
        var resultString = result.ToString();

        // Assert
        Assert.Contains("Success: False", resultString);
        Assert.Contains(detail.ToString(), resultString);
    }
}