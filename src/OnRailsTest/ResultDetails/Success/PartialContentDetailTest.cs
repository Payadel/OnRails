using Microsoft.AspNetCore.Http;
using OnRails.Models;
using OnRails.ResultDetails.Success;

namespace OnRailTest.ResultDetails.Success;

public class PartialContentDetailTest {
    [Fact]
    public void PartialContentDetail_DefaultValues() {
        // Arrange
        var partialContent = new PartialContentDetail();

        // Act & Assert
        Assert.Equal(nameof(PartialContentDetail), partialContent.Title);
        Assert.Equal("Partial content is returned successfully.", partialContent.Message);
        Assert.Equal(StatusCodes.Status206PartialContent, partialContent.StatusCode);
        Assert.Null(partialContent.Range);
        Assert.Empty(partialContent.MoreDetails);
        Assert.True(partialContent.View);
    }

    [Fact]
    public void PartialContentDetail_WithRangeData() {
        // Arrange
        var range = new RangeData(0, 99, 200); // Assuming RangeData constructor (start, end, total)
        var partialContent = new PartialContentDetail(range: range);

        // Act & Assert
        Assert.Equal(nameof(PartialContentDetail), partialContent.Title);
        Assert.Equal("Partial content is returned successfully.", partialContent.Message);
        Assert.Equal(StatusCodes.Status206PartialContent, partialContent.StatusCode);
        Assert.Equal(range, partialContent.Range);
    }

    [Fact]
    public void PartialContentDetail_GetViewModel() {
        // Arrange
        var range = new RangeData(0, 99, 200);
        var partialContent = new PartialContentDetail(range);

        // Act
        var viewModel = partialContent.GetViewModel();

        // Assert
        Assert.Equal(nameof(PartialContentDetail), viewModel[nameof(PartialContentDetail.Title)]);
        Assert.Equal("Partial content is returned successfully.", viewModel[nameof(PartialContentDetail.Message)]);
        Assert.Equal(range, viewModel[nameof(PartialContentDetail.Range)]);
    }

    [Fact]
    public void PartialContentDetail_CustomFieldsToString_WithRange() {
        // Arrange
        var range = new RangeData(0, 99, 200);
        var partialContent = new PartialContentDetail(range: range);

        // Act
        var result = partialContent.ToString();

        // Assert
        Assert.Contains($"Range: {range.Start}-{range.End} of {range.Total} bytes", result);
    }
}