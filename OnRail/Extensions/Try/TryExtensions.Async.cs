using OnRail.ResultDetails;

namespace OnRail.Extensions.Try;

public static partial class TryExtensions {
    public static async Task<Result<T>> Try<T>(
        Func<Task<T>> function,
        int numOfTry = 1) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                return Result<T>.Ok(await function())
                    .AddNumOfTry(counter + 1, numOfTry);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result<T>.Fail(GenerateExceptionError(errors, numOfTry));
    }

    //TODO: Test
    public static Task<Result> Try(
        Task task,
        int numOfTry = 1) => Try(async () => await task, numOfTry);

    //TODO: Test
    public static async Task<Result> Try(
        Task<Result> task,
        int numOfTry = 1) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = await task;

                if (result.IsSuccess || numOfTry == 1) {
                    return result
                        .AddNumOfTry(counter + 1, numOfTry);
                }

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
        this T @this,
        Func<T, Task<T>> function,
        int numOfTry = 1) => Try(() => function(@this), numOfTry);

    public static async Task<Result<T>> Try<T>(
        Func<Task<Result<T>>> function,
        int numOfTry = 1) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = await function();

                if (result.IsSuccess || numOfTry == 1) {
                    return result
                        .AddNumOfTry(counter + 1, numOfTry);
                }

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
        int numOfTry = 1) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await function();
                return Result.Ok()
                    .AddNumOfTry(counter + 1, numOfTry);
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
                    return result
                        .AddNumOfTry(counter + 1, numOfTry);
                }

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
        this T @this,
        Func<T, Task> function,
        int numOfTry = 1
    ) => Try(() => function(@this), numOfTry);

    public static Task<Result> Try<T>(
        this Task<T> @this,
        Action<T> onSuccessAction,
        int numOfTry = 1
    ) => Try(async () => onSuccessAction(await @this), numOfTry);

    public static Task<Result> Try<T>(
        this Task<T> @this,
        Action onSuccessAction,
        int numOfTry = 1
    ) => Try(async () => {
        await @this;
        onSuccessAction();
    }, numOfTry);

    public static async Task<Result> Try(
        this Task @this,
        Action onSuccessAction,
        int numOfTry = 1
    ) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await @this;
                onSuccessAction();
                return Result.Ok()
                    .AddNumOfTry(counter + 1, numOfTry);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result.Fail(GenerateExceptionError(errors, numOfTry));
    }

    public static async Task<Result> Try(
        this Task @this,
        Func<Result> onSuccessFunction,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await @this;
                var result = onSuccessFunction();

                if (result.IsSuccess || numOfTry == 1) {
                    return result
                        .AddNumOfTry(counter + 1, numOfTry);
                }

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
        this Task @this,
        Func<Task<Result>> onSuccessFunction,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await @this;
                var result = await onSuccessFunction();

                if (result.IsSuccess || numOfTry == 1) {
                    return result
                        .AddNumOfTry(counter + 1, numOfTry);
                }

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
        this Task<T> @this,
        Func<T, Task> onSuccessFunction,
        int numOfTry = 1
    ) => Try(async () => await onSuccessFunction(await @this), numOfTry);

    //TODO: Test
    public static Task<Result<T>> Try<T>(
        this Task<T> @this,
        Func<T, Task<Result<T>>> onSuccessFunction,
        int numOfTry = 1
    ) => Try(async () => await onSuccessFunction(await @this), numOfTry);

    public static Task<Result> Try<T>(
        this T @this,
        Func<T, Task<Result>> function,
        int numOfTry = 1
    ) => Try(() => function(@this), numOfTry);

    public static Task<Result> Try<T>(
        this Task<T> @this,
        Func<T, Task<Result>> onSuccessFunction,
        int numOfTry = 1
    ) => Try(async () => await onSuccessFunction(await @this), numOfTry);

//TODO: Test
    public static Task<Result<T>> Try<T>(Task<T> task, int numOfTry = 1) =>
        Try(async () => await task, numOfTry);

    //TODO: Test
    public static Task<Result<TResult>> Try<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<TResult>> func,
        int numOfTry = 1) => Try(() => func(@this), numOfTry);

//TODO: Test
    public static Task<Result<T>> Try<T>(Task<Result<T>> task, int numOfTry = 1) =>
        Try(async () => await task, numOfTry);

    public static Task<Result<T>> Try<T>(
        this T @this,
        Func<T, Task<Result<T>>> func,
        int numOfTry = 1
    ) => Try(() => func(@this), numOfTry);
}