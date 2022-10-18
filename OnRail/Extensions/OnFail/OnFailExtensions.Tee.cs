using OnRail.Extensions.Tee;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result<TSource> OnFailTee<TSource>(
        this Result<TSource> source, Action action, int numOfTry = 1) =>
        source.OnFail(result => result.Tee(action, numOfTry), numOfTry: 1);

    public static Result<TSource> OnFailTee<TSource>(
        this Result<TSource> source, Action<Result<TSource>> action, int numOfTry = 1) =>
        source.OnFail(result => result.Tee(action, numOfTry), numOfTry: 1);

    public static Result<TSource> OnFailTee<TSource, TResult>(
        this Result<TSource> source,
        Func<Result<TSource>, Result<TResult>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry), numOfTry: 1);

    public static Result<TSource> OnFailTee<TSource, TResult>(
        this Result<TSource> source,
        Func<Result<TResult>> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry), numOfTry: 1);

    public static Result<TSource> OnFailTee<TSource>(
        this Result<TSource> source,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry), numOfTry: 1);

    public static Result<T> OnFailTee<T>(
        this Result<T> source,
        Func<Task> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry), numOfTry: 1);

    public static Result<T> OnFailTee<T>(
        this Result<T> source,
        Func<Result<T>, Task> function,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(function, numOfTry), numOfTry: 1);

    public static Result OnFailTee(
        this Result source,
        Action action,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(action, numOfTry), numOfTry: 1);

    public static Result OnFailTee(
        this Result source,
        Action<Result> action,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(action, numOfTry), numOfTry: 1);

    public static Task<Result> OnFailTee(
        this Task<Result> source,
        Action action,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(action, numOfTry),
        numOfTry: 1);

    public static async Task<Result> OnFailTee(
        this Task<Result> source,
        Task task,
        int numOfTry = 1
    ) {
        var result = await TryExtensions.Try(source, numOfTry);
        return result.IsSuccess
            ? result
            : await TryExtensions.Try(task, numOfTry);
    }

    public static Task<Result> OnFailTee(
        this Task<Result> source,
        Action<Result> action,
        int numOfTry = 1
    ) => source.OnFail(result => result.Tee(action, numOfTry),
        numOfTry: 1);
}