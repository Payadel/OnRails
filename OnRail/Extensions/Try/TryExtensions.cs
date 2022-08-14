using OnRail.ResultDetails;

namespace OnRail.Extensions.Try;

public static partial class TryExtensions {
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

    public static Result<TResult> Try<TSource, TResult>(
        this TSource @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        var errors = new List<Exception>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                return Result<TResult>.Ok(function(@this))
                    .AddNumOfTry(counter + 1, numOfTry);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        return Result<TResult>.Fail(GenerateExceptionError(errors, numOfTry));
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
        Action<T> action, int numOfTry = 1) =>
        Try(() => action(@this), numOfTry);

    //TODO: Test
    public static Task<Result<TResult>> Try<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<Result<TResult>>> fun,
        int numOfTry = 1) => Try(() => fun(@this), numOfTry);

    //TODO: Test
    public static Result<TResult> Try<TSource, TResult>(
        this TSource @this,
        Func<TSource, Result<TResult>> func,
        int numOfTry = 1) => Try(() => func(@this), numOfTry);

    //TODO: Test
    public static Result Try<TSource>(
        this TSource @this,
        Func<TSource, Result> func,
        int numOfTry = 1) => Try(() => func(@this), numOfTry);
}