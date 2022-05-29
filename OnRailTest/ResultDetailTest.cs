using System;
using OnRail.ResultDetails;

namespace OnRailTest;

public class ResultDetailTest {
    [Fact]
    public void ResultDetail_OrderedInputs() {
        const string title = "title";
        const string message = "message";
        const int statusCode = 200;
        var obj = new object();
        
        var resultDetail = new ResultDetail(title, message, statusCode, obj);
        
        Assert.Equal(resultDetail.Title, title);
        Assert.Equal(resultDetail.Message, message);
        Assert.Equal(resultDetail.StatusCode, statusCode);
        Assert.Single(resultDetail.MoreDetails!);
    }

    [Fact]
    public void ResultDetail_NullOrWhiteSpaceTitle_throwArgumentException() {
        Assert.Throws<ArgumentException>(() => new ResultDetail(null!));
        Assert.Throws<ArgumentException>(() => new ResultDetail(" "));
    }

    [Fact]
    public void AddDetail_GiveNewDetail_NewDetailAdded() {
        var resultDetail = new ResultDetail("title", moreDetails: new object());
        var beforeDetailsCount = resultDetail.MoreDetails?.Count ?? 0;
        
        resultDetail.AddDetail(new object());
        Assert.Equal(resultDetail.MoreDetails?.Count, beforeDetailsCount + 1);
    }
}