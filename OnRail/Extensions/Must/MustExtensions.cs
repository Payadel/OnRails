using System.Collections;
using OnRail.Extensions.Fail;
using OnRail.Extensions.Map;
using OnRail.Extensions.Object;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.OperateWhen;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.Must;

//TODO: Test

public static class MustExtensions {
    public static Result<T> Must<T>(
        this T @this,
        bool predicate,
        ResultDetail errorDetail
    ) => @this.OperateWhen(!predicate, Result<T>.Fail(errorDetail));

    public static Result<T> Must<T>(
        this T @this,
        Func<bool> predicateFunc,
        ResultDetail errorDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFunc, numOfTry)
        .OnSuccess(predicate => @this.OperateWhen(!predicate, Result<T>.Fail(errorDetail)));

    public static Result<T> Must<T>(
        this T @this,
        bool predicate,
        Func<ResultDetail> errorDetail
    ) => @this.OperateWhen(!predicate, Result<T>.Fail(errorDetail));

    public static Result<T> Must<T>(
        this T @this,
        Func<bool> predicateFunc,
        Func<ResultDetail> errorDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFunc, numOfTry)
        .OnSuccess(predicate => @this.OperateWhen(!predicate, Result<T>.Fail(errorDetail)));

    public static Result MustNotNullOrEmpty(
        this IEnumerable? @this,
        ErrorDetail? errorDetail = null) {
        var error = errorDetail ?? new ErrorDetail(
            title: "IsNullOrEmptyError",
            message: "object is not null or empty.");
        return @this.IsNullOrEmpty()
            ? Result.Fail(error)
            : Result.Ok();
    }

    public static Result<T> MustNotNull<T>(
        this object? @this,
        ErrorDetail? errorDetail = null) =>
        @this.FailWhen(@this is null, errorDetail ?? new ErrorDetail(
                title: "NullError", message: "Object is null."))
            .Map((T) @this!);
}