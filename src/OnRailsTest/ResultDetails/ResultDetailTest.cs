using OnRails.ResultDetails;

namespace OnRailTest.ResultDetails;

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
        Assert.Single(resultDetail.MoreDetails);
    }

    [Fact]
    public void ResultDetail_NullOrWhiteSpaceTitle_throwArgumentException() {
        Assert.Throws<ArgumentException>(() => new ResultDetail(null!));
        Assert.Throws<ArgumentException>(() => new ResultDetail(" "));
    }

    [Fact]
    public void AddDetail_GiveNewDetail_NewDetailAdded() {
        var resultDetail = new ResultDetail("title", moreDetails: new object());
        var beforeDetailsCount = resultDetail.MoreDetails.Count;

        resultDetail.AddDetail(new object());
        Assert.Equal(resultDetail.MoreDetails.Count, beforeDetailsCount + 1);
    }

    [Fact]
    public void GetMoreDetailProperties_GetExistObj_ReturnObject() {
        var result = new ResultDetail("Title");
        result.AddDetail(new { duplicate_Obj = "duplicate_Obj", obj2 = "obj2" });
        result.AddDetail(new { duplicate_Obj = "duplicate_Obj" });

        var objs = result.GetMoreDetailProperties<string>("obj2");
        Assert.Single(objs);
        Assert.Equal("obj2", objs.Single());

        Assert.Equal(2, result.GetMoreDetailProperties<string>("duplicate_Obj").Count);
    }

    [Fact]
    public void GetMoreDetailProperties_GetExistObjWithType_ReturnObject() {
        var result = new ResultDetail("Title");
        var list = new List<string> { "1", "2" };
        result.AddDetail(new { obj = "obj" });
        result.AddDetail(list);

        var objs = result.GetMoreDetailProperties<List<string>>();
        Assert.Single(objs);
        Assert.Equal(2, objs.Single().Count);
    }

    [Fact]
    public void GetMoreDetailProperties_GetNotExistObj_ReturnEmptyList() {
        var result = new ResultDetail("Title");
        result.AddDetail(new { obj1 = "obj1", obj2 = "obj2-exist" });
        result.AddDetail(new { obj3 = "obj3" });

        Assert.False(result.GetMoreDetailProperties<string>("not-exist").Any());
        Assert.False(result.GetMoreDetailProperties<int>("obj2-exist").Any()); //invalid type
    }

    [Fact]
    public void GetMoreDetailProperties_NoMoreDetails_ReturnEmptyList() {
        var result = new ResultDetail("Title");

        Assert.False(result.GetMoreDetailProperties<string>("not-exist").Any());
    }
}