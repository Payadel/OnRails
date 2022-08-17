using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Func<Result<T>, Result<T>> onFailFunc,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? @this
        : @this.Try(onFailFunc, numOfTry);

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Func<Result<T>> onFailFunc,
        int numOfTry = 1) => @this.IsSuccess
        ? @this
        : TryExtensions.Try(onFailFunc, numOfTry);

    public static Result OnFail(
        this Result @this,
        Func<Result, Result> onFailFunc,
        int numOfTry = 1) => @this.IsSuccess
        ? @this
        : @this.Try(onFailFunc, numOfTry);

    public static Result OnFail(
        this Result @this,
        Func<Result> onFailFunc,
        int numOfTry = 1) => @this.IsSuccess
        ? @this
        : TryExtensions.Try(onFailFunc, numOfTry);

    public static Result OnFail(
        this Result @this,
        Action onFailFunc,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? @this
        : TryExtensions.Try(onFailFunc, numOfTry);

    public static Result OnFail(
        this Result @this,
        Action<Result> onFailAction,
        int numOfTry = 1) => @this.IsSuccess
        ? @this
        : @this.Try(onFailAction, numOfTry);
}