namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        TResult successResult) =>
        @this.IsSuccess
            ? Result<TResult>.Ok(successResult)
            : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TResult>(
        this Result @this,
        TResult successResult) =>
        @this.IsSuccess ? Result<TResult>.Ok(successResult) : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> success) =>
        @this.IsSuccess ? success(@this.Value) : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> success) =>
        @this.IsSuccess ? success() : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TResult>(
        this Result @this,
        Func<Result<TResult>> success) =>
        @this.IsSuccess ? success() : Result<TResult>.Fail(@this.Detail);

    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<TSource, Result> success) =>
        @this.IsSuccess ? success(@this.Value) : Result.Fail(@this.Detail);

    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<Result> success) =>
        @this.IsSuccess ? success() : Result.Fail(@this.Detail);

    public static Result OnSuccess(
        this Result @this,
        Func<Result> success) =>
        @this.IsSuccess ? success() : Result.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> success) =>
        @this.IsSuccess
            ? Result<TResult>.Ok(success(@this.Value))
            : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> success) =>
        @this.IsSuccess ? Result<TResult>.Ok(success()) : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TResult>(
        this Result @this,
        Func<TResult> success) =>
        @this.IsSuccess ? Result<TResult>.Ok(success()) : Result<TResult>.Fail(@this.Detail);

    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Action<TSource> success) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        success(@this.Value);
        return Result.Ok();
    }

    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Action success) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        success();
        return Result.Ok();
    }

    public static Result OnSuccess(
        this Result @this,
        Action success) {
        if (!@this.IsSuccess)
            return Result.Fail(@this.Detail);
        success();
        return Result.Ok();
    }
}