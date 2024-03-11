using System.Diagnostics;
using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails.Extensions.OperateWhen;

[DebuggerStepThrough]
public static partial class OperateWhenExtensions {
    public static Result OperateWhen(
        bool condition,
        Func<Result> function,
        int numOfTry = 1
    ) => condition ? TryExtensions.Try(function, numOfTry) : Result.Ok();

    public static Result OperateWhen(
        bool condition,
        ErrorDetail errorDetail
    ) => condition
        ? Result.Fail(errorDetail)
        : Result.Ok();

    public static Result OperateWhen(
        bool condition,
        Result result
    ) => condition ? result : Result.Ok();

    public static Result OperateWhen(
        Func<bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result OperateWhen(
        Func<bool> predicate,
        Result result,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => OperateWhen(condition, result), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        bool condition,
        Result<T> result
    ) => condition ? result : Result<T>.Ok(source);

    public static Result OperateWhen(
        bool condition,
        Action action,
        int numOfTry = 1) {
        return condition
            ? TryExtensions.Try(action, numOfTry)
            : Result.Ok();
    }

    public static Result OperateWhen(
        Func<bool> predicate,
        Action action,
        int numOfTry = 1) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => OperateWhen(condition, action, numOfTry), numOfTry: 1);

    //TODO: complete tests for numOfTry
    public static Result<T> OperateWhen<T>(
        this T source,
        bool condition,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => condition
        ? TryExtensions.Try(function, numOfTry)
        : Result<T>.Ok(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        bool condition,
        Func<T> function,
        int numOfTry = 1
    ) => condition
        ? TryExtensions.Try(function, numOfTry)
        : Result<T>.Ok(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        bool condition,
        Func<T, T> function,
        int numOfTry = 1
    ) => condition
        ? source.Try(function, numOfTry)
        : Result<T>.Ok(source);

    public static Result OperateWhen(
        this Result source,
        bool condition,
        Func<Result> operation,
        int numOfTry = 1
    ) => condition
        ? TryExtensions.Try(operation, numOfTry)
        : source;

    public static Result OperateWhen(
        this Result source,
        bool condition,
        Result result
    ) => condition ? result : source;

    public static Result OperateWhen(
        this Result source,
        bool condition,
        Func<Result, Result> operation,
        int numOfTry = 1
    ) => condition
        ? source.Try(operation, numOfTry)
        : source;

    public static Result OperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Result> operation,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => condition
            ? TryExtensions.Try(operation, numOfTry)
            : source);

    public static Result OperateWhen(
        this Result source,
        Func<bool> predicate,
        Result result,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => condition ? result : source);

