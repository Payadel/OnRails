using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate() ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate(source) ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate(source) ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate() ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate() ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate().IsSuccess ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result> OnSuccessFailWhen(
        this Task<Result> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate.IsSuccess ? Result.Fail(errorDetail) : Result.Ok());

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate(source).IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<T, Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate(source).IsSuccess ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate().IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Func<Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate().IsSuccess ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source =>
        predicate.IsSuccess ? Result<T>.Fail(errorDetail) : Result<T>.Ok(source));

    public static Task<Result<T>> OnSuccessFailWhen<T>(
        this Task<Result<T>> @this,
        Result predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate.IsSuccess ? Result<T>.Fail(errorDetail(source)) : Result<T>.Ok(source));
}