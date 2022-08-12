using OnRail.ResultDetails;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Result OnSuccessFailWhen(
        this Result @this,
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate() ? Result.Fail(errorDetail) : @this);

    public static Result OnSuccessFailWhen(
        this Result @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate ? Result.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source => predicate(source) ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source => predicate(source) ? Result<T>.Fail(errorDetail(source)) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<bool> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate() ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<bool> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source => predicate() ? Result<T>.Fail(errorDetail(source)) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        bool predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source => predicate ? Result<T>.Fail(errorDetail(source)) : @this);

    public static Result OnSuccessFailWhen(
        this Result @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate().IsSuccess ? Result.Fail(errorDetail) : @this);

    public static Result OnSuccessFailWhen(
        this Result @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate.IsSuccess ? Result.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(source => predicate(source).IsSuccess ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source =>
        predicate(source).IsSuccess ? Result<T>.Fail(errorDetail(source)) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate().IsSuccess ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source => predicate().IsSuccess ? Result<T>.Fail(errorDetail(source)) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Result predicate,
        ErrorDetail errorDetail
    ) => @this.OnSuccess(() => predicate.IsSuccess ? Result<T>.Fail(errorDetail) : @this);

    public static Result<T> OnSuccessFailWhen<T>(
        this Result<T> @this,
        Result predicate,
        Func<T, ErrorDetail> errorDetail
    ) => @this.OnSuccess(source => predicate.IsSuccess ? Result<T>.Fail(errorDetail(source)) : @this);
}