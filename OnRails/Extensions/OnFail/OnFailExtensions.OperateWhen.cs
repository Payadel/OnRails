using OnRails.Extensions.OperateWhen;

namespace OnRails.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result OnFailOperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        bool condition,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        bool condition,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        bool condition,
        Result result
    ) => source.OnFail(() => OperateWhenExtensions.OperateWhen(condition, result), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result> predicate,
        Result result
    ) => source.OnFailOperateWhen(predicate().Success, result);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFailOperateWhen(predicate().Success, function, numOfTry);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result, Result> predicate,
        Result result
    ) => source.OnFailOperateWhen(predicate(source).Success, result);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Result<T> result
    ) => source.OnFail(() => source.OperateWhen(condition, result), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Result<T> result,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, result, numOfTry), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<Result> predicate,
        Result<T> result
    ) => source.OnFailOperateWhen(predicate().Success, result);
}