namespace OnRail.Extensions;

public static class TeeExtensions {
    #region Tee

    public static T Tee<T>(
        this T @this,
        Action<T> action) {
        action(@this);
        return @this;
    }

    public static T Tee<T>(
        this T @this,
        Action? action) {
        action?.Invoke();
        return @this;
    }

    public static void Tee(
        Action? action) {
        action?.Invoke();
    }

    public static TSource Tee<TSource, TResult>(
        this TSource @this,
        Func<TSource, TResult> function) {
        function(@this);
        return @this;
    }

    public static TSource Tee<TSource, TResult>(
        this TSource @this,
        Func<TResult> function) {
        function();
        return @this;
    }

    public static void Tee<TResult>(
        Func<TResult> function) {
        function();
    }

    #endregion

    #region TeeAsync

    public static async Task TeeAsync<TResult>(
        Func<Task<TResult>> function) {
        await function();
    }

    public static async Task<T> TeeAsync<T>(
        this Task<T> @this,
        Action<T> action) {
        var t = await @this;
        action(t);
        return t;
    }

    public static async Task<T> TeeAsync<T>(
        this Task<T> @this,
        Action? action) {
        var t = await @this;
        action?.Invoke();
        return t;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, TResult> function) {
        var t = await @this;
        function(t);
        return t;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TResult> function) {
        var t = await @this;
        function();
        return t;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this TSource @this,
        Func<TSource, Task<TResult>> function) {
        await function(@this);
        return @this;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this TSource @this,
        Func<Task<TResult>> function) {
        await function();
        return @this;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<TSource, Task<TResult>> function) {
        var t = await @this;
        await function(t);
        return t;
    }

    public static async Task<TSource> TeeAsync<TSource, TResult>(
        this Task<TSource> @this,
        Func<Task<TResult>> function) {
        var t = await @this;
        await function();
        return t;
    }

    #endregion

    #region TryTee

    public static Result<T> TryTee<T>(
        this T @this,
        Action<T> action) => TryExtensions.Try(() => @this.Tee(action));

    public static Result<TSource> TryTee<TSource, TResult>(
        this TSource @this,
        Func<TSource, TResult> function) => TryExtensions.Try(() => @this.Tee(function));

    public static Result<TSource> TryTee<TSource, TResult>(
        this TSource @this,
        Func<TResult> function) => TryExtensions.Try(() => @this.Tee(function));

    public static Result TryTee<TResult>(
        Func<TResult> function) => TryExtensions.Try(() => Tee(function));

    public static Result<T> TryTee<T>(
        this T @this,
        Action? action) => TryExtensions.Try(() => @this.Tee(action));

    public static Result TryTee(Action? action) =>
        TryExtensions.Try(() => Tee(action));

    #endregion

    #region TryTeeAsync

    public static Task<Result> TryTeeAsync<TResult>(
        Func<Task<TResult>> function, int numOfTry) =>
        TryExtensions.TryAsync(() => TeeAsync(function), numOfTry);

    public static Task<Result<T>> TryTeeAsync<T>(
        this Task<T> @this, Action<T> action, int numOfTry) =>
        TryExtensions.TryAsync(() => @this.TeeAsync(action), numOfTry);

    public static Task<Result<T>> TryTeeAsync<T>(
        this Task<T> @this, Action? action, int numOfTry) =>
        TryExtensions.TryAsync(() => @this.TeeAsync(action), numOfTry);

    public static Task<Result<TSource>> TryTeeAsync<TSource, TResult>(
        this Task<TSource> @this, Func<TSource, TResult> function,
        int numOfTry) => TryExtensions.TryAsync(() => @this.TeeAsync(function), numOfTry);

    public static Task<Result<TSource>> TryTeeAsync<TSource, TResult>(
        this TSource @this, Func<TSource, Task<TResult>> function,
        int numOfTry) => TryExtensions.TryAsync(() => @this.TeeAsync(function), numOfTry);

    public static Task<Result<TSource>> TryTeeAsync<TSource, TResult>(
        this Task<TSource> @this, Func<TSource, Task<TResult>> function,
        int numOfTry) => TryExtensions.TryAsync(() => @this.TeeAsync(function), numOfTry);

    public static Task<Result<TSource>> TryTeeAsync<TSource, TResult>(
        this Task<TSource> @this, Func<TResult> function,
        int numOfTry) => TryExtensions.TryAsync(() => @this.TeeAsync(function), numOfTry);

