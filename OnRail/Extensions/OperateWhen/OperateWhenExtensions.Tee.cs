using OnRail.Extensions.Tee;

namespace OnRail.Extensions.OperateWhen;

public static partial class OperateWhenExtensions {
    public static Result<T> TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Func<Result> function
    ) => predicate ? function().MapResult(@this) : Result<T>.Ok(@this);

    public static Result<T> TeeOperateWhen<T>(
        this T @this,
        Result predicate,
        Func<Result> function
    ) => @this.TeeOperateWhen(predicate.IsSuccess, function);

    public static T TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Action action
    ) => predicate ? @this.Tee(action) : @this;

    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Action action
    ) => @this.TeeOperateWhen(predicate(@this), action);

    public static T TeeOperateWhen<T>(
        this T @this,
        bool predicate,
        Action<T> action
    ) => predicate ? @this.Tee(action) : @this;

    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, bool> predicate,
        Action<T> action
    ) => @this.TeeOperateWhen(predicate(@this), action);

    public static T TeeOperateWhen<T>(
        this T @this,
        Result predicate,
        Action action
    ) => @this.TeeOperateWhen(predicate.IsSuccess, action);

    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Action action
    ) => @this.TeeOperateWhen(predicate(@this).IsSuccess, action);

    public static T TeeOperateWhen<T>(
        this T @this,
        Result predicate,
        Action<T> action
    ) => @this.TeeOperateWhen(predicate.IsSuccess, action);

    public static T TeeOperateWhen<T>(
        this T @this,
        Func<T, Result> predicate,
        Action<T> action
    ) => @this.TeeOperateWhen(predicate(@this).IsSuccess, action);
}