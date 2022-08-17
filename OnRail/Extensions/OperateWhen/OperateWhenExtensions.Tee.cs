using OnRail.Extensions.Tee;

namespace OnRail.Extensions.OperateWhen;

//TODO: Test

public static partial class OperateWhenExtensions {
    public static T TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Result> function,
        int numOfTry = 1) =>
        @this.Tee(() => OperateWhen(predicate, function, numOfTry));

    public static T TeeOperateWhen<T>(
        this T @this,
        Result predicate,
        Func<Result> function,
        int numOfTry = 1) => @this.TeeOperateWhen(predicate.IsSuccess, function, numOfTry);

    public static T TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Action action,
        int numOfTry = 1) => @this.Tee(() => OperateWhen(predicate, action, numOfTry));

    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, bool> predicateFun,
        Action action,
        int numOfTry = 1) =>
        @this.Tee(() => OperateWhen(() => predicateFun(@this), action, numOfTry));

    public static T TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Action<T> action,
        int numOfTry = 1
    ) => @this.Tee(() => @this.OperateWhen(predicate, action, numOfTry));

    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Action<T> action,
        int numOfTry = 1) => @this.Tee(() => @this.OperateWhen(predicate, action, numOfTry));

    public static T TeeOperateWhen<T>(
        this T @this,
        Result predicate,
        Action action,
        int numOfTry = 1) => @this.TeeOperateWhen(predicate.IsSuccess, action, numOfTry);

    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Action action,
        int numOfTry = 1) => @this.TeeOperateWhen(t => predicate(t).IsSuccess, action, numOfTry);

    public static T TeeOperateWhen<T>(
        this T @this,
        Result predicate,
        Action<T> action,
        int numOfTry = 1) => @this.TeeOperateWhen(predicate.IsSuccess, action, numOfTry);

    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Action<T> action,
        int numOfTry = 1) => @this.TeeOperateWhen(t => predicate(t).IsSuccess, action, numOfTry);

    public static Result<T> TeeOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Action operation,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate, () => @this.Tee(operation, numOfTry));

    public static Result TeeOperateWhen(
        this Result _,
        bool predicate,
        Action operation,
        int numOfTry = 1
    ) => OperateWhen(predicate, () => TeeExtensions.Tee(operation, numOfTry));

    public static Result<T> TeeOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        Action operation,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate().IsSuccess, () => @this.Tee(operation, numOfTry));

    public static Result<T> TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Func<T, Result> function,
        int numOfTry = 1
    ) => @this.OperateWhen(predicate, () => @this.Tee(function, numOfTry));
}