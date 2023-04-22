using OnRails.Extensions.Tee;

namespace OnRails.Extensions.OperateWhen;

//TODO: Test

public static partial class OperateWhenExtensions {
    public static T TeeOperateWhen<T>(
        this T source,
        bool condition,
        Func<Result> function,
        int numOfTry = 1) =>
        source.Tee(() => OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static T TeeOperateWhen<T>(
        this T source,
        Result predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.TeeOperateWhen(predicate.IsSuccess, function, numOfTry);

    public static T TeeOperateWhen<T>(
        this T source,
        bool condition,
        Action action,
        int numOfTry = 1
    ) => source.Tee(() => OperateWhen(condition, action, numOfTry));

    public static T TeeOperateWhen<T>(
        this T source,
        Func<T, bool> predicateFun,
        Action action,
        int numOfTry = 1) =>
        source.Tee(() => OperateWhen(() => predicateFun(source), action, numOfTry), numOfTry: 1);

    public static T TeeOperateWhen<T>(
        this T source,
        bool condition,
        Action<T> action,
        int numOfTry = 1
    ) => source.Tee(() => source.OperateWhen(condition, action, numOfTry), numOfTry: 1);

    public static T TeeOperateWhen<T>(
        this T source,
        Func<T, bool> predicate,
        Action<T> action,
        int numOfTry = 1
    ) => source.Tee(() => source.OperateWhen(predicate, action, numOfTry), numOfTry: 1);

    public static T TeeOperateWhen<T>(
        this T source,
        Result predicate,
        Action action,
        int numOfTry = 1
    ) => source.TeeOperateWhen(predicate.IsSuccess, action, numOfTry);

    public static T TeeOperateWhen<T>(
        this T source,
        Func<T, Result> predicate,
        Action action,
        int numOfTry = 1
    ) => source.TeeOperateWhen(t => predicate(t).IsSuccess, action, numOfTry);

    public static T TeeOperateWhen<T>(
        this T source,
        Result predicate,
        Action<T> action,
        int numOfTry = 1
    ) => source.TeeOperateWhen(predicate.IsSuccess, action, numOfTry);

    public static T TeeOperateWhen<T>(
        this T source,
        Func<T, Result> predicate,
        Action<T> action,
        int numOfTry = 1
    ) => source.TeeOperateWhen(t => predicate(t).IsSuccess, action, numOfTry);

    public static Result<T> TeeOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Action action,
        int numOfTry = 1
    ) => source.OperateWhen(condition, () => source.Tee(action, numOfTry), numOfTry: 1);

    public static Result TeeOperateWhen(
        this Result _,
        bool condition,
        Action action,
        int numOfTry = 1
    ) => OperateWhen(condition, () => TeeExtensions.Tee(action, numOfTry), numOfTry: 1);

    public static Result<T> TeeOperateWhen<T>(
        this Result<T> source,
        Func<Result> predicate,
        Action action,
        int numOfTry = 1
    ) => source.OperateWhen(predicate().IsSuccess, () => source.Tee(action, numOfTry), numOfTry: 1);

    public static Result<T> TeeOperateWhen<T>(
        this T source,
        bool condition,
        Func<T, Result> function,
        int numOfTry = 1
    ) => source.OperateWhen(condition, () => source.Tee(function, numOfTry), numOfTry: 1);
}