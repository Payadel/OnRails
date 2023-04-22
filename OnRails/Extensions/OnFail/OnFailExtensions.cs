using OnRails.Extensions.Try;

namespace OnRails.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1
    ) => source.Success
        ? source
        : source.Try(function, numOfTry);

    public static Result<T> OnFail<T>(
        this Result<T> source,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.Success
        ? source
        : TryExtensions.Try(function, numOfTry);

    public static Result OnFail(
        this Result source,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => source.Success
        ? source
        : source.Try(function, numOfTry);

    public static Result OnFail(
        this Result source,
        Func<Result> function,
        int numOfTry = 1
    ) => source.Success
        ? source
        : TryExtensions.Try(function, numOfTry);
}