    public static Result OperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Func<Result> operation,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => condition
            ? TryExtensions.Try(operation, numOfTry)
            : source);

    public static Result OperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Result result,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => condition ? result : source);

    public static Result OperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Result, Result> operation,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => condition
            ? source.Try(operation, numOfTry)
            : source);

    public static Result OperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Func<Result, Result> operation,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => condition
            ? source.Try(operation, numOfTry)
            : source);

    public static Result<T> OperateWhen<T>(
        this Result<T> _,
        Result predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => predicate.OnSuccess(operation, numOfTry);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        Result predicate,
        Action operation,
        int numOfTry = 1
    ) => predicate.OnSuccessTee(operation, numOfTry)
        .OnSuccess(() => source);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => condition
        ? TryExtensions.Try(operation, numOfTry)
        : source;

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Result<T>, Result<T>> operation,
        int numOfTry = 1
    ) => condition
        ? source.Try(operation, numOfTry)
        : source;

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Result<T>, Result<T>> operation,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, operation, numOfTry), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        Func<Result<T>, bool> predicate,
        Func<Result<T>, Result<T>> operation,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, operation, numOfTry), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        Func<Result<T>, bool> predicate,
        Result<T> result,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, result), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        Func<Result<T>, bool> predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, operation, numOfTry), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, operation, numOfTry), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        bool condition,
        Action operation,
        int numOfTry = 1
    ) => condition
        ? TryExtensions.Try(operation, numOfTry)
            .OnSuccess(() => source)
        : source;

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        Func<Result> predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => source.OperateWhen(predicate().Success, operation, numOfTry);

    public static Result OperateWhen(
        this Result source,
        bool condition,
        Action operation,
        int numOfTry = 1
    ) => condition
        ? TryExtensions.Try(operation, numOfTry)
        : source;

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Result<T> result,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, result), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<T> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<T, T> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        bool condition,
        Func<Result> function,
        int numOfTry = 1
    ) => condition
        ? TryExtensions.Try(function, numOfTry)
            .OnSuccess(source)
        : Result<T>.Ok(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, bool> predicateFun,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.Try(predicateFun, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, bool> predicateFun,
        Result<T> result,
        int numOfTry = 1
    ) => source.OperateWhen(() => predicateFun(source), result, numOfTry);

    public static Result<T> OperateWhen<T>(
        this T source,
        bool condition,
        ErrorDetail errorDetail
    ) => condition
        ? Result<T>.Fail(errorDetail)
        : Result<T>.Ok(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<bool> predicateFunc,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFunc, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, errorDetailFunc, numOfTry), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<bool> predicateFunc,
        ErrorDetail errorDetail,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFunc, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, errorDetail), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OperateWhen(() => predicate(source), function, numOfTry);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<T> function,
        int numOfTry = 1
    ) => condition
        ? TryExtensions.Try(function, numOfTry)
        : source;

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        Func<Result<T>, Result> predicateFunc,
        Func<T> function,
        int numOfTry = 1
    ) => predicateFunc(source).Success
        ? TryExtensions.Try(function, numOfTry)
        : source;

    public static Result<T> OperateWhen<T>(
        this T source,
        bool condition,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => condition
        ? source.Try(function, numOfTry)
        : Result<T>.Ok(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<T, T> operation,
        int numOfTry = 1
    ) => source.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, operation, numOfTry), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicate, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        bool condition,
        Func<T, Result> function,
        int numOfTry = 1
    ) => condition
        ? source.Try(function, numOfTry)
            .OnSuccess(source)
        : Result<T>.Ok(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OperateWhen(() => predicate(source), function, numOfTry);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, bool> predicateFunc,
        Func<T, Result> function,
        int numOfTry = 1
    ) => source.Try(predicateFunc, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result OperateWhen(
        Func<Result> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => OperateWhen(predicate().Success, function, numOfTry);

    public static Result OperateWhen(
        Func<Result> predicate,
        Action action,
        int numOfTry = 1
    ) => OperateWhen(predicate().Success, action, numOfTry);

    public static Result OperateWhen(
        Result predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => OperateWhen(predicate.Success, function, numOfTry);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<Result> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OperateWhen(predicate().Success, function, numOfTry);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        Func<bool> predicateFunc,
        Func<T> function,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFunc, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        Func<Result<T>, bool> predicateFunc,
        Func<T> function,
        int numOfTry = 1
    ) => source.Try(predicateFunc, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, Result> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OperateWhen(predicate(source).Success, function, numOfTry);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        Func<bool> predicateFunc,
        Result<T> result,
        int numOfTry = 1
    ) => TryExtensions.Try(predicateFunc, numOfTry)
        .OnSuccess(condition => source.OperateWhen(condition, result), numOfTry: 1);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<Result> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OperateWhen(predicate().Success, function, numOfTry);

    public static Result<T> OperateWhen<T>(
        this T source,
        Result predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OperateWhen(predicate.Success, function, numOfTry);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, Result> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OperateWhen(predicate(source).Success, function, numOfTry);

    public static Result<T> OperateWhen<T>(
        this T source,
        bool condition,
        Action action,
        int numOfTry = 1) => OperateWhen(condition, action, numOfTry)
        .OnSuccess(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Action action,
        int numOfTry = 1) =>
        TryExtensions.Try(predicate, numOfTry)
            .OnSuccess(condition => OperateWhen(condition, action, numOfTry), numOfTry: 1)
            .OnSuccess(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, bool> predicateFun,
        Action action,
        int numOfTry = 1) =>
        TryExtensions.Try(() => predicateFun(source), numOfTry)
            .OnSuccess(condition => OperateWhen(condition, action, numOfTry), numOfTry: 1)
            .OnSuccess(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, bool> predicateFun,
        Func<T, ErrorDetail> errorDetail,
        int numOfTry = 1) =>
        TryExtensions.Try(() => predicateFun(source), numOfTry)
            .OnSuccess(condition => source.OperateWhen(condition, errorDetail, numOfTry), numOfTry: 1)
            .OnSuccess(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        bool condition,
        Func<T, ErrorDetail> errorDetailFunc,
        int numOfTry = 1) => condition
        ? source.Try(errorDetailFunc, numOfTry)
            .OnSuccess(Result<T>.Fail)
        : Result<T>.Ok(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        bool condition,
        Action<T> action,
        int numOfTry = 1) =>
        OperateWhen(condition, () => action(source), numOfTry)
            .OnSuccess(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<bool> predicate,
        Action<T> action,
        int numOfTry = 1) =>
        OperateWhen(predicate, () => action(source), numOfTry)
            .OnSuccess(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, bool> predicateFun,
        Action<T> action,
        int numOfTry = 1) =>
        OperateWhen(() => predicateFun(source), () => action(source), numOfTry)
            .OnSuccess(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        Result predicate,
        Action action,
        int numOfTry = 1
    ) => source.OperateWhen(predicate.Success, action, numOfTry);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, Result> predicateFun,
        Action action,
        int numOfTry = 1
    ) => OperateWhen(() => predicateFun(source), action, numOfTry)
        .OnSuccess(source);

    public static Result<T> OperateWhen<T>(
        this T source,
        Result predicate,
        Action<T> action,
        int numOfTry = 1
    ) => source.OperateWhen(predicate.Success, action, numOfTry);

    public static Result<T> OperateWhen<T>(
        this T source,
        Func<T, Result> predicate,
        Action<T> action,
        int numOfTry = 1
    ) => OperateWhen(() => predicate(source), () => action(source), numOfTry)
        .OnSuccess(source);

    public static Result<T> OperateWhen<T>(
        this Result<T> source,
        bool condition,
        Result<T> result) => condition
        ? result
        : source;
}