using OnRails;
using OnRails.ResultDetails;

namespace OnRailTest;

public class ResultTest {
    [Fact]
    public void Ok_NoInput() {
        var result = Result.Ok();
        Assert.True(result.Success);
    }

    [Fact]
    public void Ok_WithDetail() {
        var resultDetail = new SuccessDetail("title");
        var result = Result.Ok(resultDetail);

        Assert.True(result.Success);
        Assert.StrictEqual(result.Detail, resultDetail);
    }

    [Fact]
    public void Fail() {
        var result = Result.Fail();

        Assert.False(result.Success);
    }
}

public class ResultWithValue {
    [Fact]
    public void Ok() {
        const string value = "value";
        var result = Result<string>.Ok(value);

        Assert.True(result.Success);
        Assert.Equal(result.Value, value);
    }

    [Fact]
    public void Ok_WithDetail() {
        var resultDetail = new SuccessDetail("title");
        const string value = "value";
        var result = Result<string>.Ok(value, resultDetail);

        Assert.True(result.Success);
        Assert.StrictEqual(result.Detail, resultDetail);
        Assert.Equal(result.Value, value);
    }

    [Fact]
    public void Fail() {
        var result = Result<string>.Fail();

        Assert.False(result.Success);
        Assert.Null(result.Value);
    }
}