using OnRail.Extensions.OperateWhen;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<bool> predicate,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        bool condition,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<T> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, Result> predicate,
        Func<T> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(t => t.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(t => t.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<T> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(t => t.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicateFunc,
        Func<T> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<bool> predicate,
        Result result,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, result, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        bool condition,
        Func<Result> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        bool condition,
        Result result,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(condition, result));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => source.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Func<Result<T>, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Result<T>, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, bool> predicate,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry));

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<bool> predicate,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry));

    //TODO: Use OperateWhen, numOfTRy
    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, bool> predicate,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) => source.OnFail(result => predicate(result) ? function(result) : source);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Result<T> result,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(t => t.OperateWhen(predicate, result, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.OperateWhen(condition, function, numOfTry));

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Result<T> result
    ) => source.OnFail(sourceResult => sourceResult.OperateWhen(condition, result));

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11 + numOfTry
    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1) {
        var methodResult = await source;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? function(methodResult) : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate(), function);

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1) {
        var methodResult = await source;
        if (methodResult.IsSuccess)
            return methodResult;
        return condition ? function(methodResult) : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1) {
        var methodResult = await source;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? function() : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Result<T> result,
        int numOfTry = 1) {
        var methodResult = await source;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? result : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, bool> predicate,
        Func<Result> function,
        int numOfTry = 1) {
        var methodResult = await source;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? function() : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, bool> predicate,
        Result result,
        int numOfTry = 1) {
        var methodResult = await source;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? result : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<bool> predicate,
        Func<Result, Result> function,
        int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate(), function);

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        bool condition,
        Func<Result, Result> function,
        int numOfTry = 1) {
        var methodResult = await source;
        if (methodResult.IsSuccess)
            return methodResult;
        return condition ? function(methodResult) : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, bool> predicate,
        Func<Result, Result> function,
        int numOfTry = 1) {
        var methodResult = await source;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult) ? function(methodResult) : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, Result> predicate,
        Result result,
        int numOfTry = 1) {
        var methodResult = await source;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult).IsSuccess ? result : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result> predicate,
        Result result,
        int numOfTry = 1) {
        var methodResult = await source;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate().IsSuccess ? result : methodResult;
    }

    //TODO: Use OnFail and OperateWhen method - https://github.com/Payadel/OnRail/issues/11
    public static async Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, Result> predicate,
        Result<T> result,
        int numOfTry = 1) {
        var methodResult = await source;
        if (methodResult.IsSuccess)
            return methodResult;
        return predicate(methodResult).IsSuccess ? result : methodResult;
    }
}