using OnRail.Extensions.Try;

namespace OnRail.Extensions.OperateWhen;

public static partial class OperateWhenExtensions {
    //TODO: Test
    public static async Task<Result> OperateWhen(
        bool predicate,
        Func<Task> function,
        int numOfTry = 1) {
        if (predicate)
            return await TryExtensions.Try(function, numOfTry);
        return Result.Ok();
    }

    //TODO: Test
    public static Task<Result> OperateWhen(
        Func<bool> predicateFun,
        Func<Task> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicateFun)
            .OnSuccess(predicate => OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static async Task<Result> OperateWhen(
        bool predicate,
        Func<Task<Result>> function,
        int numOfTry = 1) {
        if (predicate)
            return await TryExtensions.Try(function, numOfTry);
        return Result.Ok();
    }

    //TODO: Test
    public static Task<Result> OperateWhen(
        Func<bool> predicateFun,
        Func<Task<Result>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicateFun)
            .OnSuccess(predicate => OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        bool predicate,
        Func<Task<T>> function,
        int numOfTry = 1) =>
        predicate
            ? TryExtensions.Try(function, numOfTry)
            : TryExtensions.Try(@this, numOfTry);

    //TODO: Test
    public static async Task<Result<T>> OperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task<T>> function,
        int numOfTry = 1) => predicate
        ? await TryExtensions.Try(function, numOfTry)
        : await TryExtensions.Try(@this, numOfTry);

    //TODO: Test
    public static async Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        bool predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) => predicate
        ? await TryExtensions.Try(function, numOfTry)
        : await TryExtensions.Try(@this, numOfTry);

    //TODO: Test
    public static async Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        bool predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1) => predicate
        ? await @this.Try(function, numOfTry)
        : await TryExtensions.Try(@this, numOfTry);

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<bool> predicateFun,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<T, bool> predicateFun,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(async () => predicateFun(await @this))
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        bool predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnSuccess(t => t.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<bool> predicateFun,
        Func<T, Result<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnSuccess(t => t.OperateWhen(predicateFun, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<T, bool> predicateFun,
        Func<T, Result<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnSuccess(t => t.OperateWhen(predicateFun, function, numOfTry));

    //TODO: Test
    public static async Task<Result<T>> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Task<T>> function,
        int numOfTry = 1) => predicate
        ? await TryExtensions.Try(function, numOfTry)
        : Result<T>.Ok(@this);

    //TODO: Test
    public static async Task<Result<T>> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<T, Task<T>> function,
        int numOfTry = 1) => predicate
        ? await @this.Try(function, numOfTry)
        : Result<T>.Ok(@this);

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<Task<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<Task> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static async Task<Result<T>> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Task> function,
        int numOfTry = 1) => predicate
        ? await TryExtensions.Try(function, numOfTry)
            .OnSuccess(() => @this)
        : Result<T>.Ok(@this);

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFun,
        Func<Task<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnSuccess(t => t.OperateWhen(predicateFun, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<bool> predicateFun,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnSuccess(t => t.OperateWhen(predicateFun, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<T, bool> predicateFun,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnSuccess(t => t.OperateWhen(predicateFun, function, numOfTry));

    //TODO: Test
    public static async Task<Result<T>> OperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<T>> function,
        int numOfTry = 1) => predicate
        ? await TryExtensions.Try(function, numOfTry)
        : @this;

    //TODO: Test
    public static async Task<Result<T>> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) => predicate
        ? await TryExtensions.Try(function, numOfTry)
        : Result<T>.Ok(@this);

    //TODO: Test
    public static async Task<Result<T>> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<T, Task> function,
        int numOfTry = 1) => predicate
        ? await @this.Try(function, numOfTry)
            .OnSuccess(() => @this)
        : Result<T>.Ok(@this);

    //TODO: Test
    public static async Task<Result<T>> OperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) => predicate
        ? await TryExtensions.Try(function, numOfTry)
        : @this;

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<Task<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicateFun,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnSuccess(t => t.OperateWhen(predicateFun, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicateFun,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) =>
        @this.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicateFun,
        Func<Task> function,
        int numOfTry = 1) =>
        @this.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<T, Task<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static async Task<Result<T>> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1) => predicate
        ? await @this.Try(function, numOfTry)
        : Result<T>.Ok(@this);

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicateFun,
        Func<T, Task<Result<T>>> function,
        int numOfTry = 1) =>
        @this.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<T, Result> predicateFun,
        Func<Task<Result<T>>> function,
        int numOfTry = 1) =>
        @this.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => @this.OperateWhen(predicate.IsSuccess, function, numOfTry));
}