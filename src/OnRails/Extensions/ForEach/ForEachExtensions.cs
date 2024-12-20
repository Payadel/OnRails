using System.Diagnostics;
using OnRails.Extensions.Map;
using OnRails.Extensions.OnFail;
using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;

namespace OnRails.Extensions.ForEach;

[DebuggerStepThrough]
public static partial class ForEachExtensions {
    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<T> source,
        Func<T, Result> function,
        int numOfTry = 1
    ) {
        foreach (var item in source) {
            var result = item.Try(function, numOfTry)
                .OnFailAddMoreDetails(new { item });
            if (!result.Success)
                return result;
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> source,
        Func<T, Result> function,
        int numOfTry = 1
    ) {
        var list = source.ToList();
        foreach (var item in list) {
            var result = item.OnSuccess(function, numOfTry)
                .OnFailAddMoreDetails(new { item });
            if (!result.Success)
                return result;
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1
    ) {
        foreach (var item in source) {
            var result = item.Try(function, numOfTry)
                .OnFailAddMoreDetails(new { item });
            if (!result.Success)
                return result.Map();
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<Result<TSource>> source,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1
    ) {
        var list = source.ToList();
        foreach (var item in list) {
            var result = item.OnSuccess(function, numOfTry)
                .OnFailAddMoreDetails(new { item });
            if (!result.Success)
                return result.Map();
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<T> source,
        Action<T> action,
        int numOfTry = 1
    ) {
        var list = source.ToList();
        foreach (var item in list) {
            var result = item.Try(action, numOfTry)
                .OnFailAddMoreDetails(new { item });
            if (!result.Success)
                return result;
        }

        return Result.Ok();
    }

    public static Result ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> source,
        Action<T> action,
        int numOfTry = 1
    ) {
        var list = source.ToList();
        foreach (var item in list) {
            var result = item.OnSuccess(action, numOfTry)
                .OnFailAddMoreDetails(new { item });
            if (!result.Success)
                return result;
        }

        return Result.Ok();
    }
}