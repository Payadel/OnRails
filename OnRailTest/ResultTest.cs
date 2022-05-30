using OnRail;
using OnRail.ResultDetails;

namespace OnRailTest.Result;

public class ResultTest {
    [Fact]
    public void Ok_NoInput() {
        var result = OnRail.Result.Ok();
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Ok_WithDetail() {
        var resultDetail = new ResultDetail("title");
        var result = OnRail.Result.Ok(resultDetail);

        Assert.True(result.IsSuccess);
        Assert.StrictEqual(result.Detail, resultDetail);
    }

    [Fact]
    public void Fail() {
        var result = OnRail.Result.Fail();

        Assert.False(result.IsSuccess);
    }
}

public class ResultWithValue {
    [Fact]
    public void Ok() {
        const string value = "value";
        var result = Result<string>.Ok(value);

        Assert.True(result.IsSuccess);
        Assert.Equal(result.Value, value);
    }

    [Fact]
    public void Ok_WithDetail() {
        var resultDetail = new ResultDetail("title");
        const string value = "value";
        var result = Result<string>.Ok(value, resultDetail);

        Assert.True(result.IsSuccess);
        Assert.StrictEqual(result.Detail, resultDetail);
        Assert.Equal(result.Value, value);
    }

    [Fact]
    public void Fail() {
        var result = Result<string>.Fail();

        Assert.False(result.IsSuccess);
        Assert.Null(result.Value);
    }
}