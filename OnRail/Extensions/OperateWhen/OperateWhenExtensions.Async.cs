namespace OnRail.Extensions.OperateWhen;

public static partial class OperateWhenExtensions {
    public static async Task OperateWhen(
        bool predicate,
        Func<Task> function) {
        if (predicate)
            await function();
    }

    public static Task OperateWhen(
        Func<bool> predicateFun,
        Func<Task> function) =>
        OperateWhen(predicateFun(), function);

    public static async Task<Result> OperateWhen(
        bool predicate,
        Func<Task<Result>> function) {
        if (predicate)
            return await function();
        return Result.Ok();
    }

    public static Task<Result> OperateWhen(
        Func<bool> predicateFun,
        Func<Task<Result>> function) =>
        OperateWhen(predicateFun(), function);

    public static async Task<T> OperateWhen<T>(
        this Task<T> @this,
        bool predicate,
        Func<Task<T>> function) {
        var t = await @this;
        if (predicate)
            return await function();
        return t;
    }

    public static async Task<Result<T>> OperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task<T>> function) {
        var t = await @this;
        return predicate ? Result<T>.Ok(await function()) : t;
    }

    public static async Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        bool predicate,
        Func<Task<Result<T>>> function) {
        var t = await @this;
        if (predicate)
            return await function();
        return Result<T>.Ok(t);
    }

    public static async Task<T> OperateWhen<T>(
        this Task<T> @this,
        bool predicate,
        Func<T, Task<T>> function) {
        var t = await @this;
        if (predicate)
            return await function(t);
        return t;
    }

    public static async Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        bool predicate,
        Func<T, Task<Result<T>>> function) {
        var t = await @this;
        if (predicate)
            return await function(t);
        return Result<T>.Ok(t);
    }

    public static Task<T> OperateWhen<T>(
        this Task<T> @this,
        Func<bool> predicateFun,
        Func<T, Task<T>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<bool> predicateFun,
        Func<T, Task<Result<T>>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static async Task<T> OperateWhen<T>(
        this Task<T> @this,
        Func<T, bool> predicate,
        Func<T, Task<T>> function) {
        var t = await @this;
        if (predicate(t))
            return await function(t);
        return t;
    }

    public static async Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> function) {
        var t = await @this;
        if (predicate(t))
            return await function(t);
        return Result<T>.Ok(t);
    }

    public static async Task<T> OperateWhen<T>(
        this Task<T> @this,
        bool predicate,
        Func<T, T> function) {
        var t = await @this;
        return predicate ? function(t) : t;
    }

    public static async Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        bool predicate,
        Func<T, Result<T>> function) {
        var t = await @this;
        return predicate ? function(t) : Result<T>.Ok(t);
    }

    public static Task<T> OperateWhen<T>(
        this Task<T> @this,
        Func<bool> predicateFun,
        Func<T, T> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<bool> predicateFun,
        Func<T, Result<T>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static async Task<T> OperateWhen<T>(
        this Task<T> @this,
        Func<T, bool> predicate,
        Func<T, T> function) {
        var t = await @this;
        return predicate(t) ? function(t) : t;
    }

    public static async Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<T, bool> predicate,
        Func<T, Result<T>> function) {
        var t = await @this;
        return predicate(t) ? function(t) : Result<T>.Ok(t);
    }

    public static Task<T> OperateWhen<T>(
        this Task<T> @this,
        Func<bool> predicateFun,
        Func<Task<T>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFun,
        Func<Task<T>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<bool> predicateFun,
        Func<Task<Result<T>>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static async Task<T> OperateWhen<T>(
        this Task<T> @this,
        Func<T, bool> predicate,
        Func<Task<T>> function) {
        var t = await @this;
        if (predicate(t))
            return await function();
        return t;
    }

    public static async Task<Result<T>> OperateWhen<T>(
        this Task<T> @this,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> function) {
        var t = await @this;
        if (predicate(t))
            return await function();
        return Result<T>.Ok(t);
    }

    public static async Task<T> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Task<T>> function) {
        if (predicate)
            return await function();
        return @this;
    }

    public static async Task<T> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Task> function) {
        if (predicate)
            await function();
        return @this;
    }

    public static async Task<Result<T>> OperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<T>> function) =>
        predicate ? Result<T>.Ok(await function()) : @this;

    public static async Task<Result<T>> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Task<Result<T>>> function) {
        if (predicate)
            return await function();
        return Result<T>.Ok(@this);
    }

    public static async Task<Result<T>> OperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Task<Result<T>>> function) {
        if (predicate)
            return await function();
        return @this;
    }

    public static Task<T> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<Task<T>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static Task<T> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<Task> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static Task<Result<T>> OperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<Task<T>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<Task<Result<T>>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static Task<Result<T>> OperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<Task<Result<T>>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static async Task<Result<T>> OperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task<Result<T>>> function) {
        var t = await @this;
        if (predicate)
            return await function();
        return t;
    }

    public static Task<T> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Func<Task<T>> function) =>
        @this.OperateWhen(predicate(@this), function);

    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Func<Task<Result<T>>> function) =>
        @this.OperateWhen(predicate(@this), function);

    public static async Task<T> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<T, Task<T>> function) {
        if (predicate)
            return await function(@this);
        return @this;
    }

    public static async Task<Result<T>> OperateWhen<T>(
        this T @this,
        bool predicate,
        Func<T, Task<Result<T>>> function) {
        if (predicate)
            return await function(@this);
        return Result<T>.Ok(@this);
    }

    public static Task<T> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<T, Task<T>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<bool> predicateFun,
        Func<T, Task<Result<T>>> function) =>
        @this.OperateWhen(predicateFun(), function);

    public static Task<T> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Func<T, Task<T>> function) =>
        @this.OperateWhen(predicate(@this), function);

    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Func<T, Task<Result<T>>> function) =>
        @this.OperateWhen(predicate(@this), function);

    public static Task<T> OperateWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Func<Task<T>> function) =>
        @this.OperateWhen(predicate(@this).IsSuccess, function);

    public static Task<Result<T>> OperateWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Func<Task<Result<T>>> function) =>
        @this.OperateWhen(predicate(@this).IsSuccess, function);
}