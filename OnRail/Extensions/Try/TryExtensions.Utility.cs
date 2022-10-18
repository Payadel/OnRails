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
}