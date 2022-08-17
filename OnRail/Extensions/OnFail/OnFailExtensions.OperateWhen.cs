using OnRail.Extensions.OperateWhen;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result OnFailOperateWhen(
        this Result @this,
        Func<bool> predicateFunc,
        Func<Result> function,
        int numOfTry = 1
    ) => @this.OnFail(() => OperateWhenExtensions.OperateWhen(predicateFunc, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        bool predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => @this.OnFail(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFunc,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicateFunc, function, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicate, function, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFunc,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicateFunc, function, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicate, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result, bool> predicateFunc,
        Func<Result> function,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicateFunc, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<bool> predicateFunc,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicateFunc, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        bool predicate,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicate, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result, bool> predicateFunc,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicateFunc, function, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        bool predicate,
        Result result
    ) => @this.OnFail(() => OperateWhenExtensions.OperateWhen(predicate, result));

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result> predicateFunc,
        Result result
    ) => @this.OnFailOperateWhen(predicateFunc().IsSuccess, result);

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result> predicateFunc,
        Func<Result> result
    ) => @this.OnFailOperateWhen(predicateFunc().IsSuccess, result);

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result, Result> predicate,
        Result result
    ) => @this.OnFailOperateWhen(predicate(@this).IsSuccess, result);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Result<T> result
    ) => @this.OnFail(() => @this.OperateWhen(predicate, result));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFunc,
        Result<T> result,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicateFunc, result, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicateFunc,
        Result<T> result
    ) => @this.OnFailOperateWhen(predicateFunc().IsSuccess, result);
}