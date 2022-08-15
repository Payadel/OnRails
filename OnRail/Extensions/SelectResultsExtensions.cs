using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions;

public static class SelectResultsExtensions {
    #region SelectResults

    public static Result<List<TResult>> SelectResults<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, Result<TResult>> function) {
        var thisList = @this.ToList();

        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            var result = function(item);
            if (!result.IsSuccess) {
                result.Detail.AddDetail(new {thisObj = thisList, targetItem = item});
                return Result<List<TResult>>.Fail(result.Detail);
            }

            selectedResult.Add(result.Value);
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }

    public static Result<List<TResult>> SelectResults<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, TResult> function) {
        var thisList = @this.ToList();

        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            try {
                var result = function(item);
                selectedResult.Add(result);
            }
            catch (Exception e) {
                return Result<List<TResult>>.Fail(new ExceptionError(e,
                    moreDetails: new {thisObj = thisList, targetItem = item}));
            }
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }

    #endregion

    #region SelectResultsAsync

    public static async Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this Task<IEnumerable<TSource>> @this,
        Func<TSource, Result<TResult>> function) {
        var thisList = (await @this).ToList();
        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            var result = function(item);
            if (!result.IsSuccess) {
                result.Detail.AddDetail(new {thisObj = @this, targetItem = item});
                return Result<List<TResult>>.Fail(result.Detail);
            }

            selectedResult.Add(result.Value);
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }

    public static async Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, Task<Result<TResult>>> function) {
        var thisList = @this.ToList();

        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            var result = await function(item);
            if (!result.IsSuccess) {
                result.Detail.AddDetail(new {thisObj = thisList, targetItem = item});
                return Result<List<TResult>>.Fail(result.Detail);
            }

            selectedResult.Add(result.Value);
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }

    public static async Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this Task<IEnumerable<TSource>> @this,
        Func<TSource, Task<Result<TResult>>> function) {
        var thisList = (await @this).ToList();

        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            var result = await function(item);
            if (!result.IsSuccess) {
                result.Detail.AddDetail(new {thisObj = @this, targetItem = item});
                return Result<List<TResult>>.Fail(result.Detail);
            }

            selectedResult.Add(result.Value);
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }

    public static async Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this Task<IEnumerable<TSource>> @this,
        Func<TSource, TResult> function) {
        var thisList = (await @this).ToList();

        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            try {
                var result = function(item);
                selectedResult.Add(result);
            }
            catch (Exception e) {
                return Result<List<TResult>>.Fail(new ExceptionError(e,
                    moreDetails: new {thisObj = thisList, targetItem = item}));
            }
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }

    public static async Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, Task<TResult>> function) {
        var thisList = @this.ToList();

        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            try {
                var result = await function(item);
                selectedResult.Add(result);
            }
            catch (Exception e) {
                return Result<List<TResult>>.Fail(new ExceptionError(e,
                    moreDetails: new {thisObj = thisList, targetItem = item}));
            }
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }

    public static async Task<Result<List<TResult>>> SelectResultsAsync<TSource, TResult>(
        this Task<IEnumerable<TSource>> @this,
        Func<TSource, Task<TResult>> function) {
        var thisList = (await @this).ToList();

        var selectedResult = new List<TResult>(thisList.Count);
        foreach (var item in thisList) {
            try {
                var result = await function(item);
                selectedResult.Add(result);
            }
            catch (Exception e) {
                return Result<List<TResult>>.Fail(new ExceptionError(e,
                    moreDetails: new {thisObj = thisList, targetItem = item}));
            }
        }

        return Result<List<TResult>>.Ok(selectedResult);
    }

    #endregion
}