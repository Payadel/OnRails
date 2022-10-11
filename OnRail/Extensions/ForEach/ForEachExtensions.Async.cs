using OnRail.Extensions.Map;
using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.ForEach;

public static partial class ForEachExtensions {
    public static async Task<Result> ForEachUntilIsSuccess<T>(
        this IEnumerable<T> source,
        Func<T, Task<Result>> function,
        int numOfTry = 1
    ) {
        foreach (var item in source) {
            var result = await item.Try(function, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static async Task<Result> ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> source,
        Func<T, Task<Result>> function,
        int numOfTry = 1
    ) {
        foreach (var item in source) {
            var result = await item.OnSuccess(function, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Task<Result> ForEachUntilIsSuccess<T>(
        this Task<IEnumerable<T>> source,
        Func<T, Task<Result>> function,
        int numOfTry = 1
    ) =>
        TryExtensions.Try(source, numOfTry)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    var result = await item.Try(function, numOfTry)
                        .OnFail(new {item});
                    if (!result.IsSuccess)
                        return result;
                }

                return Result.Ok();
            });

    public static Task<Result> ForEachUntilIsSuccess<T>(
        this Task<IEnumerable<Result<T>>> source,
        Func<T, Task<Result>> function,
        int numOfTry = 1
    ) =>
        TryExtensions.Try(source)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    var result = await item.OnSuccess(function, numOfTry)
                        .OnFail(new {item});
                    if (!result.IsSuccess)
                        return result;
                }

                return Result.Ok();
            });

    public static async Task<Result> ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) {
        foreach (var item in source) {
            var result = await item.Try(function, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return Result.Fail(result.Detail);
        }

        return Result.Ok();
    }

    public static async Task<Result> ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<Result<TSource>> source,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) {
        foreach (var item in source) {
            var result = await item.OnSuccess(function, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return result.Map();
        }

        return Result.Ok();
    }

    public static Task<Result> ForEachUntilIsSuccess<TSource, TResult>(
        this Task<IEnumerable<TSource>> source,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) =>
        TryExtensions.Try(() => source)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    var result = await item.Try(function, numOfTry)
                        .OnFail(new {item});
                    if (!result.IsSuccess)
                        return Result.Fail(result.Detail);
                }

                return Result.Ok();
            });

    public static Task<Result> ForEachUntilIsSuccess<TSource, TResult>(
        this Task<IEnumerable<Result<TSource>>> source,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) =>
        TryExtensions.Try(() => source)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    var result = await item.OnSuccess(function, numOfTry)
                        .OnFail(new {item});
                    if (!result.IsSuccess)
                        return result.Map();
                }

                return Result.Ok();
            });

    public static async Task<Result> ForEachUntilIsSuccess<T>(
        this IEnumerable<T> source,
        Func<T, Task> function,
        int numOfTry = 1
    ) {
        var list = source.ToList();
        foreach (var item in list) {
            var result = await item.Try(function, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return Result.Fail(result.Detail);
        }

        return Result.Ok();
    }

    public static async Task<Result> ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> source,
        Func<T, Task> function,
        int numOfTry = 1
    ) {
        var list = source.ToList();
        foreach (var item in list) {
            var result = await item.OnSuccess(function, numOfTry)
                .OnFail(new {item});
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Task<Result> ForEachUntilIsSuccess<T>(
        this Task<IEnumerable<T>> source,
        Func<T, Task> function,
        int numOfTry = 1
    ) => TryExtensions.Try(() => source)
        .OnSuccess(async items => {
            var list = items.ToList();
            foreach (var item in list) {
                var result = await item.Try(function, numOfTry)
                    .OnFail(new {item});
                if (!result.IsSuccess)
                    return Result.Fail(result.Detail);
            }

            return Result.Ok();
        });

    public static Task<Result> ForEachUntilIsSuccess<T>(
        this Task<IEnumerable<Result<T>>> source,
        Func<T, Task> function,
        int numOfTry = 1
    ) => TryExtensions.Try(() => source)
        .OnSuccess(async items => {
            var list = items.ToList();
            foreach (var item in list) {
                var result = await item.OnSuccess(function, numOfTry)
                    .OnFail(new {item});
                if (!result.IsSuccess)
                    return result;
            }

            return Result.Ok();
        });
}