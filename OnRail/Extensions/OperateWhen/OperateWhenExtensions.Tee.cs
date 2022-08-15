using OnRail.Extensions.Map;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Tee;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.OperateWhen;

public static partial class OperateWhenExtensions {
    //TODO: Test
    public static T TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Result> function,
        int numOfTry = 1) =>
        @this.Tee(() => OperateWhen(predicate, function, numOfTry));

    //TODO: Test
    public static T TeeOperateWhen<T>(
        this T @this,
        Result predicate,
        Func<Result> function,
        int numOfTry = 1) => @this.TeeOperateWhen(predicate.IsSuccess, function, numOfTry);

    //TODO: Test
    public static T TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Action action,
        int numOfTry = 1) => predicate ? @this.Tee(action, numOfTry) : @this;

    //TODO: Test
    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, bool> predicateFun,
        Action action,
        int numOfTry = 1) =>
        @this.Try(predicateFun, numOfTry)
            .OnSuccess(predicate => OperateWhen(predicate, action, numOfTry))
            .Map(@this);

    //TODO: Test
    public static T TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Action<T> action,
        int numOfTry = 1) => predicate ? @this.Tee(action, numOfTry) : @this;

    //TODO: Test
    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Action<T> action,
        int numOfTry = 1) => @this.TeeOperateWhen(predicate, () => action(@this), numOfTry);

    //TODO: Test
    public static T TeeOperateWhen<T>(
        this T @this,
        Result predicate,
        Action action,
        int numOfTry = 1) => @this.TeeOperateWhen(predicate.IsSuccess, action, numOfTry);

    //TODO: Test
    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Action action,
        int numOfTry = 1) => @this.TeeOperateWhen(t => predicate(t).IsSuccess, action, numOfTry);

    //TODO: Test
    public static T TeeOperateWhen<T>(
        this T @this,
        Result predicate,
        Action<T> action,
        int numOfTry = 1) => @this.TeeOperateWhen(predicate.IsSuccess, action, numOfTry);

    //TODO: Test
    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Action<T> action,
        int numOfTry = 1) => @this.TeeOperateWhen(t => predicate(t).IsSuccess, action, numOfTry);
}