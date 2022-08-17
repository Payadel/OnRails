namespace OnRail.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Result OnFailSuccessWhen(
        this Result @this, bool predicate) =>
        @this.OnFailOperateWhen(predicate, Result.Ok);

    public static Result OnFailSuccessWhen(
        this Result @this, Func<bool> predicate) =>
        @this.OnFailOperateWhen(predicate, Result.Ok);

    public static Result OnFailSuccessWhen(
        this Result @this, Result predicate) =>
        @this.OnFailOperateWhen(predicate.IsSuccess, Result.Ok);

    public static Result OnFailSuccessWhen(
        this Result @this, Func<Result, bool> predicate) =>
        @this.OnFailOperateWhen(predicate, Result.Ok);

    public static Result OnFailSuccessWhen(
        this Result @this, Func<Result> predicate) =>
        @this.OnFailSuccessWhen(predicate());

    public static Result OnFailSuccessWhen(
        this Result @this, Func<Result, Result> predicate) =>
        @this.OnFailSuccessWhen(predicate(@this));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, bool predicate, T result) =>
        @this.OnFailOperateWhen(predicate, Result<T>.Ok(result));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, bool predicate, Func<T> result) =>
        @this.OnFailOperateWhen(predicate, Result<T>.Ok(result()));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Result predicate, T result) =>
        @this.OnFailOperateWhen(predicate.IsSuccess, Result<T>.Ok(result));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Result predicate, Func<T> result) =>
        @this.OnFailOperateWhen(predicate.IsSuccess, Result<T>.Ok(result()));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<bool> predicate, T result) =>
        @this.OnFailOperateWhen(predicate, Result<T>.Ok(result));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<Result> predicate, T result) =>
        @this.OnFailSuccessWhen(predicate().IsSuccess, result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<Result<T>, Result> predicate, T result) =>
        @this.OnFailSuccessWhen(predicate(@this).IsSuccess, result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<Result> predicate, Func<T> result) =>
        @this.OnFailSuccessWhen(predicate().IsSuccess, result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> @this, Func<Result<T>, Result> predicate, Func<T> result) =>
        @this.OnFailSuccessWhen(predicate(@this).IsSuccess, result);
}