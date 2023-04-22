using OnRails.Extensions.OperateWhen;
using OnRails.Extensions.Try;

namespace OnRails.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<bool> predicate,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        bool condition,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<T> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(condition, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, Result> predicate,
        Func<T> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(t => t.OperateWhen(condition, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(t => t.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<T> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(t => t.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicateFunc,
        Func<T> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicateFunc, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Func<Task<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<bool> predicate,
        Result result,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(predicate, result, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        bool condition,
        Func<Result> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        bool condition,
        Result result,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(condition, result),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => source.OperateWhen(condition, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Func<Result<T>, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Result<T>, Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Func<Task<Result<T>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, bool> predicate,
        Func<Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<bool> predicate,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, bool> predicate,
        Func<Result, Task<Result>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.OperateWhen(predicate, function, numOfTry),
        numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Result<T> result,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnFail(t => t.OperateWhen(predicate, result, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.OperateWhen(condition, function, numOfTry),
        numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Result<T> result
    ) => source.OnFail(sourceResult => sourceResult.OperateWhen(condition, result),
        numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);


    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<bool> predicate,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        bool condition,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(condition, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, bool> predicate,
        Result<T> result,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(sourceResult => sourceResult.OperateWhen(predicate, result, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, bool> predicate,
        Func<Result> function,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, bool> predicate,
        Result result,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(sourceResult => sourceResult.OperateWhen(predicate, result, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<bool> predicate,
        Func<Result, Result> function,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        bool condition,
        Func<Result, Result> function,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(condition, function, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, bool> predicate,
        Func<Result, Result> function,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(result => result.OperateWhen(predicate, function, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result, Result> predicate,
        Result result,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(sourceResult => sourceResult.OperateWhen(
                () => predicate(sourceResult).IsSuccess, result, numOfTry),
            numOfTry: 1);

    public static Task<Result> OnFailOperateWhen(
        this Task<Result> source,
        Func<Result> predicate,
        Result result,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(() => OperateWhenExtensions.OperateWhen(() => predicate().IsSuccess, result, numOfTry),
            numOfTry: 1);

    public static Task<Result<T>> OnFailOperateWhen<T>(
        this Task<Result<T>> source,
        Func<Result<T>, Result> predicate,
        Result<T> result,
        int numOfTry = 1) => TryExtensions.Try(source, numOfTry)
        .OnFail(sourceResult => sourceResult.OperateWhen(() => predicate(sourceResult).IsSuccess, result, numOfTry),
            numOfTry: 1);
}