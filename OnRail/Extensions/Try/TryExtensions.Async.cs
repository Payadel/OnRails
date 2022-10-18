using OnRail.ResultDetails;

namespace OnRail.Extensions.Try;

public static partial class TryExtensions {
    public static async Task<Result<T>> Try<T>(
        Func<Task<T>> function,
        int numOfTry = 1
    ) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                return Result<T>.Ok(await function());
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result<T>.Fail(GenerateExceptionError(errors, numOfTry));
    }

    //TODO: Test
    //TODO: Add this and change name to source
    public static Task<Result> Try(
        Task task,
        int numOfTry = 1
    ) => Try(async () => await task, numOfTry);

    //TODO: Test
    //TODO: Add this and change name to source
    public static async Task<Result> Try(
        Task<Result> task,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = await task;

                if (result.IsSuccess || numOfTry == 1) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add(result.Detail);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        var errorDetail = new ErrorDetail(moreDetails: errors);
        errorDetail.AddDetail(new {numOfTry});
        return Result.Fail(errorDetail);
    }

    public static Task<Result<T>> Try<T>(
        this T source,
        Func<T, Task<T>> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry);

    public static async Task<Result<T>> Try<T>(
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = await function();

                if (result.IsSuccess || numOfTry == 1) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add(result.Detail);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        var errorDetail = new ErrorDetail(moreDetails: errors);
        errorDetail.AddDetail(new {numOfTry});
        return Result<T>.Fail(errorDetail);
    }

    public static async Task<Result> Try(
        Func<Task> function,
        int numOfTry = 1
    ) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await function();
                return Result.Ok();
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result.Fail(GenerateExceptionError(errors, numOfTry));
    }

    public static async Task<Result> Try(
        Func<Task<Result>> function,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = await function();

                if (result.IsSuccess || numOfTry == 1) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add(result.Detail);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        var errorDetail = new ErrorDetail(moreDetails: errors);
        errorDetail.AddDetail(new {numOfTry});
        return Result.Fail(errorDetail);
    }

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
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await source;
                action();
                return Result.Ok();
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result.Fail(GenerateExceptionError(errors, numOfTry));
    }

    public static async Task<Result> Try(
        this Task source,
        Func<Result> function,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await source;
                var result = function();

                if (result.IsSuccess || numOfTry == 1) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add(result.Detail);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        var errorDetail = new ErrorDetail(moreDetails: errors);
        errorDetail.AddDetail(new {numOfTry});
        return Result.Fail(errorDetail);
    }

    public static async Task<Result> Try(
        this Task source,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await source;
                var result = await function();

                if (result.IsSuccess || numOfTry == 1) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add(result.Detail);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        var errorDetail = new ErrorDetail(moreDetails: errors);
        errorDetail.AddDetail(new {numOfTry});
        return Result.Fail(errorDetail);
    }

    public static Task<Result> Try<T>(
        this Task<T> source,
        Func<T, Task> function,
        int numOfTry = 1
    ) => Try(async () => await function(await source), numOfTry);

    //TODO: Test
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

    public static Task<Result> Try<T>(
        this Task<T> source,
        Func<T, Task<Result>> onSuccessFunction,
        int numOfTry = 1
    ) => Try(async () => await onSuccessFunction(await source), numOfTry);

//TODO: Test
//TODO: Add this and change name to source
    public static Task<Result<T>> Try<T>(Task<T> task, int numOfTry = 1) =>
        Try(async () => await task, numOfTry);

    //TODO: Test
    public static Task<Result<TResult>> Try<TSource, TResult>(
        this TSource source,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry);

//TODO: Test
    public static Task<Result<T>> Try<T>(Task<Result<T>> task,
        int numOfTry = 1
    ) => Try(async () => await task, numOfTry);

    public static Task<Result<T>> Try<T>(
        this T source,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry);
}