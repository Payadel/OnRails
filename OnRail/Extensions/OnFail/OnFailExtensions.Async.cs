using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> @this,
        Func<Task<Result<TSource>>> onFailFunc,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        if (!result.IsSuccess)
            return await TryExtensions.Try(onFailFunc, numOfTry);

        return result;
    }

    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>, Result<TSource>> onFailFunc,
        int numOfTry = 1) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? result.Try(onFailFunc, numOfTry)
            : result;
    }

    public static async Task<Result<TSource>> OnFail<TSource>(
        this Task<Result<TSource>> @this,
        Func<Result<TSource>> onFailFunc,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? TryExtensions.Try(onFailFunc, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Func<Task<Result>> onFailFunc,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? await TryExtensions.Try(onFailFunc, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Func<Result, Task<Result>> onFailFunc,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? await @this.Try(onFailFunc, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Func<Result, Result> onFailFunc,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? result.Try(onFailFunc, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Func<Result> onFailFunc,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return !result.IsSuccess
            ? TryExtensions.Try(onFailFunc, numOfTry)
            : result;
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Action onFailAction,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? result
            : TryExtensions.Try(onFailAction, numOfTry);
    }

    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Task task,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        return result.IsSuccess
            ? result
            : await TryExtensions.Try(task, numOfTry);
    }

    //TODO: https://github.com/Payadel/OnRail/issues/9
    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> @this,
        Action onFailAction,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        if (!result.IsSuccess)
            TryExtensions.Try(onFailAction, numOfTry);

        return result;
    }

    //TODO: https://github.com/Payadel/OnRail/issues/9
    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> @this,
        Func<Task> onFailFunc,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        if (!result.IsSuccess)
            await TryExtensions.Try(onFailFunc, numOfTry);

        return result;
    }

    //TODO: https://github.com/Payadel/OnRail/issues/9
    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> @this,
        Func<Result<T>, Task<Result<T>>> onFailFunc,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(@this, numOfTry);
        if (!result.IsSuccess)
            await @this.Try(onFailFunc, numOfTry);

        return result;
    }

    public static async Task<Result<T>> OnFail<T>(
        this Result<T> @this,
        Func<Result<T>, Task<Result<T>>> onFailFunc,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? @this
        : await @this.Try(onFailFunc, numOfTry);

    public static async Task<Result<T>> OnFail<T>(
        this Result<T> @this,
        Func<Task<Result<T>>> onFailFunc,
        int numOfTry = 1) =>
        @this.IsSuccess ? @this : await TryExtensions.Try(onFailFunc, numOfTry);

    public static async Task<Result> OnFail(
        this Result @this,
        Func<Result, Task<Result>> onFailFunc,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? @this
        : await @this.Try(onFailFunc, numOfTry);

    public static async Task<Result> OnFail(
        this Result @this,
        Func<Task<Result>> onFailFunc,
        int numOfTry = 1
    ) => @this.IsSuccess
        ? @this
        : await TryExtensions.Try(onFailFunc, numOfTry);

    //TODO: https://github.com/Payadel/OnRail/issues/9
    public static async Task<Result> OnFail(
        this Task<Result> @this,
        Action<Result> onFailAction,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            await @this.Try(onFailAction, numOfTry);
        return methodResult;
    }

    //TODO: https://github.com/Payadel/OnRail/issues/9
    public static async Task<Result<T>> OnFail<T>(
        this Task<Result<T>> @this,
        Action<Result<T>> onFailAction,
        int numOfTry = 1) {
        var methodResult = await @this;
        if (!methodResult.IsSuccess)
            await @this.Try(onFailAction, numOfTry);
        return methodResult;
    }
}