using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
//TODO: Test
    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        TResult successResult) =>
        @this.IsSuccess
            ? Result<TResult>.Ok(successResult)
            : Result<TResult>.Fail(@this.Detail);

//TODO: Test
    public static Result<TResult> OnSuccess<TResult>(
        this Result @this,
        TResult successResult) =>
        @this.IsSuccess ? Result<TResult>.Ok(successResult) : Result<TResult>.Fail(@this.Detail);

//TODO: Test
    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> success,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? @this.Value!.Try(success, numOfTry)
            : Result<TResult>.Fail(@this.Detail);

//TODO: Test
    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> success,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(success, numOfTry)
            : Result<TResult>.Fail(@this.Detail);

//TODO: Test
    public static Result<TResult> OnSuccess<TResult>(
        this Result @this,
        Func<Result<TResult>> success,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(success, numOfTry)
            : Result<TResult>.Fail(@this.Detail);

    //TODO: Test
    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<TSource, Result> success,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? @this.Value!.Try(success, numOfTry)
            : Result.Fail(@this.Detail);

    //TODO: Test
    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<Result> success,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(success, numOfTry)
            : Result.Fail(@this.Detail);

    //TODO: Test
    public static Result OnSuccess(
        this Result @this,
        Func<Result> success,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(success, numOfTry)
            : Result.Fail(@this.Detail);

//TODO: Test
    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> success,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? @this.Value!.Try(success, numOfTry)
            : Result<TResult>.Fail(@this.Detail);

//TODO: Test
    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> success,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(success, numOfTry)
            : Result<TResult>.Fail(@this.Detail);

    //TODO: Test
    public static Result<TResult> OnSuccess<TResult>(
        this Result @this,
        Func<TResult> success,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(success, numOfTry)
            : Result<TResult>.Fail(@this.Detail);

    //TODO: Test
    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Action<TSource> success,
        int numOfTry = 1) => @this.IsSuccess
        ? @this.Value!.Try(success, numOfTry)
        : Result.Fail(@this.Detail);

//TODO: Test
    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Action success,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(success, numOfTry)
            : Result.Fail(@this.Detail);

//TODO: Test
    public static Result OnSuccess(
        this Result @this,
        Action success,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(success, numOfTry)
            : Result.Fail(@this.Detail);
}