using OnRails.ResultDetails;
using OnRails.ResultDetails.Errors.Internal;

namespace OnRails.Extensions.Try;

public static partial class TryExtensions {
    public static async Task<Result<T>> Try<T>(
        Func<Task<T>> function,
        int numOfTry = 1
    ) {
        var errors = new List<ErrorDetail>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                return Result<T>.Ok(await function());
            }
            catch (Exception e) {
                errors.Add(new ExceptionError(e));
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result<T>.Fail(errorDetail);
    }

    public static Task<Result> Try(
        this Task source,
        int numOfTry = 1
    ) => Try(async () => await source, numOfTry);

    private static async Task<Result> Try(
        this Task<Result> source,
        int numOfTry,
        bool tryOnlyOnExceptions
    ) {
        var errors = new List<ErrorDetail>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = await source;

                if (result.Success || numOfTry == 1 || tryOnlyOnExceptions) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add((ErrorDetail)result.Detail);
            }
            catch (Exception e) {
                errors.Add(new ExceptionError(e));
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result.Fail(errorDetail);
    }

    public static Task<Result> Try(
        Task<Result> source,
        int numOfTry = 1
    ) => Try(source, numOfTry, tryOnlyOnExceptions: false);

    public static Task<Result> TryOnExceptions(
        Task<Result> task,
        int numOfTry = 1
    ) => Try(task, numOfTry, tryOnlyOnExceptions: true);

    public static Task<Result<T>> Try<T>(
        this T source,
        Func<T, Task<T>> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry);

    public static Task<Result<TResult>> Try<TSource, TResult>(
        this TSource source,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry);

    public static async Task<Result<T>> Try<T>(
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) {
        var errors = new List<ErrorDetail>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = await function();

                if (result.Success || numOfTry == 1) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add((ErrorDetail)result.Detail);
            }
            catch (Exception e) {
                errors.Add(new ExceptionError(e));
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result<T>.Fail(errorDetail);
    }

    public static async Task<Result> Try(
        Func<Task> function,
        int numOfTry = 1
    ) {
        var errors = new List<ErrorDetail>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await function();
                return Result.Ok();
            }
            catch (Exception e) {
                errors.Add(new ExceptionError(e));
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result.Fail(errorDetail);
    }

    private static async Task<Result> Try(
        Func<Task<Result>> function,
        int numOfTry,
        bool tryOnlyOnExceptions
    ) {
        var errors = new List<ErrorDetail>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = await function();

                if (result.Success || numOfTry == 1 || tryOnlyOnExceptions) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add((ErrorDetail)result.Detail);
            }
            catch (Exception e) {
                errors.Add(new ExceptionError(e));
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result.Fail(errorDetail);
    }

    public static Task<Result> Try(
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => Try(function, numOfTry, false);

    public static Task<Result> TryOnExceptions(
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => Try(function, numOfTry, true);


    public static Task<Result> Try<T>(
        this T source,
        Func<T, Task> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry);

    public static Task<Result> Try<T>(
        this Task<T> source,
        Action<T> action,
        int numOfTry = 1
    ) => Try(async () => action(await source), numOfTry);

    public static Task<Result> Try<T>(
        this Task<T> source,
        Action action,
        int numOfTry = 1
    ) => Try(async () => {
        await source;
        action();
    }, numOfTry);

    public static async Task<Result> Try(
        this Task source,
        Action action,
        int numOfTry = 1
    ) {
        var errors = new List<ErrorDetail>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await source;
                action();
                return Result.Ok();
            }
            catch (Exception e) {
                errors.Add(new ExceptionError(e));
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result.Fail(errorDetail);
    }

    private static async Task<Result> Try(
        this Task source,
        Func<Result> function,
        int numOfTry,
        bool tryOnlyOnExceptions
    ) {
        var errors = new List<ErrorDetail>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await source;
                var result = function();

                if (result.Success || numOfTry == 1 || tryOnlyOnExceptions) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add((ErrorDetail)result.Detail);
            }
            catch (Exception e) {
                errors.Add(new ExceptionError(e));
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result.Fail(errorDetail);
    }

    public static Task<Result> Try(
        this Task source,
        Func<Result> function,
        int numOfTry = 1
    ) => source.Try(function, numOfTry, false);

    public static Task<Result> TryOnExceptions(
        this Task source,
        Func<Result> function,
        int numOfTry = 1
    ) => source.Try(function, numOfTry, true);

    private static async Task<Result> Try(
        this Task source,
        Func<Task<Result>> function,
        int numOfTry,
        bool tryOnlyOnExceptions
    ) {
        var errors = new List<ErrorDetail>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await source;
                var result = await function();

                if (result.Success || numOfTry == 1 || tryOnlyOnExceptions) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add((ErrorDetail)result.Detail);
            }
            catch (Exception e) {
                errors.Add(new ExceptionError(e));
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result.Fail(errorDetail);
    }

    public static Task<Result> Try(
        this Task source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.Try(function, numOfTry, false);

    public static Task<Result> TryOnExceptions(
        this Task source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => source.Try(function, numOfTry, true);

    public static Task<Result> Try<T>(
        this Task<T> source,
        Func<T, Task> function,
        int numOfTry = 1
    ) => Try(async () => await function(await source), numOfTry);

    public static Task<Result<T>> Try<T>(
        this Task<T> source,
        Func<T, Task<Result<T>>> onSuccessFunction,
        int numOfTry = 1
    ) => Try(async () => await onSuccessFunction(await source), numOfTry);

    public static Task<Result> Try<T>(
        this T source,
        Func<T, Task<Result>> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry);

    public static Task<Result> TryOnExceptions<T>(
        this T source,
        Func<T, Task<Result>> function,
        int numOfTry = 1
    ) => TryOnExceptions(() => function(source), numOfTry);

    //TODO: Fix this
    // public static Task<Result> Try<T>(
    //     this Task<T> source,
    //     Func<T, Task<Result>> onSuccessFunction,
    //     int numOfTry = 1
    // ) =>  Try(async () =>  onSuccessFunction(await source), numOfTry);

    public static Task<Result<T>> Try<T>(
        this Task<T> source,
        int numOfTry = 1) =>
        Try(async () => await source, numOfTry);

    public static Task<Result<TResult>> Try<TSource, TResult>(
        this TSource source,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry);

    public static Task<Result<T>> Try<T>(Task<Result<T>> task,
        int numOfTry = 1
    ) => Try(async () => await task, numOfTry);

    public static Task<Result<T>> Try<T>(
        this T source,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry);
}