using OnRails.Models;

namespace OnRailTest.Models;

public class RangeDataTest {
    [Fact]
    public void Constructor_ValidInput_SetsProperties() {
        // Arrange
        const long start = 0;
        const long end = 499;
        const long total = 1000;

        // Act
        var range = new RangeData(start, end, total);

        // Assert
        Assert.Equal(start, range.Start);
        Assert.Equal(end, range.End);
        Assert.Equal(total, range.Total);
    }

    [Fact]
    public void Constructor_NegativeValues_ThrowsArgumentException() {
        // Arrange
        const long start = -1;
        const long end = 499;
        const long total = 1000;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new RangeData(start, end, total));
    }

    [Fact]
    public void Constructor_StartGreaterThanEnd_ThrowsArgumentException() {
        // Arrange
        const long start = 500;
        const long end = 499;
        const long total = 1000;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new RangeData(start, end, total));
    }

    [Fact]
    public void ToString_ValidRange_ReturnsCorrectString() {
        // Arrange
        const long start = 0;
        const long end = 499;
        const long total = 1000;
        var range = new RangeData(start, end, total);

        // Act
        var result = range.ToString();

        // Assert
        Assert.Equal("Range: 0-499 of 1000 bytes", result);
    }

    [Fact]
    public void Constructor_ValidInputWithStartEqualToEnd_SetsProperties() {
        // Arrange
        const long start = 100;
        const long end = 100;
        const long total = 500;

        // Act
        var range = new RangeData(start, end, total);

        // Assert
        Assert.Equal(start, range.Start);
        Assert.Equal(end, range.End);
        Assert.Equal(total, range.Total);
    }

    [Fact]
    public void Objects_WithSameProperties_ShouldBeEqual() {
        // Arrange
        var range1 = new RangeData(0, 100, 200);
        var range2 = new RangeData(0, 100, 200);

        // Act & Assert
        Assert.Equal(range1, range2); // Value equality using Assert.Equal
        Assert.True(range1 == range2); // Equality operator
        Assert.True(range1.Equals(range2)); // Equals method
    }

    [Fact]
    public void Objects_WithDifferentProperties_ShouldNotBeEqual() {
        // Arrange
        var range1 = new RangeData(0, 100, 200);
        var range2 = new RangeData(0, 100, 300); // Different Total
        var range3 = new RangeData(10, 100, 200); // Different Start
        var range4 = new RangeData(0, 90, 200); // Different End

        // Act & Assert
        Assert.NotEqual(range1, range2);
        Assert.NotEqual(range1, range3);
        Assert.NotEqual(range1, range4);

        Assert.False(range1 == range2);
        Assert.False(range1 == range3);
        Assert.False(range1 == range4);

        Assert.False(range1.Equals(range2));
        Assert.False(range1.Equals(range3));
        Assert.False(range1.Equals(range4));
    }
}