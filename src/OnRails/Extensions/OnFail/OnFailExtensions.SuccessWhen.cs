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
        source.OnFailOperateWhen(predicate.Success, Result.Ok);

    public static Result OnFailSuccessWhen(
        this Result source, Func<Result, bool> predicate, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate, Result.Ok, numOfTry);

    public static Result OnFailSuccessWhen(
        this Result source, Func<Result> predicate) =>
        source.OnFailSuccessWhen(predicate().Success);

    public static Result OnFailSuccessWhen(
        this Result source, Func<Result, Result> predicate) =>
        source.OnFailSuccessWhen(predicate(source).Success);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, bool condition, T result) =>
        source.OnFailOperateWhen(condition, Result<T>.Ok(result));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, bool condition, Func<T> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(condition, () => Result<T>.Ok(function()), numOfTry);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Result predicate, T result) =>
        source.OnFailOperateWhen(predicate.Success, Result<T>.Ok(result));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Result predicate, Func<T> function, int numOfTry = 1) =>
        source.OnFailOperateWhen(predicate.Success, () => Result<T>.Ok(function()), numOfTry);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Func<bool> predicate, T result) =>
        source.OnFailOperateWhen(predicate, Result<T>.Ok(result));

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Func<Result> predicate, T result) =>
        source.OnFailSuccessWhen(predicate().Success, result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Func<Result<T>, Result> predicate, T result) =>
        source.OnFailSuccessWhen(predicate(source).Success, result);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Func<Result> predicate, Func<T> function, int numOfTry = 1) =>
        source.OnFailSuccessWhen(predicate().Success, function, numOfTry);

    public static Result<T> OnFailSuccessWhen<T>(
        this Result<T> source, Func<Result<T>, Result> predicate, Func<T> function, int numOfTry = 1) =>
        source.OnFailSuccessWhen(predicate(source).Success, function, numOfTry);
}