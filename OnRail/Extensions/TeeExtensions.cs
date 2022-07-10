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

    #region Tee Async

    public static async Task Tee<TResult>(
        Func<Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.Try(function, numOfTry);
    }

    public static async Task<T> Tee<T>(
        this Task<T> @this,
        Action<T> action,
        int numOfTry = 1) {
        await TryExtensions.Try(async () => {
            var t = await @this;
            action(t);
        }, numOfTry);

        return await @this;
    }

    public static async Task<T> Tee<T>(
        this Task<T> @this,
        Action action,
        int numOfTry = 1) {
        await TryExtensions.Try(async () => {
            await @this;
            action();
        }, numOfTry);

        return await @this;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        await TryExtensions.Try(async () => {
            var t = await @this;
            function(t);
        }, numOfTry);

        return await @this;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> @this,
        Func<TResult> function,
        int numOfTry = 1) {
        await TryExtensions.Try(async () => {
            await @this;
            function();
        }, numOfTry);

        return await @this;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.Try(() => function(@this), numOfTry);
        return @this;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this TSource @this,
        Func<Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.Try(function, numOfTry);
        return @this;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.Try(async () => {
            var t = await @this;
            await function(t);
        }, numOfTry);

        return await @this;
    }

    public static async Task<TSource> Tee<TSource, TResult>(
        this Task<TSource> @this,
        Func<Task<TResult>> function,
        int numOfTry = 1) {
        await TryExtensions.Try(async () => {
            await @this;
            await function();
        }, numOfTry);

        return await @this;
    }

    #endregion

    #region TeeOnSuccess

    //TODO: numOfTry
    //TODO: Test

    public static Result<T> TeeOnSuccess<T>(
        this Result<T> @this,
        Action<T> action,
        int numOfTry = 1) {
        @this.OnSuccess(() => action(@this.Value!));
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
        @this.OnSuccess(() => function(@this.Value!));
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

    #region TeeOnSuccess Async

    //TODO: numOfTry
    //TODO: Test

    public static async Task<Result<T>> TeeOnSuccess<T>(
        this Task<Result<T>> @this,
        Action<T> action,
        int numOfTry = 1) {
        await @this.OnSuccessAsync(action);
        return await @this;
    }

    public static Task<Result<T>> TeeOnSuccess<T>(
        this Task<Result<T>> @this,
        Action action,
        int numOfTry = 1) => @this
        .OnSuccessAsync(() => @this.Tee<Task<Result<T>>>(action));

    public static Task<Result> TeeOnSuccess(
        this Task<Result> @this,
        Action action,
        int numOfTry = 1) =>
        @this.OnSuccessAsync(() => @this.Tee<Task<Result>>(action));

    public static async Task<Result<TSource>> TeeOnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) {
        await @this.OnSuccessAsync(function);
        return await @this;
    }

    public static Task<Result<TSource>> TeeOnSuccess<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> function,
        int numOfTry = 1) => @this
        .OnSuccessAsync(() => @this.Tee<Task<Result<TSource>>, TResult>(function));

    public static Task<Result> TeeOnSuccess<TResult>(
        this Task<Result> @this,
        Func<TResult> function,
        int numOfTry = 1) =>
        @this.OnSuccessAsync(() => @this.Tee<Task<Result>, TResult>(function));

    #endregion

    //TODO: TeeOnFail
    //TODO: TeeOnFail Async
}