using OnRail.Extensions.OperateWhen;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result OnFailOperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result source,
        bool condition,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(condition, function, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(condition, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result source,
        bool condition,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(condition, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result source,
        bool condition,
        Result result
    ) => source.OnFail(() => OperateWhenExtensions.OperateWhen(condition, result));

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result> predicate,
        Result result
    ) => source.OnFailOperateWhen(predicate().IsSuccess, result);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result> predicate,
        Func<Result> function
    ) => source.OnFailOperateWhen(predicate().IsSuccess, function);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result, Result> predicate,
        Result result
    ) => source.OnFailOperateWhen(predicate(source).IsSuccess, result);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Result<T> result
    ) => source.OnFail(() => source.OperateWhen(condition, result));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Result<T> result,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, result, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<Result> predicate,
        Result<T> result
    ) => source.OnFailOperateWhen(predicate().IsSuccess, result);
}