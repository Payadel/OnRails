using OnRail.Extensions.OperateWhen;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test all methods

public static partial class OnSuccessExtensions {
    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<bool> predicateFun,
        Func<Result> function,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicateFun, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Action action,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Action<T> action,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicateFunc,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFunc, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicateFun,
        Action action,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicateFun,
        Action<T> action,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicateFunc,
        Func<T, Result<T>> function,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFunc, function, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<bool> predicateFun,
        Action action,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicateFun, action, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        bool condition,
        Func<Result> function,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        bool condition,
        Action action,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(condition, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool condition,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => @this.OperateWhen(condition, operation, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool condition,
        Action action,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(condition, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool condition,
        Action<T> action,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(condition, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool condition,
        Func<T, Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(condition, operation, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<Result> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => @this.OnSuccess(() => @this.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        Action action,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicate().IsSuccess, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        Action<T> action,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicate().IsSuccess, action, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Action operation,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Action<T> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        Func<T, Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Func<T, Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<Result> predicate,
        Action action,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, action, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Result predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Result predicate,
        Action operation,
        int numOfTry = 1
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate.IsSuccess, operation, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicate.IsSuccess, operation, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Action operation,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Action<T> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation, numOfTry));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Func<T, Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation, numOfTry));
}