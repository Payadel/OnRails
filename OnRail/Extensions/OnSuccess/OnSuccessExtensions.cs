using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test

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
        @this.IsSuccess
            ? Result<TResult>.Ok(successResult)
            : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? @this.Value!.Try(function, numOfTry)
            : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<Result<TResult>> function,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TResult>(
        this Result @this,
        Func<Result<TResult>> function,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(@this.Detail);


    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<TSource, Result> function,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? @this.Value!.Try(function, numOfTry)
            : Result.Fail(@this.Detail);


    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Func<Result> function,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result.Fail(@this.Detail);


    public static Result OnSuccess(
        this Result @this,
        Func<Result> function,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TSource, TResult> function,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? @this.Value!.Try(function, numOfTry)
            : Result<TResult>.Fail(@this.Detail);

    public static Result<TResult> OnSuccess<TSource, TResult>(
        this Result<TSource> @this,
        Func<TResult> function,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(@this.Detail);


    public static Result<TResult> OnSuccess<TResult>(
        this Result @this,
        Func<TResult> function,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(function, numOfTry)
            : Result<TResult>.Fail(@this.Detail);


    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Action<TSource> action,
        int numOfTry = 1) => @this.IsSuccess
        ? @this.Value!.Try(action, numOfTry)
        : Result.Fail(@this.Detail);

    public static Result OnSuccess<TSource>(
        this Result<TSource> @this,
        Action action,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(action, numOfTry)
            : Result.Fail(@this.Detail);

    public static Result OnSuccess(
        this Result @this,
        Action action,
        int numOfTry = 1) =>
        @this.IsSuccess
            ? TryExtensions.Try(action, numOfTry)
            : Result.Fail(@this.Detail);
}