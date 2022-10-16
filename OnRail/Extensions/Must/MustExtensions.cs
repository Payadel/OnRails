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
        this T source,
        bool condition,
        ErrorDetail? errorDetail
    ) => source.OperateWhen(!condition, Result<T>.Fail(errorDetail));

    public static Result<T> Must<T>(
        this T source,
        Func<bool> predicate,
        ErrorDetail? errorDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(!condition, Result<T>.Fail(errorDetail)));

    public static Result<T> Must<T>(
        this T source,
        bool condition,
        Func<ErrorDetail?> errorDetailFunc
    ) => source.OperateWhen(!condition, Result<T>.Fail(errorDetailFunc));

    public static Result<T> Must<T>(
        this T source,
        Func<bool> predicate,
        Func<ErrorDetail?> errorDetailFunc,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(!condition, Result<T>.Fail(errorDetailFunc)));

    public static Result MustNotNullOrEmpty(
        this IEnumerable? source,
        ErrorDetail? errorDetail = null
    ) {
        var error = errorDetail ?? new ErrorDetail(
            title: "IsNullOrEmptyError",
            message: "object is not null or empty.");
        return source.IsNullOrEmpty()
            ? Result.Fail(error)
            : Result.Ok();
    }

    public static Result<T> MustNotNull<T>(
        this object? source,
        ErrorDetail? errorDetail = null) =>
        source.FailWhen(source is null, errorDetail ?? new ErrorDetail(
                title: "NullError", message: "Object is null."))
            .Map((T) source!);
}