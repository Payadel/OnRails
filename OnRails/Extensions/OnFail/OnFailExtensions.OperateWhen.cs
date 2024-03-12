using OnRails.Extensions.OperateWhen;
using OnRails.ResultDetails;
using OnRails.ResultDetails.Errors;

namespace OnRails.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Result OnFailOperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => OperateWhenExtensions.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        bool condition,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => OperateWhenExtensions.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Func<Result<T>, Result<T>> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<bool> predicate,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        bool condition,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(condition, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result, bool> predicate,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, function, numOfTry), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        bool condition,
        Result result
    ) => source.OnFail(() => OperateWhenExtensions.OperateWhen(condition, result), numOfTry: 1);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result> predicate,
        Result result
    ) => source.OnFailOperateWhen(predicate().Success, result);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result> predicate,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFailOperateWhen(predicate().Success, function, numOfTry);

    public static Result OnFailOperateWhen(
        this Result source,
        Func<Result, Result> predicate,
        Result result
    ) => source.OnFailOperateWhen(predicate(source).Success, result);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        bool condition,
        Result<T> result
    ) => source.OnFail(() => source.OperateWhen(condition, result), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<bool> predicate,
        Result<T> result,
        int numOfTry = 1
    ) => source.OnFail(() => source.OperateWhen(predicate, result, numOfTry), numOfTry: 1);

    public static Result<T> OnFailOperateWhen<T>(
        this Result<T> source,
        Func<Result> predicate,
        Result<T> result
    ) => source.OnFailOperateWhen(predicate().Success, result);

    #region Condition base ErrorDetail or Exception type

    public static Result OnFailOperateWhen(
        this Result source,
        Type errorOrExceptionType,
        Result result
    ) => source.OnFail(() => {
        var errorDetail = (ErrorDetail)source.Detail!;

        if (errorOrExceptionType.IsAssignableTo(typeof(ErrorDetail)))
            return source.OperateWhen(source.IsDetailTypeOf(errorOrExceptionType), result);
        if (errorOrExceptionType.IsAssignableTo(typeof(Exception)))
            return source.OperateWhen(errorDetail.HasErrorTypeOf(errorOrExceptionType), result);

        return Result.Fail(new ValidationError(
            message:
            $"{errorOrExceptionType.Name} is not type of {nameof(ErrorDetail)} or {nameof(Exception)}."));
    });

    public static Result OnFailOperateWhen(
        this Result source,
        Type errorOrExceptionType,
        Func<Result> function,
        int numOfTry = 1
    ) => source.OnFail(() => {
        var errorDetail = (ErrorDetail)source.Detail!;

        if (errorOrExceptionType.IsAssignableTo(typeof(ErrorDetail)))
            return source.OperateWhen(source.IsDetailTypeOf(errorOrExceptionType), function, numOfTry);
        if (errorOrExceptionType.IsAssignableTo(typeof(Exception)))
            return source.OperateWhen(errorDetail.HasErrorTypeOf(errorOrExceptionType), function);

        return Result.Fail(new ValidationError(
            message:
            $"{errorOrExceptionType.Name} is not type of {nameof(ErrorDetail)} or {nameof(Exception)}."));
    });

    public static Result OnFailOperateWhen(
        this Result source,
        Type errorOrExceptionType,
        Func<Result, Result> function,
        int numOfTry = 1
    ) => source.OnFailOperateWhen(errorOrExceptionType, () => function(source), numOfTry);

    public static Result<TSource> OnFailOperateWhen<TSource>(
        this Result<TSource> source,
        Type errorOrExceptionType,
        Func<Result<TSource>> function,
        int numOfTry = 1
    ) => source.OnFail(() => {
        var errorDetail = (ErrorDetail)source.Detail!;

        if (errorOrExceptionType.IsAssignableTo(typeof(ErrorDetail)))
            return source.OperateWhen(source.IsDetailTypeOf(errorOrExceptionType), function, numOfTry);
        if (errorOrExceptionType.IsAssignableTo(typeof(Exception)))
            return source.OperateWhen(errorDetail.HasErrorTypeOf(errorOrExceptionType), function);

        return Result<TSource>.Fail(new ValidationError(
            message:
            $"{errorOrExceptionType.Name} is not type of {nameof(ErrorDetail)} or {nameof(Exception)}."));
    });

    public static Result<TSource> OnFailOperateWhen<TSource>(
        this Result<TSource> source,
        Type errorOrExceptionType,
        Func<Result<TSource>, Result<TSource>> function,
        int numOfTry = 1
    ) => source.OnFailOperateWhen(errorOrExceptionType, () => function(source), numOfTry);

    #endregion
}