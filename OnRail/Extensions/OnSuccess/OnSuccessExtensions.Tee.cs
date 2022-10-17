using OnRail.Extensions.Tee;

namespace OnRail.Extensions.OnSuccess;

public static partial class OnSuccessExtensions {
    public static Result<T> OnSuccessTee<T>(
        this Result<T> source,
        Action<T> action,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.Value!.Tee(action, numOfTry));

    public static Result<T> OnSuccessTee<T>(
        this Result<T> source,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.Tee(action, numOfTry));

    public static Result OnSuccessTee(
        this Result source,
        Action action,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.Tee(action, numOfTry));

    public static Result<TSource> OnSuccessTee<TSource, TResult>(
        this Result<TSource> source,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.Value!.Tee(function, numOfTry));

    public static Result<TSource> OnSuccessTee<TSource, TResult>(
        this Result<TSource> source,
        Func<TResult> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.Tee(function, numOfTry));

    public static Result OnSuccessTee<TResult>(
        this Result source,
        Func<TResult> function,
        int numOfTry = 1
    ) => source.OnSuccess(() => source.Tee(function, numOfTry));
}