using OnRail.Extensions.Map;
using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.ForEach;

public static partial class ForEachExtensions {
    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<T> @this,
        Func<T, Result> function,
        int numOfTry = 1) {
        foreach (var item in @this) {
            var result = item.Try(function, numOfTry);
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> @this,
        Func<T, Result> function,
        int numOfTry = 1) {
        var list = @this.ToList();
        foreach (var item in list) {
            var result = item.OnSuccess(value => value.Try(function, numOfTry))
                .OnFail(result => result.Detail.AddDetail(new {thisObj = list, targetItem = item}));
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) {
        foreach (var item in @this) {
            var result = function(item);
            if (!result.IsSuccess)
                return Result.Fail(result.Detail);
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<Result<TSource>> @this,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) {
        var list = @this.ToList();
        foreach (var item in list) {
            var result = item.OnSuccess(value => value.Try(function, numOfTry))
                .OnFail(result => result.Detail.AddDetail(new {thisObj = list, targetItem = item}));
            if (!result.IsSuccess)
                return result.Map();
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<T> @this,
        Action<T> action,
        int numOfTry = 1) {
        var list = @this.ToList();
        foreach (var item in list) {
            var result = item.Try(action, numOfTry);
            if (!result.IsSuccess) {
                result.Detail.AddDetail(new {thisObj = list, targetItem = item});
                return result;
            }
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> @this,
        Action<T> action,
        int numOfTry = 1) {
        var list = @this.ToList();
        foreach (var item in list) {
            var result = item.OnSuccess(value => value.Try(action, numOfTry))
                .OnFail(result => result.Detail.AddDetail(new {thisObj = list, targetItem = item}));
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }
}