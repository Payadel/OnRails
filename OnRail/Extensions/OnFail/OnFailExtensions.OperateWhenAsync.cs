using OnRail.Extensions.OperateWhen;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<bool> predicateFunc,
        Func<Task<Result>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(() => OperateWhenExtensions.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        bool predicate,
        Func<Task<Result>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<T> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(result => result.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, Result> predicateFunc,
        Func<T> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(result => result.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(t => t.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Func<Task<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(t => t.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Func<T> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(t => t.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicateFunc,
        Func<T> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(result => result.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicateFunc,
        Func<Task<T>> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(result => result.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<bool> predicateFunc,
        Func<Result> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(() => OperateWhenExtensions.OperateWhen(predicateFunc, function, numOfTry));

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
        Func<Result> function,
        int numOfTry = 1) =>
        TryExtensions.Try(@this, numOfTry)
            .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

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
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(() => @this.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicateFunc,
        Func<Result<T>, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Func<Result<T>, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicateFunc,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result, bool> predicateFunc,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<bool> predicateFunc,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result, bool> predicateFunc,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) => @this.OnFail(result => predicateFunc(result) ? function(result) : @this);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Result<T> result,
        int numOfTry = 1
    ) => TryExtensions.Try(@this, numOfTry)
        .OnFail(t => t.OperateWhen(predicateFunc, result, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => @this.OnFail(result => result.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Result<T> function
    ) => @this.OnFail(result => result.OperateWhen(predicate, function));

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicateFunc,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicateFunc(methodResult) ? function(methodResult) : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<bool> predicateFunc,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1) =>
        @this.OnFailOperateWhen(predicateFunc(), function);

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        bool predicate,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate ? function(methodResult) : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicateFunc,
        Func<Result<T>> function,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicateFunc(methodResult) ? function() : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, bool> predicateFunc,
        Result<T> result,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicateFunc(methodResult) ? result : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result, bool> predicateFunc,
        Func<Result> function,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicateFunc(methodResult) ? function() : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result, bool> predicateFunc,
        Result result,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicateFunc(methodResult) ? result : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<bool> predicateFunc,
        Func<Result, Result> function,
        int numOfTry = 1) =>
        @this.OnFailOperateWhen(predicateFunc(), function);

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        bool predicate,
        Func<Result, Result> function,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate ? function(methodResult) : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result, bool> predicateFunc,
        Func<Result, Result> function,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicateFunc(methodResult) ? function(methodResult) : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
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

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> @this,
        Func<Result> predicate,
        Result result,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate().IsSuccess ? result : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
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