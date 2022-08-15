using OnRail.Extensions.OperateWhen;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result OnFailOperateWhen(
        this Result @this,
        Func<bool> predicateFunc,
        Func<Result> operation,
        int numOfTry = 1
    ) => @this.OnFail(() => OperateWhenExtensions.OperateWhen(predicateFunc, operation, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        bool predicate,
        Func<Result> operation,
        int numOfTry = 1
    ) => @this.OnFail(() => OperateWhenExtensions.OperateWhen(predicate, operation, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFunc,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicateFunc, operation, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicate, operation, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<bool> predicateFunc,
        Func<Result<T>, Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicateFunc, operation, numOfTry));

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Func<Result<T>, Result<T>> operation,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicate, operation, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result, bool> predicate,
        Func<Result> operation,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicate, operation, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<bool> predicateFunc,
        Func<Result, Result> operation,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicateFunc, operation, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        bool predicate,
        Func<Result, Result> operation,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicate, operation, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result, bool> predicate,
        Func<Result, Result> operation,
        int numOfTry = 1
    ) => @this.OnFail(() => @this.OperateWhen(predicate, operation, numOfTry));

    public static Result OnFailOperateWhen(
        this Result @this,
        bool predicate,
        Result result
    ) => @this.OnFail(() => predicate ? result : @this);

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result> predicate,
        Result result
    ) => @this.OnFailOperateWhen(predicate().IsSuccess, result);

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result> predicate,
        Func<Result> result
    ) => @this.OnFailOperateWhen(predicate().IsSuccess, result);

    public static Result OnFailOperateWhen(
        this Result @this,
        Func<Result, Result> predicate,
        Result result
    ) => @this.OnFailOperateWhen(predicate(@this).IsSuccess, result);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        bool predicate,
        Result<T> result
    ) => @this.OnFail(() => predicate ? result : @this);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> @this,
        Func<Result> predicate,
        Result<T> result
    ) => @this.OnFailOperateWhen(predicate().IsSuccess, result);
}