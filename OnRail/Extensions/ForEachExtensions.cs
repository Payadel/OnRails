using OnRail.Extensions.Map;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions;

public static class ForEachExtensions {
    #region ForEachUntilIsSuccess

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<T> @this,
        Func<T, Result> function) {
        foreach (var item in @this) {
            var result = function(item);
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> @this,
        Func<T, Result> function) {
        foreach (var item in @this) {
            if (!item.IsSuccess)
                return item.MapResult();

            var result = function(item.Value);
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, Result<TResult>> function) {
        foreach (var item in @this) {
            var result = function(item);
            if (!result.IsSuccess)
                return Result.Fail(result.Detail);
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<Result<TSource>> @this,
        Func<TSource, Result<TResult>> function) {
        foreach (var item in @this) {
            if (!item.IsSuccess)
                return item.MapResult();

            var result = function(item.Value);
            if (!result.IsSuccess)
                return Result.Fail(result.Detail);
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<T> @this,
        Action<T> action) {
        var list = @this.ToList();
        foreach (var item in list) {
            try {
                action(item);
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e,
                    moreDetails: new {thisObj = list, targetItem = item}));
            }
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> @this,
        Action<T> action) {
        var list = @this.ToList();
        foreach (var item in list) {
            if (!item.IsSuccess)
                return item.MapResult();

            try {
                action(item.Value);
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e,
                    moreDetails: new {thisObj = list, targetItem = item}));
            }
        }

        return Result.Ok();
    }

    #endregion

    #region ForEachUntilIsSuccessAsync

    public static async Task<Result> ForEachUntilIsSuccessAsync<T>(
        this IEnumerable<T> @this,
        Func<T, Task<Result>> function) {
        foreach (var item in @this) {
            var result = await function(item);
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static async Task<Result> ForEachUntilIsSuccessAsync<T>(
        this IEnumerable<Result<T>> @this,
        Func<T, Task<Result>> function) {
        foreach (var item in @this) {
            if (!item.IsSuccess)
                return item.MapResult();

            var result = await function(item.Value);
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Task<Result> ForEachUntilIsSuccessAsync<T>(
        this Task<IEnumerable<T>> @this,
        Func<T, Task<Result>> function) =>
        TryExtensions.Try(() => @this)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    var result = await function(item);
                    if (!result.IsSuccess)
                        return result;
                }

                return Result.Ok();
            });

    public static Task<Result> ForEachUntilIsSuccessAsync<T>(
        this Task<IEnumerable<Result<T>>> @this,
        Func<T, Task<Result>> function) =>
        TryExtensions.Try(() => @this)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    if (!item.IsSuccess)
                        return item.MapResult();

                    var result = await function(item.Value);
                    if (!result.IsSuccess)
                        return result;
                }

                return Result.Ok();
            });

    public static async Task<Result> ForEachUntilIsSuccessAsync<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, Task<Result<TResult>>> function) {
        foreach (var item in @this) {
            var result = await function(item);
            if (!result.IsSuccess)
                return Result.Fail(result.Detail);
        }

        return Result.Ok();
    }

    public static async Task<Result> ForEachUntilIsSuccessAsync<TSource, TResult>(
        this IEnumerable<Result<TSource>> @this,
        Func<TSource, Task<Result<TResult>>> function) {
        foreach (var item in @this) {
            if (!item.IsSuccess)
                return item.MapResult();

            var result = await function(item.Value);
            if (!result.IsSuccess)
                return Result.Fail(result.Detail);
        }

        return Result.Ok();
    }

    public static Task<Result> ForEachUntilIsSuccessAsync<TSource, TResult>(
        this Task<IEnumerable<TSource>> @this,
        Func<TSource, Task<Result<TResult>>> function) =>
        TryExtensions.Try(() => @this)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    var result = await function(item);
                    if (!result.IsSuccess)
                        return Result.Fail(result.Detail);
                }

                return Result.Ok();
            });

    public static Task<Result> ForEachUntilIsSuccessAsync<TSource, TResult>(
        this Task<IEnumerable<Result<TSource>>> @this,
        Func<TSource, Task<Result<TResult>>> function) =>
        TryExtensions.Try(() => @this)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    if (!item.IsSuccess)
                        return item.MapResult();

                    var result = await function(item.Value);
                    if (!result.IsSuccess)
                        return Result.Fail(result.Detail);
                }

                return Result.Ok();
            });

    public static async Task<Result> ForEachUntilIsSuccessAsync<T>(
        this IEnumerable<T> @this,
        Func<T, Task> action) {
        var list = @this.ToList();
        foreach (var item in list) {
            try {
                await action(item);
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e,
                    moreDetails: new {thisObj = list, targetItem = item}));
            }
        }

        return Result.Ok();
    }

    public static async Task<Result> ForEachUntilIsSuccessAsync<T>(
        this IEnumerable<Result<T>> @this,
        Func<T, Task> action) {
        var list = @this.ToList();
        foreach (var item in list) {
            if (!item.IsSuccess)
                return item.MapResult();

            try {
                await action(item.Value);
            }
            catch (Exception e) {
                return Result.Fail(new ExceptionError(e,
                    moreDetails: new {thisObj = list, targetItem = item}));
            }
        }

        return Result.Ok();
    }

    public static Task<Result> ForEachUntilIsSuccessAsync<T>(
        this Task<IEnumerable<T>> @this,
        Func<T, Task> action) => TryExtensions.Try(() => @this)
        .OnSuccess(async items => {
            var list = items.ToList();
            foreach (var item in list) {
                try {
                    await action(item);
                }
                catch (Exception e) {
                    return Result.Fail(new ExceptionError(e,
                        moreDetails: new {thisObj = list, targetItem = item}));
                }
            }

            return Result.Ok();
        });

    public static Task<Result> ForEachUntilIsSuccessAsync<T>(
        this Task<IEnumerable<Result<T>>> @this,
        Func<T, Task> action) => TryExtensions.Try(() => @this)
        .OnSuccess(async items => {
            var list = items.ToList();
            foreach (var item in list) {
                if (!item.IsSuccess)
                    return item.MapResult();

                try {
                    await action(item.Value);
                }
                catch (Exception e) {
                    return Result.Fail(new ExceptionError(e,
                        moreDetails: new {thisObj = list, targetItem = item}));
                }
            }

            return Result.Ok();
        });

    #endregion

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