using OnRail.Extensions.OperateWhen;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<bool> predicateFunc,
        Func<Task<Result>> operation,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(() => OperateWhenExtensions.OperateWhen(predicateFunc, operation, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        bool predicate,
        Func<Task<Result>> operation,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<bool> predicateFunc,
        Func<Result> operation,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(() => OperateWhenExtensions.OperateWhen(predicateFunc, operation, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<bool> predicateFunc,
        Result result,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(() => OperateWhenExtensions.OperateWhen(predicateFunc, result, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        bool predicate,
        Func<Result> operation,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        bool predicate,
        Result result,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, result));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Func<Task<Result<T>>> operation,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(predicateFunc, operation, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task<Result<T>>> operation,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(() => @this.OperateWhen(predicate, operation, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicateFunc,
        Func<Result<T>, Task<Result<T>>> operation,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, operation, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Func<Result<T>, Task<Result<T>>> operation,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, operation, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicateFunc,
        Func<Task<Result<T>>> operation,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, operation, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result, bool> predicateFunc,
        Func<Task<Result>> operation,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, operation, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<bool> predicateFunc,
        Func<Result, Task<Result>> operation,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, operation, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result, bool> predicate,
        Func<Result, Task<Result>> operation,
        int numOfTry = 1
    ) => @this.OnFail(result => predicate(result) ? operation(result) : @this);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnFailOperateWhen(predicateFunc(), operation);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnFail(methodResult => methodResult.OperateWhen(predicate, operation));

    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicate,
        Func<Result<T>, Result<T>> operation,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? operation(methodResult) : methodResult;
    }

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Func<Result<T>, Result<T>> operation,
        int numOfTry = 1) =>
        @this.OnFailOperateWhen(predicateFunc(), operation);

    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Result<T>, Result<T>> operation,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate ? operation(methodResult) : methodResult;
    }

    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicate,
        Func<Result<T>> operation,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? operation() : methodResult;
    }

    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result, bool> predicate,
        Func<Result> operation,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? operation() : methodResult;
    }

    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result, bool> predicate,
        Result result,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? result : methodResult;
    }

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<bool> predicateFunc,
        Func<Result, Result> operation,
        int numOfTry = 1) =>
        @this.OnFailOperateWhen(predicateFunc(), operation);

    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        bool predicate,
        Func<Result, Result> operation,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate ? operation(methodResult) : methodResult;
    }

    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result, bool> predicate,
        Func<Result, Result> operation,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? operation(methodResult) : methodResult;
    }

    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result, Result> predicate,
        Result result,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult).IsSuccess ? result : methodResult;
    }

    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, Result> predicate,
        Result<T> result,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult).IsSuccess ? result : methodResult;
    }
}