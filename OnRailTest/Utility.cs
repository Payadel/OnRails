using OnRail;
using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;

namespace OnRailTest;

public static class Utility {
    private static void EnsureIsError(ResultBase result, int numOfTry) {
        Assert.False(result.IsSuccess);

        var detailsCount = result.Detail.MoreDetails?.Count;
        if (numOfTry > 1) {
            //We must have two objects: numOfTry - errors
            Assert.Equal(2, detailsCount);
        }
        else {
            //We must have only "numOfTry"
            Assert.Equal(1, detailsCount);
        }

        Assert.Equal(numOfTry, result.Detail.GetMoreDetailProperties<int>("numOfTry").Single());
    }

    public static void EnsureIsExceptionError(ResultBase result, int numOfTry) {
        EnsureIsError(result, numOfTry);
        Assert.True(result.Detail is ExceptionError);

        if (numOfTry < 2)
            return;

        var exceptions =
            result.Detail.GetMoreDetailProperties<List<Exception>>().Single() as List<Exception>;
        Assert.Equal(numOfTry, exceptions!.Count);
    }

    public static void EnsureIsErrorDetail(ResultBase result, int numOfTry) {
        EnsureIsError(result, numOfTry);

        Assert.True(result.Detail is ErrorDetail);
        var exceptions =
            result.Detail.GetMoreDetailProperties<List<object>>().Single() as List<object>;
        Assert.Equal(numOfTry, exceptions!.Count);
    }
}