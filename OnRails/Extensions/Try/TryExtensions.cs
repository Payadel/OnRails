namespace OnRails.Extensions.Try;

public static partial class TryExtensions {
    public static Result<T> Try<T>(
        Func<T> function,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                return Result<T>.Ok(function());
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result<T>.Fail(errorDetail);
    }

    public static Result<TResult> Try<TSource, TResult>(
        this TSource source,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry);

    private static Result Try(
        Func<Result> function,
        int numOfTry,
        bool tryOnlyOnExceptions
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = function();

                if (result.Success || numOfTry == 1 || tryOnlyOnExceptions) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add(result.Detail);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result.Fail(errorDetail);
    }

    public static Result Try(
        Func<Result> function,
        int numOfTry = 1
    ) => Try(function, numOfTry, false);

    public static Result TryOnExceptions(
        Func<Result> function,
        int numOfTry = 1
    ) => Try(function, numOfTry, true);

    public static Result<T> Try<T>(
        Func<Result<T>> function,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                var result = function();

                if (result.Success || numOfTry == 1) {
                    return result;
                }

                if (result.Detail is not null)
                    errors.Add(result.Detail);
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result<T>.Fail(errorDetail);
    }

    public static Result Try(Action action,
        int numOfTry = 1
    ) {
        var errors = new List<object>(numOfTry);

        for (var counter = 0; counter < numOfTry; counter++) {
            try {
                action();
                return Result.Ok();
            }
            catch (Exception e) {
                errors.Add(e);
            }
        }

        var errorDetail = TryHelper.GenerateError(errors, numOfTry);
        return Result.Fail(errorDetail);
    }

    public static Result Try<T>(
        this T source,
        Action<T> action,
        int numOfTry = 1
    ) => Try(() => action(source), numOfTry);


    public static Result<TResult> Try<TSource, TResult>(
        this TSource source,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) => Try(() => function(source), numOfTry);


    public static Result Try<TSource>(
        this TSource source,
        Func<TSource, Result> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry, false);

    public static Result TryOnExceptions<TSource>(
        this TSource source,
        Func<TSource, Result> function,
        int numOfTry = 1
    ) => Try(() => function(source), numOfTry, true);
}