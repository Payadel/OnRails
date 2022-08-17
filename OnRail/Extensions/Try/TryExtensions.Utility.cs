using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions.Try;

public static partial class TryExtensions {
    //TODO: https://github.com/Payadel/OnRail/issues/16
    private static ExceptionError GenerateExceptionError(IReadOnlyCollection<Exception> exceptions, int numOfTry) {
        var lastItem = exceptions.Last();
        var failResult = new ExceptionError(lastItem, message: lastItem.Message, moreDetails: new {numOfTry});

        if (exceptions.Count > 1)
            failResult.AddDetail(exceptions);

        return failResult;
    }

    //TODO: https://github.com/Payadel/OnRail/issues/17

    private static Result AddNumOfTry(this Result result,
        int numOfTry, int maxTryRequested) {
        result.Detail.AddNumOfTry(numOfTry, maxTryRequested);
        return result;
    }

    private static Result<T> AddNumOfTry<T>(this Result<T> result,
        int numOfTry, int maxTryRequested) {
        result.Detail.AddNumOfTry(numOfTry, maxTryRequested);
        return result;
    }

    private static void AddNumOfTry(this ResultDetail detail,
        int numOfTry, int maxTryRequested) {
        detail.AddDetail(new {numOfTry, maxTryRequested});
    }
}