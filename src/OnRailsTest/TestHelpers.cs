using OnRails;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRailTest;

internal static class TestHelpers {
    public static void EnsureHasFailed(ResultBase result, int numOfTry, bool hasExceptionType) {
        Assert.False(result.Success);
        Assert.True(result.Detail is not null);
        Assert.True(result.Detail is ErrorDetail);
        var errorDetail = result.Detail as ErrorDetail;

        if (numOfTry > 0)
            Assert.True(errorDetail!.MoreDetails.Count >= numOfTry);
    }

    public static void ThrowException() => throw new Exception("Fake");

    public static Result FailResult() => TryExtensions.Try(() => {
        TestHelpers.ThrowException();
        return Result.Ok();
    }, 1);
}