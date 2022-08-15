using OnRail.Extensions.OnFail;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.SelectResults;

public static partial class SelectResultsExtensions {
    public static Result<List<TResult>> SelectResults<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) {
        var thisList = @this.ToList();

        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            var result = item.Try(function, numOfTry)
                .OnFail(result => result.Detail.AddDetail(new {thisObj = thisList, targetItem = item}));
            if (!result.IsSuccess)
                return Result<List<TResult>>.Fail(result.Detail);

            selectedResult.Add(result.Value!);
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }

    public static Result<List<TResult>> SelectResults<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        var thisList = @this.ToList();

        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            var result = item.Try(function, numOfTry)
                .OnFail(result => result.Detail.AddDetail(new {thisObj = thisList, targetItem = item}));
            if (!result.IsSuccess)
                return Result<List<TResult>>.Fail(result.Detail);

            selectedResult.Add(result.Value!);
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }
}