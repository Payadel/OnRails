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
        Action<T> action, int numOfTry = 1) => Try(() => action(@this), numOfTry);

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

    public static async Task<Result> TryAsync(
        Func<Task<Result>> function,
        int numOfTry = 1
    ) {
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
        return Result.Fail(errorDetail);
    }

    public static Task<Result> TryAsync<T>(
        this T @this,
        Func<T, Task> function,
        int numOfTry = 1
    ) => TryAsync(() => function(@this), numOfTry);

    public static async Task<Result> TryAsync<T>(
        this Task<T> @this,
        Action<T> onSuccessAction,
        int numOfTry = 1
    ) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var source = await @this;
                onSuccessAction(source);
                return Result.Ok();
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result.Fail(GenerateExceptionError(errors, numOfTry));
    }

    public static Task<Result> TryAsync<T>(
        this Task<T> @this,
        Action onSuccessAction,
        int numOfTry = 1
    ) => @this.TryAsync(_ => onSuccessAction(), numOfTry);

    public static async Task<Result> TryAsync(
        this Task @this,
        Action onSuccessAction,
        int numOfTry = 1
    ) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await @this;
                onSuccessAction();
                return Result.Ok();
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result.Fail(GenerateExceptionError(errors, numOfTry));
    }

    public static async Task<Result> TryAsync(
        this Task @this,
        Func<Result> onSuccessFunction,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await @this;
                var result = onSuccessFunction();

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

    public static async Task<Result> TryAsync(
        this Task @this,
        Func<Task<Result>> onSuccessFunction,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await @this;
                var result = await onSuccessFunction();

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

    public static async Task<Result> TryAsync<T>(
        this Task<T> @this,
        Func<T, Task> onSuccessFunction,
        int numOfTry = 1
    ) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                await onSuccessFunction(await @this);
                return Result.Ok();
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result.Fail(GenerateExceptionError(errors, numOfTry));
    }

    public static Task<Result> TryAsync<T>(
        this T @this,
        Func<T, Task<Result>> function,
        int numOfTry = 1
    ) => TryAsync(() => function(@this), numOfTry);

    public static async Task<Result> TryAsync<T>(
        this Task<T> @this,
        Func<T, Task<Result>> onSuccessFunction,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = await onSuccessFunction(await @this);

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

    #endregion
}