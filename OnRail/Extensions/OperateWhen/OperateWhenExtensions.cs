using OnRail.Extensions.Try;

namespace OnRail.Extensions.OperateWhen;

public static partial class OperateWhenExtensions {
    public static Result OperateWhen(
        bool predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => predicate ? TryExtensions.Try(function, numOfTry) : Result.Ok();

    public static Result OperateWhen(
        Func<bool> predicateFun,
        Func<Result> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFun, numOfTry)
        .OnSuccess(predicate => OperateWhen(predicate, function, numOfTry));

    public static Result OperateWhen(
        bool predicate,
        Action action,
        int numOfTry = 1) {
        return predicate
            ? TryExtensions.Try(action, numOfTry)
            : Result.Ok();
    }

    public static Result OperateWhen(
        Func<bool> predicateFun,
        Action action,
        int numOfTry = 1) => TryExtensions.Try(predicateFun, numOfTry)
        .OnSuccess(predicate => OperateWhen(predicate, action, numOfTry));

    //TODO: complete tests for numOfTry
    public static Result<T> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => predicate
        ? TryExtensions.Try(function, numOfTry)
        : Result<T>.Ok(@this);

    //TODO: Add numOfTry + Test
    public static Result<T> OperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Func<Result<T>> operation
    ) => predicate
        .OnSuccess(operation)
        .OnFail(() => @this);

    //TODO: Test (OnSuccess must support try)
    public static Result<T> OperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Action operation,
        int numOfTry = 1
    ) => predicate
        .OnSuccess(() => {
            operation();
            return @this;
        });

    //TODO: complete tests for numOfTry
    public static Result<T> OperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => predicate
        ? TryExtensions.Try(operation, numOfTry)
        : @this;

    public static Result<T> OperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Action operation,
        int numOfTry = 1
    ) {
        if (predicate) {
            var result = TryExtensions.Try(operation, numOfTry);
            if (!result.IsSuccess)
                return Result<T>.Fail(result.Detail);
        }

        return @this;
    }

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate().IsSuccess, operation, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        Action operation,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate().IsSuccess, operation, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFun, numOfTry)
        .OnSuccess(predicate => @this.OperateWhen(predicate, function));

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Result> function,
        int numOfTry = 1
    ) {
        if (predicate) {
            return TryExtensions.Try(function, numOfTry)
                .OnSuccess(() => @this);
        }

        return Result<T>.Ok(@this);
    }

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<Result> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFun, numOfTry)
        .OnSuccess(predicate => @this.OperateWhen(predicate, function));

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicateFun,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => @this.OperateWhen(() => predicateFun(@this), function, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => @this.OperateWhen(() => predicate(@this), function, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => predicate
        ? TryExtensions.Try(() => function(@this), numOfTry)
        : Result<T>.Ok(@this);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFun, numOfTry)
        .OnSuccess(predicate => @this.OperateWhen(predicate, function));

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<T, Result> function,
        int numOfTry = 1
    ) {
        if (predicate) {
            return TryExtensions.Try(() => function(@this), numOfTry)
                .OnSuccess(() => @this);
        }

        return Result<T>.Ok(@this);
    }

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => @this.OperateWhen(() => predicate(@this), function, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicateFunc,
        Func<T, Result> function,
        int numOfTry = 1
    ) => @this.Try(predicateFunc, numOfTry)
        .OnSuccess(predicate => @this.OperateWhen(predicate, function));

    //TODO: Test
    public static Result OperateWhen(
        Func<Result> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => OperateWhen(predicate().IsSuccess, function, numOfTry);

    //TODO: Test
    public static Result OperateWhen(
        Func<Result> predicate,
        Action action,
        int numOfTry = 1
    ) => OperateWhen(predicate().IsSuccess, action, numOfTry);

    //TODO: Test
    public static Result OperateWhen(
        Result predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => OperateWhen(predicate.IsSuccess, function, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<Result> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate().IsSuccess, function, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate(@this).IsSuccess, function, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<Result> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate().IsSuccess, function, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Result predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate.IsSuccess, function, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate(@this).IsSuccess, function, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        bool predicate,
        Action action,
        int numOfTry = 1) {
        if (!predicate)
            return Result<T>.Ok(@this);

        return TryExtensions.Try(action, numOfTry)
            .OnSuccess(() => @this);
    }

    //TODO: Test - What happen OnFail?
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Action action,
        int numOfTry = 1) =>
        TryExtensions.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => OperateWhen(predicate, action, numOfTry))
            .OnSuccess(@this);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicateFun,
        Action action,
        int numOfTry = 1) =>
        TryExtensions.Try(() => predicateFun(@this), numOfTry)
            .OnSuccess(predicate => OperateWhen(predicate, action, numOfTry))
            .OnSuccess(@this);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        bool predicate,
        Action<T> action,
        int numOfTry = 1) =>
        OperateWhen(predicate, () => action(@this), numOfTry)
            .OnSuccess(() => @this);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Action<T> action,
        int numOfTry = 1) =>
        OperateWhen(predicateFun, () => action(@this), numOfTry)
            .OnSuccess(() => @this);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicateFun,
        Action<T> action,
        int numOfTry = 1) =>
        OperateWhen(() => predicateFun(@this), () => action(@this), numOfTry)
            .OnSuccess(() => @this);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Result predicate,
        Action action,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate.IsSuccess, action, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<T, Result> predicateFun,
        Action action,
        int numOfTry = 1
    ) => OperateWhen(() => predicateFun(@this), action, numOfTry)
        .OnSuccess(() => @this);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Result predicate,
        Action<T> action,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate.IsSuccess, action, numOfTry);

    //TODO: Test
    public static Result<T> OperateWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Action<T> action,
        int numOfTry = 1
    ) => OperateWhen(() => predicate(@this), () => action(@this), numOfTry)
        .OnSuccess(() => @this);
}