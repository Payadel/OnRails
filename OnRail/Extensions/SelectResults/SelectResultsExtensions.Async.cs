using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.SelectResults;

public static partial class SelectResultsExtensions {
    public static Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this Task<IEnumerable<TSource>> @this,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) =>TryExtensions.Try(@this, numOfTry)
        .OnSuccess(items => {
            var list = items.ToList();
            var selectedResult = new List<TResult>(list.Count);
            foreach (var item in list) {
                var result = item.Try(function, numOfTry)
                    .OnFail(result => result.Detail.AddDetail(new {thisObj = list, targetItem = item}));
                if (!result.IsSuccess) 
                    return Result<List<TResult>>.Fail(result.Detail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        });

    public static async Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1) {
        var thisList = @this.ToList();

        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            var result = await item.Try(function, numOfTry)
                .OnFail(result => result.Detail.AddDetail(new {thisObj = thisList, targetItem = item}));
            if (!result.IsSuccess) 
                return Result<List<TResult>>.Fail(result.Detail);

            selectedResult.Add(result.Value!);
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }

    public static Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this Task<IEnumerable<TSource>> @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1) =>TryExtensions.Try(@this, numOfTry)
        .OnSuccess(async items => {
            var list = items.ToList();
            var selectedResult = new List<TResult>(list.Count);
            foreach (var item in list) {
                var result = await item.Try(function, numOfTry)
                    .OnFail(result => result.Detail.AddDetail(new {thisObj = list, targetItem = item}));
                if (!result.IsSuccess) 
                    return Result<List<TResult>>.Fail(result.Detail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        });

    public static Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this Task<IEnumerable<TSource>> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) =>TryExtensions.Try(@this, numOfTry)
        .OnSuccess(items => {
            var list = items.ToList();
            var selectedResult = new List<TResult>(list.Count);
            foreach (var item in list) {
                var result = item.Try(function, numOfTry)
                    .OnFail(result => result.Detail.AddDetail(new {thisObj = list, targetItem = item}));
                if (!result.IsSuccess) 
                    return Result<List<TResult>>.Fail(result.Detail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        });

    public static async Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) {
        var thisList = @this.ToList();

        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            var result = await item.Try(function, numOfTry)
                .OnFail(result => result.Detail.AddDetail(new {thisObj = thisList, targetItem = item}));
            if (!result.IsSuccess) 
                return Result<List<TResult>>.Fail(result.Detail);

            selectedResult.Add(result.Value!);
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }

    public static Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this Task<IEnumerable<TSource>> @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) =>TryExtensions.Try(@this, numOfTry)
        .OnSuccess(async items => {
            var list = items.ToList();
            var selectedResult = new List<TResult>(list.Count);
            foreach (var item in list) {
                var result = await item.Try(function, numOfTry)
                    .OnFail(result => result.Detail.AddDetail(new {thisObj = list, targetItem = item}));
                if (!result.IsSuccess) 
                    return Result<List<TResult>>.Fail(result.Detail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        });
}