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

        Assert.Equal(title, resultDetail.Title);
        Assert.Equal(message, resultDetail.Message);
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

        Assert.Empty(result.GetMoreDetailProperties<string>("not-exist"));
        Assert.Empty(result.GetMoreDetailProperties<int>("obj2-exist")); //invalid type
    }

    [Fact]
    public void GetMoreDetailProperties_NoMoreDetails_ReturnEmptyList() {
        var result = new ResultDetail("Title");

        Assert.Empty(result.GetMoreDetailProperties<string>("not-exist"));
    }


    [Fact]
    public void IsTypeOf_MatchingType_ReturnsTrue() {
        // Arrange
        var resultDetail = new ResultDetail("Title");

        // Act
        var isTypeOfResultDetail = resultDetail.IsTypeOf(typeof(ResultDetail));

        // Assert
        Assert.True(isTypeOfResultDetail);
    }

    [Fact]
    public void IsTypeOf_DerivedType_ReturnsFalse() {
        // Arrange
        var resultDetail = new ResultDetail("Title");

        // Act
        var isTypeOfErrorDetail = resultDetail.IsTypeOf(typeof(ErrorDetail));

        // Assert
        Assert.False(isTypeOfErrorDetail);
    }

    [Fact]
    public void GetViewModel_ReturnsCorrectDictionary() {
        // Arrange
        const string title = "Sample Title";
        const string message = "Sample Message";
        var resultDetail = new ResultDetail(title, message);

        // Act
        var viewModel = resultDetail.GetViewModel();

        // Assert
        Assert.NotNull(viewModel);
        Assert.Equal(title, viewModel[nameof(ResultDetail.Title)]);
        Assert.Equal(message, viewModel[nameof(ResultDetail.Message)]);
    }

    [Fact]
    public void ToString_ContainsAllProperties() {
        // Arrange
        const string title = "Sample Title";
        const string message = "Sample Message";
        const int statusCode = 200;
        var resultDetail = new ResultDetail(title, message, statusCode, moreDetails: "extra detail");

        // Act
        var resultString = resultDetail.ToString();

        // Assert
        Assert.Contains($"Title: {title}", resultString);
        Assert.Contains($"Message: {message}", resultString);
        Assert.Contains($"Status Code: {statusCode}", resultString);
        Assert.Contains($"MoreDetails:", resultString);
        Assert.Contains($"extra detail", resultString);
    }
}