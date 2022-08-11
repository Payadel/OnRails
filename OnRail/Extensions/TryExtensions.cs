using OnRail.ResultDetails;
using OnRail.ResultDetails.Errors;

namespace OnRail.Extensions;

public static class TryExtensions {
    private static ExceptionError GenerateExceptionError(IReadOnlyCollection<Exception> exceptions, int numOfTry) {
        var lastItem = exceptions.Last();
        var failResult = new ExceptionError(lastItem, message: lastItem.Message, moreDetails: new {numOfTry});

        if (exceptions.Count > 1)
            failResult.AddDetail(exceptions);

        return failResult;
    }

    private static Result AddNumOfTry(this Result result,
        int numOfTry, int maxTryRequested) {
        result.Detail.AddNumOfTry(numOfTry, maxTryRequested);
        return result;
    }

    private static Result<T> AddNumOfTry<T>(this Result<T> result,
        int numOfTry, int maxTryRequested) {
        result.Detail.AddNumOfTry(numOfTry, maxTryRequested);
        return result;
    }

    private static void AddNumOfTry(this ResultDetail detail,
        int numOfTry, int maxTryRequested) {
        detail.AddDetail(new {numOfTry, maxTryRequested});
    }

    #region Try

    public static Result<T> Try<T>(
        Func<T> function, int numOfTry = 1) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                return Result<T>.Ok(function())
                    .AddNumOfTry(counter + 1, numOfTry);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result<T>.Fail(GenerateExceptionError(errors, numOfTry));
    }

    public static Result Try(
        Func<Result> function, int numOfTry = 1) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = function();

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

    public static Result<T> Try<T>(
        Func<Result<T>> function, int numOfTry = 1) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = function();

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

    public static Result Try(Action action, int numOfTry = 1) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                action();
                return Result.Ok().AddNumOfTry(counter + 1, numOfTry);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result.Fail(GenerateExceptionError(errors, numOfTry));
    }

    public static Result Try<T>(
        this T @this,
        Action<T> action, int numOfTry = 1) => Try(() => action(@this), numOfTry);

    //TODO: Test
    public static Result<TResult> Try<TSource, TResult>(
        this TSource @this,
        Func<TSource, TResult> func,
        int numOfTry = 1) => Try(() => func(@this), numOfTry);

    #endregion

    #region Async methods

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

    public static async Task<Result> Try<T>(
        this Task<T> @this,
        Action<T> onSuccessAction,
        int numOfTry = 1
    ) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var source = await @this;
                onSuccessAction(source);
                return Result.Ok()
                    .AddNumOfTry(counter + 1, numOfTry);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result.Fail(GenerateExceptionError(errors, numOfTry));
    }

    public static Task<Result> Try<T>(
        this Task<T> @this,
        Action onSuccessAction,
        int numOfTry = 1) =>
        Try(async () => {
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

    public static async Task<Result> Try<T>(
        this Task<T> @this,
        Func<T, Task> onSuccessFunction,
        int numOfTry = 1
    ) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await onSuccessFunction(await @this);
                return Result.Ok()
                    .AddNumOfTry(counter + 1, numOfTry);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result.Fail(GenerateExceptionError(errors, numOfTry));
    }

    public static Task<Result> Try<T>(
        this T @this,
        Func<T, Task<Result>> function,
        int numOfTry = 1
    ) => Try(() => function(@this), numOfTry);

    public static async Task<Result> Try<T>(
        this Task<T> @this,
        Func<T, Task<Result>> onSuccessFunction,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = await onSuccessFunction(await @this);

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

    #endregion
}