    public static Task<Result<TSource>> TryTeeAsync<TSource, TResult>(
        this TSource @this, Func<Task<TResult>> function,
        int numOfTry) => TryExtensions.TryAsync(() => @this.TeeAsync(function), numOfTry);

    public static Task<Result<TSource>> TryTeeAsync<TSource, TResult>(
        this Task<TSource> @this, Func<Task<TResult>> function,
        int numOfTry) => TryExtensions.TryAsync(() => @this.TeeAsync(function), numOfTry);

    #endregion

    #region TeeOnSuccess

    public static Result<T> TeeOnSuccess<T>(
        this Result<T> @this,
        Action<T> action) {
        if (@this.IsSuccess)
            action(@this.Value);
        return @this;
    }

    public static Result<T> TeeOnSuccess<T>(
        this Result<T> @this,
        Action action) => @this
        .OnSuccess(() => @this.Tee(action));

    public static Result TeeOnSuccess(
        this Result @this,
        Action action) =>
        @this.OnSuccess(() => @this.Tee(action));

    public static Result<TSource> TeeOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> function) {
        if (@this.IsSuccess)
            function(@this.Value);
        return @this;
    }

    public static Result<TSource> TeeOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> function) => @this
        .OnSuccess(() => @this.Tee(function));

    public static Result TeeOnSuccess<TResult>(
        this Result @this,
        Func<TResult> function) =>
        @this.OnSuccess(() => @this.Tee(function));

    #endregion

    #region TeeOnSuccessAsync

    public static async Task<Result<T>> TeeOnSuccessAsync<T>(
        this Task<Result<T>> @this,
        Action<T> action) {
        var t = await @this;
        if (t.IsSuccess)
            action(t.Value);
        return t;
    }

    public static Task<Result<T>> TeeOnSuccessAsync<T>(
        this Task<Result<T>> @this,
        Action action) => @this
        .OnSuccessAsync(() => @this.Tee(action));

    public static Task<Result> TeeOnSuccessAsync(
        this Task<Result> @this,
        Action action) =>
        @this.OnSuccessAsync(() => @this.Tee(action));

    public static async Task<Result<TSource>> TeeOnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TSource, TResult> function) {
        var t = await @this;
        if (t.IsSuccess)
            function(t.Value);
        return t;
    }

    public static Task<Result<TSource>> TeeOnSuccessAsync<TSource, TResult>(
        this Task<Result<TSource>> @this,
        Func<TResult> function) => @this
        .OnSuccessAsync(() => @this.Tee(function));

    public static Task<Result> TeeOnSuccessAsync<TResult>(
        this Task<Result> @this,
        Func<TResult> function) =>
        @this.OnSuccessAsync(() => @this.Tee(function));

    #endregion

    #region TryTeeOnSuccess

    public static Result<T> TryTeeOnSuccess<T>(
        this Result<T> @this,
        Action<T> action) => @this
        .OnSuccess(value => value.TryTee(action));

    public static Result<T> TryTeeOnSuccess<T>(
        this Result<T> @this,
        Action action) => @this
        .OnSuccess(value => value.TryTee(action));

    public static Result TryTeeOnSuccess(
        this Result @this,
        Action action) => @this
        .OnSuccess(() => TryExtensions.Try(action));

    public static Result<TSource> TryTeeOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> function) => @this
        .OnSuccess(value => value.TryTee(function));

    public static Result<TSource> TryTeeOnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> function) => @this
        .OnSuccess(value => value.TryTee(function));

    public static Result TryTeeOnSuccess<TResult>(
        this Result @this,
        Func<TResult> function) => @this
        .OnSuccess(() => TryTee(function));

    #endregion

    #region TryTeeOnSuccessAsync

    public static Task<Result<T>> TryTeeOnSuccessAsync<T>(
        this Task<Result<T>> @this,
        Action<T> action) => @this
        .OnSuccessAsync(value => value.TryTee(action));

    public static Task<Result<T>> TryTeeOnSuccessAsync<T>(
        this Task<Result<T>> @this,
        Action action) => @this
        .OnSuccessAsync(value => value.TryTee(action));

    public static Task<Result> TryTeeOnSuccessAsync(
        this Task<Result> @this,
        Action action) => @this
        .OnSuccessAsync(() => TryExtensions.Try(action));

    #endregion
}