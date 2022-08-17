using OnRail.Extensions.Map;
using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.ForEach;

public static partial class ForEachExtensions {
    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<T> @this,
        Func<T, Result> function,
        int numOfTry = 1
    ) {
        foreach (var item in @this) {
            var result = item.Try(function, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> @this,
        Func<T, Result> function,
        int numOfTry = 1
    ) {
        var list = @this.ToList();
        foreach (var item in list) {
            var result = item.OnSuccess(function, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1
    ) {
        foreach (var item in @this) {
            var result = item.Try(function, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return result.Map();
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<Result<TSource>> @this,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1
    ) {
        var list = @this.ToList();
        foreach (var item in list) {
            var result = item.OnSuccess(function, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return result.Map();
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<T> @this,
        Action<T> action,
        int numOfTry = 1
    ) {
        var list = @this.ToList();
        foreach (var item in list) {
            var result = item.Try(action, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> @this,
        Action<T> action,
        int numOfTry = 1
    ) {
        var list = @this.ToList();
        foreach (var item in list) {
            var result = item.OnSuccess(action, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }
}