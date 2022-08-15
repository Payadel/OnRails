using OnRail.Extensions.Map;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.ForEach;

public static partial class ForEachExtensions {
    public static async Task<Result> ForEachUntilIsSuccess<T>(
        this IEnumerable<T> @this,
        Func<T, Task<Result>> function,
        int numOfTry = 1) {
        foreach (var item in @this) {
            var result = await item.Try(function, numOfTry);
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static async Task<Result> ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> @this,
        Func<T, Task<Result>> function,
        int numOfTry = 1) {
        foreach (var item in @this) {
            var result = await item.OnSuccess(value => function(value));
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Task<Result> ForEachUntilIsSuccess<T>(
        this Task<IEnumerable<T>> @this,
        Func<T, Task<Result>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    var result = await function(item);
                    if (!result.IsSuccess)
                        return result;
                }

                return Result.Ok();
            });

    public static Task<Result> ForEachUntilIsSuccess<T>(
        this Task<IEnumerable<Result<T>>> @this,
        Func<T, Task<Result>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    var result = await item.OnSuccess(function, numOfTry);
                    if (!result.IsSuccess)
                        return result;
                }

                return Result.Ok();
            });

    public static async Task<Result> ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<TSource> @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1) {
        foreach (var item in @this) {
            var result = await item.Try(function, numOfTry);
            if (!result.IsSuccess)
                return Result.Fail(result.Detail);
        }

        return Result.Ok();
    }

    public static async Task<Result> ForEachUntilIsSuccess<TSource, TResult>(
        this IEnumerable<Result<TSource>> @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1) {
        foreach (var item in @this) {
            var result = await item.OnSuccess(function, numOfTry);
            if (!result.IsSuccess)
                return result.Map();
        }

        return Result.Ok();
    }

    public static Task<Result> ForEachUntilIsSuccess<TSource, TResult>(
        this Task<IEnumerable<TSource>> @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(() => @this)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    var result = await item.Try(function, numOfTry);
                    if (!result.IsSuccess)
                        return Result.Fail(result.Detail);
                }

                return Result.Ok();
            });

    public static Task<Result> ForEachUntilIsSuccess<TSource, TResult>(
        this Task<IEnumerable<Result<TSource>>> @this,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(() => @this)
            .OnSuccess(async items => {
                foreach (var item in items) {
                    var result = await item.OnSuccess(function, numOfTry);
                    if (!result.IsSuccess)
                        return result.Map();
                }

                return Result.Ok();
            });

    public static async Task<Result> ForEachUntilIsSuccess<T>(
        this IEnumerable<T> @this,
        Func<T, Task> action,
        int numOfTry = 1) {
        var list = @this.ToList();
        foreach (var item in list) {
            var result = await item.Try(action, numOfTry);
            if (!result.IsSuccess)
                return Result.Fail(result.Detail);
        }

        return Result.Ok();
    }

    public static async Task<Result> ForEachUntilIsSuccess<T>(
        this IEnumerable<Result<T>> @this,
        Func<T, Task> action,
        int numOfTry = 1) {
        var list = @this.ToList();
        foreach (var item in list) {
            var result = await item.OnSuccess(action, numOfTry);
            if (!result.IsSuccess)
                return result;
        }

        return Result.Ok();
    }

    public static Task<Result> ForEachUntilIsSuccess<T>(
        this Task<IEnumerable<T>> @this,
        Func<T, Task> action,
        int numOfTry = 1) => TryExtensions.Try(() => @this)
        .OnSuccess(async items => {
            var list = items.ToList();
            foreach (var item in list) {
                var result = await item.Try(action, numOfTry);
                if (!result.IsSuccess)
                    return Result.Fail(result.Detail);
            }

            return Result.Ok();
        });

    public static Task<Result> ForEachUntilIsSuccess<T>(
        this Task<IEnumerable<Result<T>>> @this,
        Func<T, Task> action,
        int numOfTry = 1) => TryExtensions.Try(() => @this)
        .OnSuccess(async items => {
            var list = items.ToList();
            foreach (var item in list) {
                var result = await item.OnSuccess(action, numOfTry);
                if (!result.IsSuccess)
                    return result;
            }

            return Result.Ok();
        });
}