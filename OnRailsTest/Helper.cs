using OnRails;
using OnRails.ResultDetails;

namespace OnRailTest;

internal static class Helper {
    public static void EnsureHasFailed(ResultBase result, int numOfTry, bool hasExceptionType) {
        Assert.False(result.Success);
        Assert.True(result.Detail is not null);
        Assert.True(result.Detail is ErrorDetail);
        var errorDetail = result.Detail as ErrorDetail;

        if (numOfTry > 0)
            Assert.True(errorDetail!.MoreDetails.Count >= numOfTry);
    }
}