namespace OnRail.Extensions;

public static class TeeExtensions {
    #region Tee

    public static T Tee<T>(
        this T @this,
        Action<T> action,
        int numOfTry = 1) {
        TryExtensions.Try(() => action(@this), numOfTry);
        return @this;
    }

    public static T Tee<T>(
        this T @this,
        Action action,
        int numOfTry = 1) {
        TryExtensions.Try(action, numOfTry);
        return @this;
    }

    public static void Tee(
        Action action,
        int numOfTry = 1) {
        TryExtensions.Try(action, numOfTry);
    }

    public static TSource Tee<TSource, TResult>(
        this TSource @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        TryExtensions.Try(() => function(@this), numOfTry);
        return @this;
    }

    public static TSource Tee<TSource, TResult>(
        this TSource @this,
        Func<TResult> function,
        int numOfTry = 1) {
        TryExtensions.Try(function, numOfTry);
        return @this;
    }

    public static void Tee<TResult>(
        Func<TResult> function,
        int numOfTry = 1) {
        TryExtensions.Try(function, numOfTry);
    }

    #endregion

    #region TeeAsync

    public static async Task TeeAsync<TResult>(
        Func<Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.TryAsync(function, numOfTry);
    }

    public static async Task<T> TeeAsync<T>(
        this Task<T> @this,
        Action<T> action,
        int numOfTry = 1) {
        await TryExtensions.TryAsync(async () => {
            var t = await @this;
            action(t);
        }, numOfTry);

        return await @this;
    }

    public static async Task<T> TeeAsync<T>(
        this Task<T> @this,
        Action action,
        int numOfTry = 1) {
        await TryExtensions.TryAsync(async () => {
            await @this;
            action();
        }, numOfTry);

        return await @this;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        await TryExtensions.TryAsync(async () => {
            var t = await @this;
            function(t);
        }, numOfTry);

        return await @this;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TResult> function,
        int numOfTry = 1) {
        await TryExtensions.TryAsync(async () => {
            await @this;
            function();
        }, numOfTry);

        return await @this;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.TryAsync(() => function(@this), numOfTry);
        return @this;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this TSource @this,
        Func<Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.TryAsync(function, numOfTry);
        return @this;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.TryAsync(async () => {
            var t = await @this;
            await function(t);
        }, numOfTry);

        return await @this;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.TryAsync(async () => {
            await @this;
            await function();
        }, numOfTry);

        return await @this;
    }

    #endregion

    #region TeeOnSuccess

    public static Result<T> TeeOnSuccess<T>(
        this Result<T> @this,
        Action<T> action,
        int numOfTry = 1) {
        if (@this.IsSuccess)
            action(@this.Value);
        return @this;
    }

    public static Result<T> TeeOnSuccess<T>(
        this Result<T> @this,
        Action action,
        int numOfTry = 1) => @this
        .OnSuccess(() => @this.Tee(action));

    public static Result TeeOnSuccess(
        this Result @this,
        Action action,
        int numOfTry = 1) =>
        @this.OnSuccess(() => @this.Tee(action));

    public static Result<TSource> TeeOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        if (@this.IsSuccess)
            function(@this.Value);
        return @this;
    }

    public static Result<TSource> TeeOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> function,
        int numOfTry = 1) => @this
        .OnSuccess(() => @this.Tee(function));

    public static Result TeeOnSuccess<TResult>(
        this Result @this,
        Func<TResult> function,
        int numOfTry = 1) =>
        @this.OnSuccess(() => @this.Tee(function));

    #endregion

    #region TeeOnSuccessAsync

    public static async Task<Result<T>> TeeOnSuccessAsync<T>(
        this Task<Result<T>> @this,
        Action<T> action,
        int numOfTry = 1) {
        var t = await @this;
        if (t.IsSuccess)
            action(t.Value);
        return t;
    }

    public static Task<Result<T>> TeeOnSuccessAsync<T>(
        this Task<Result<T>> @this,
        Action action,
        int numOfTry = 1) => @this
        .OnSuccessAsync(() => @this.Tee(action));

    public static Task<Result> TeeOnSuccessAsync(
        this Task<Result> @this,
        Action action,
        int numOfTry = 1) =>
        @this.OnSuccessAsync(() => @this.Tee(action));

    public static async Task<Result<TSource>> TeeOnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        var t = await @this;
        if (t.IsSuccess)
            function(t.Value);
        return t;
    }

    public static Task<Result<TSource>> TeeOnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> function,
        int numOfTry = 1) => @this
        .OnSuccessAsync(() => @this.Tee(function));

    public static Task<Result> TeeOnSuccessAsync<TResult>(
        this Task<Result> @this,
        Func<TResult> function,
        int numOfTry = 1) =>
        @this.OnSuccessAsync(() => @this.Tee(function));

    #endregion

    //TODO: TeeOnFail
    //TODO: TeeOnFailAsync
}