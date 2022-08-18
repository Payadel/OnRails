using OnRail.Extensions.OperateWhen;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test all methods

public static partial class OnSuccessExtensions {
    public static Result OnSuccessOperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<T, bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<T, bool> predicate,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<T, bool> predicate,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<T, bool> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, function, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result source,
        Func<bool> predicate,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, action, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result source,
        bool condition,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result source,
        bool condition,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(condition, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.OperateWhen(condition, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(condition, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(condition, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(condition, function, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result source,
        Func<Result> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<Result> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<Result> predicate,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate().IsSuccess, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<Result> predicate,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate().IsSuccess, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<T, Result> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<T, Result> predicate,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<T, Result> predicate,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<Result> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Func<T, Result> predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, function, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result source,
        Func<Result> predicate,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, action, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result source,
        Result predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result source,
        Result predicate,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate.IsSuccess, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Result predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate.IsSuccess, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Result predicate,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Result predicate,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> source,
        Result predicate,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => source.OnSuccess(value => value.OperateWhen(predicate, function, numOfTry));
}