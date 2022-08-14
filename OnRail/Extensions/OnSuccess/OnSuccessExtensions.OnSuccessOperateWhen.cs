using OnRail.Extensions.OperateWhen;

namespace OnRail.Extensions.OnSuccess;

//TODO: Test all methods

public static partial class OnSuccessExtensions {
    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<bool> predicateFun,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<Result<T>> operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Action action
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Action<T> action
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(value => @this.OperateWhen(predicate(value), operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicateFun,
        Action action
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicateFun,
        Action<T> action
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFun,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, bool> predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => @this.OperateWhen(
        predicate(value), () => operation(value)));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<bool> predicateFun,
        Action action
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicateFun, action));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        bool predicate,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        bool predicate,
        Action action
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(() => @this.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Action action
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Action<T> action
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => @this.OperateWhen(predicate, () => operation(value)));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<Result> predicateFun,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFun,
        Func<Result<T>> operation
    ) => @this.OnSuccess(() => @this.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFun,
        Action action
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun(), action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFun,
        Action<T> action
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun(), action));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Action operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Action<T> operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFun,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicateFun, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Func<T, Result> predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => @this.OperateWhen(
        predicate(value), () => operation(value)));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Func<Result> predicateFun,
        Action action
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicateFun, action));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Result predicate,
        Func<Result> operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate, operation));

    public static Result OnSuccessOperateWhen(
        this Result @this,
        Result predicate,
        Action operation
    ) => @this.OnSuccess(() => OperateWhenExtensions.OperateWhen(predicate.IsSuccess, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Func<Result<T>> operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicate.IsSuccess, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Action operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Action<T> operation
    ) => @this.OnSuccess(value => value.OperateWhen(predicate, operation));

    public static Result<T> OnSuccessOperateWhen<T>(
        this Result<T> @this,
        Result predicate,
        Func<T, Result<T>> operation
    ) => @this.OnSuccess(value => @this.OperateWhen(predicate, () => operation(value)));
}