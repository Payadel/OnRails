namespace OnRail.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> @this, bool predicate) =>
        @this.OnFailOperateWhen(predicate, Result.Ok);

    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> @this, Result predicate) =>
        @this.OnFailOperateWhen(predicate.IsSuccess, Result.Ok);

    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> @this, Func<bool> predicate) =>
        @this.OnFailSuccessWhen(predicate());

    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> @this, Func<Result, bool> predicate) =>
        @this.OnFailOperateWhen(predicate, Result.Ok);

    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> @this, Func<Result> predicate) =>
        @this.OnFailSuccessWhen(predicate().IsSuccess);

    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> @this, Func<Result, Result> predicate) =>
        @this.OnFailOperateWhen(predicate, Result.Ok());

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, bool predicate, T result) =>
        @this.OnFailOperateWhen(predicate, () => Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, bool predicate, Func<T> result) =>
        @this.OnFailOperateWhen(predicate, () => Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, bool predicate, Func<Task<T>> result) =>
        @this.OnFailOperateWhen(predicate,
            async () => Result<T>.Ok(await result()));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Result predicate, T result) =>
        @this.OnFailOperateWhen(predicate.IsSuccess, () => Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Result predicate, Func<T> result) =>
        @this.OnFailOperateWhen(predicate.IsSuccess, () => Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Result predicate, Func<Task<T>> result) =>
        @this.OnFailOperateWhen(predicate.IsSuccess,
            async () => Result<T>.Ok(await result()));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Func<bool> predicate, T result) =>
        @this.OnFailOperateWhen(predicate, () => Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Func<Result<T>, bool> predicate, T result) =>
        @this.OnFailOperateWhen(predicate, () => Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Func<bool> predicate, Func<T> result) =>
        @this.OnFailOperateWhen(predicate, () => Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Func<Result<T>, bool> predicate, Func<T> result) =>
        @this.OnFailOperateWhen(predicate, () => Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Func<bool> predicate, Func<Task<T>> result) =>
        @this.OnFailOperateWhen(predicate,
            async () => Result<T>.Ok(await result()));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Func<Result<T>, bool> predicate, Func<Task<T>> result) =>
        @this.OnFailOperateWhen(predicate,
            async () => Result<T>.Ok(await result()));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Func<Result> predicate, T result) =>
        @this.OnFailOperateWhen(predicate().IsSuccess, () => Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Func<Result<T>, Result> predicate, T result) =>
        @this.OnFailOperateWhen(predicate, Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Func<Result> predicate, Func<T> result) =>
        @this.OnFailOperateWhen(predicate().IsSuccess, () => Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Func<Result<T>, Result> predicate, Func<T> result) =>
        @this.OnFailOperateWhen(predicate, Result<T>.Ok(result()));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> @this, Func<Result> predicate, Func<Task<T>> result) =>
        @this.OnFailOperateWhen(predicate().IsSuccess,
            async () => Result<T>.Ok(await result()));
}