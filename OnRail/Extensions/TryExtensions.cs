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

    #region Try

    public static Result<T> Try<T>(
        Func<T> function, int numOfTry = 1) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                return Result<T>.Ok(function());
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

                if (result.IsSuccess)
                    return result;
                if (numOfTry == 1)
                    return result;

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

                if (result.IsSuccess)
                    return result;
                if (numOfTry == 1)
                    return result;

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
                return Result.Ok();
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result.Fail(GenerateExceptionError(errors, numOfTry));
    }

    public static Result Try<T>(
        this T @this,
        Action<T> action, int numOfTry = 1) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                action(@this);
                return Result.Ok();
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result.Fail(GenerateExceptionError(errors, numOfTry));
    }

    #endregion

    #region TryAsync

    public static async Task<Result<T>> TryAsync<T>(
        Func<Task<T>> function,
        int numOfTry = 1) {
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

    public static async Task<Result<T>> TryAsync<T>(
        Func<Task<Result<T>>> function,
        int numOfTry = 1) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = await function();

                if (result.IsSuccess)
                    return result;
                if (numOfTry == 1)
                    return result;

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

    public static async Task<Result> TryAsync(
        Func<Task> function,
        int numOfTry = 1) {
        var counter = 0;
        while (true) {
            try {
                await function();
                return Result.Ok();
            }
            catch (Exception e) {
                counter++;
                if (counter >= numOfTry)
                    return Result.Fail(new ExceptionError(e,
                        moreDetails: new {numOfTry}));
            }
        }
    }

    public static async Task<Result> TryAsync(
        Func<Task<Result>> function,
        int numOfTry = 1
    ) {
        var counter = 0;
        while (true) {
            try {
                return await function();
            }
            catch (Exception e) {
                counter++;
                if (counter >= numOfTry)
                    return Result.Fail(new ExceptionError(e,
                        moreDetails: new {numOfTry}));
            }
        }
    }

    public static Task<Result> TryAsync<TSource>(
        this TSource @this,
        Func<TSource, Task> function,
        int numOfTry = 1
    ) => TryAsync(() => function(@this), numOfTry);

    public static async Task<Result> TryAsync<TSource>(
        this Task<TSource> @this,
        Action<TSource> onSuccessFunction
    ) {
        try {
            var source = await @this;
            onSuccessFunction(source);
            return Result.Ok();
        }
        catch (Exception e) {
            return Result.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryAsync<TSource>(
        this Task<TSource> @this,
        Action onSuccessFunction
    ) {
        try {
            await @this;
            onSuccessFunction();
            return Result.Ok();
        }
        catch (Exception e) {
            return Result.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryAsync(
        this Task @this,
        Action onSuccessFunction
    ) {
        try {
            await @this;
            onSuccessFunction();
            return Result.Ok();
        }
        catch (Exception e) {
            return Result.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryAsync(
        Func<Task<Result>> onSuccessFunction
    ) {
        try {
            return await onSuccessFunction();
        }
        catch (Exception e) {
            return Result.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryAsync<T>(
        this T @this,
        Func<T, Task<Result>> onSuccessFunction
    ) {
        try {
            return await onSuccessFunction(@this);
        }
        catch (Exception e) {
            return Result.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryAsync<T>(
        this T @this,
        Func<T, Task> onSuccessFunction
    ) {
        try {
            await onSuccessFunction(@this);
            return Result.Ok();
        }
        catch (Exception e) {
            return Result.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryAsync(
        this Task @this,
        Func<Result> onSuccessFunction
    ) {
        try {
            await @this;
            return onSuccessFunction();
        }
        catch (Exception e) {
            return Result.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryAsync(
        this Task @this,
        Func<Task<Result>> onSuccessFunction
    ) {
        try {
            await @this;
            return await onSuccessFunction();
        }
        catch (Exception e) {
            return Result.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result<TResult>> TryAsync<TResult>(
        Func<Task<Result<TResult>>> onSuccessFunction
    ) {
        try {
            return await onSuccessFunction();
        }
        catch (Exception e) {
            return Result<TResult>.Fail(new ExceptionError(e, e.Message));
        }
    }

    public static async Task<Result> TryAsync<TSource>(
        this Task<TSource> @this,
        Func<TSource, Task> function,
        int numOfTry = 1
    ) {
        var t = await @this;
        return await TryAsync(() => function(t), numOfTry);
    }

    public static Task<Result> TryAsync<TSource>(
        this TSource @this,
        Func<TSource, Task<Result>> function,
        int numOfTry = 1
    ) => TryAsync(() => function(@this), numOfTry);

    public static async Task<Result> TryAsync<TSource>(
        this Task<TSource> @this,
        Func<TSource, Task<Result>> function,
        int numOfTry = 1
    ) {
        var t = await @this;
        return await TryAsync(() => function(t), numOfTry);
    }

    #endregion
}