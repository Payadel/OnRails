using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.OperateWhen;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions;

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
}