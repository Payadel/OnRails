using System.Diagnostics;
using OnRails.Extensions.Fail;
using OnRails.Extensions.Map;
using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.OperateWhen;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails.Extensions.Must;

[DebuggerStepThrough]
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
        .OnSuccess(condition => source.OperateWhen(!condition, Result<T>.Fail(errorDetail)), numOfTry: 1);

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
        .OnSuccess(condition => source.OperateWhen(!condition, Result<T>.Fail(errorDetailFunc)), numOfTry: 1);

    public static Result<T> MustNotNull<T>(
        this object? source,
        ErrorDetail? errorDetail = null) =>
        source.FailWhen(source is null, errorDetail ?? new ErrorDetail(
                title: "NullError", message: "Object is null."))
            .Map((T)source!);
}