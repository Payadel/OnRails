namespace OnRail.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> source, bool condition) =>
        source.OnFailOperateWhen(condition, Result.Ok());

    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> source, Result predicate) =>
        source.OnFailOperateWhen(predicate.IsSuccess, Result.Ok());

    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> source, Func<bool> predicate, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, Result.Ok(), numOfTry);

    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> source, Func<Result, bool> predicate, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, Result.Ok(), numOfTry);

    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> source, Func<Result> predicate) =>
        source.OnFailSuccessWhen(predicate().IsSuccess);

    public static Task<Result> OnFailSuccessWhen(
        this Task<Result> source, Func<Result, Result> predicate, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, Result.Ok(), numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, bool condition, T result) =>
        source.OnFailOperateWhen(condition, Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, bool condition, Func<T> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(condition, function, numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, bool condition, Func<Task<T>> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(condition, function, numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Result predicate, T result) =>
        source.OnFailOperateWhen(predicate.IsSuccess, Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Result predicate, Func<T> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate.IsSuccess, function, numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Result predicate, Func<Task<T>> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate.IsSuccess, function, numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Func<bool> predicate, T result, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, Result<T>.Ok(result), numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Func<Result<T>, bool> predicate, T result) =>
        source.OnFailOperateWhen(predicate, Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Func<bool> predicate, Func<T> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, function, numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Func<Result<T>, bool> predicate, Func<T> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, function, numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Func<bool> predicate, Func<Task<T>> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, function, numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Func<Result<T>, bool> predicate, Func<Task<T>> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, function, numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Func<Result> predicate, T result) =>
        source.OnFailOperateWhen(predicate().IsSuccess, () => Result<T>.Ok(result));

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Func<Result<T>, Result> predicate, T result, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, Result<T>.Ok(result), numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Func<Result> predicate, Func<T> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate().IsSuccess, function, numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Func<Result<T>, Result> predicate, Func<T> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, function, numOfTry);

    public static Task<Result<T>> OnFailSuccessWhen<T>(
        this Task<Result<T>> source, Func<Result> predicate, Func<Task<T>> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate().IsSuccess, function, numOfTry);
}