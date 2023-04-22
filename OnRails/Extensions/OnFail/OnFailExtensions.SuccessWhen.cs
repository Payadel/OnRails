namespace OnRails.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Result OnFailSuccessWhen(
        this Result source, bool condition) =>
        source.OnFailOperateWhen(condition, Result.Ok);

    public static Result OnFailSuccessWhen(
        this Result source, Func<bool> predicate, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, Result.Ok, numOfTry);

    public static Result OnFailSuccessWhen(
        this Result source, Result predicate) =>
        source.OnFailOperateWhen(predicate.IsSuccess, Result.Ok);

    public static Result OnFailSuccessWhen(
        this Result source, Func<Result, bool> predicate, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, Result.Ok, numOfTry);

    public static Result OnFailSuccessWhen(
        this Result source, Func<Result> predicate) =>
        source.OnFailSuccessWhen(predicate().IsSuccess);

    public static Result OnFailSuccessWhen(
        this Result source, Func<Result, Result> predicate) =>
        source.OnFailSuccessWhen(predicate(source).IsSuccess);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, bool condition, T result) =>
        source.OnFailOperateWhen(condition, Result<T>.Ok(result));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, bool condition, Func<T> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(condition, () => Result<T>.Ok(function()), numOfTry);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Result predicate, T result) =>
        source.OnFailOperateWhen(predicate.IsSuccess, Result<T>.Ok(result));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Result predicate, Func<T> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate.IsSuccess, () => Result<T>.Ok(function()), numOfTry);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Func<bool> predicate, T result) =>
        source.OnFailOperateWhen(predicate, Result<T>.Ok(result));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Func<Result> predicate, T result) =>
        source.OnFailSuccessWhen(predicate().IsSuccess, result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Func<Result<T>, Result> predicate, T result) =>
        source.OnFailSuccessWhen(predicate(source).IsSuccess, result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Func<Result> predicate, Func<T> function, int numOfTry = 1) =>
        source.OnFailSuccessWhen(predicate().IsSuccess, function, numOfTry);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Func<Result<T>, Result> predicate, Func<T> function, int numOfTry = 1) =>
        source.OnFailSuccessWhen(predicate(source).IsSuccess, function, numOfTry);
}