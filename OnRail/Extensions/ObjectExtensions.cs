using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions;

public static class ObjectExtensions {
    public static Result<T> IsNotNull<T>(
        this object? @this,
        ErrorDetail? errorDetail = null) =>
        @this.FailWhen(@this is null, errorDetail ?? new ErrorDetail(
                title: "NullError", message: "Object is null."))
            .MapResult((T) @this!);

    public static Result<TResult> As<TResult>(
        this object @this,
        ErrorDetail? errorDetail = null) =>
        TryExtensions.Try(() => Convert.ChangeType(@this, typeof(TResult)))
            .OnSuccess(obj => obj.IsNotNull<TResult>())
            .OnFail(() =>
                Result<TResult>.Fail(errorDetail ?? new ErrorDetail(
                    message: $"({@this} - Type of ({@this.GetType()})) is not {typeof(TResult)}")));

    public static Result AreNull(
        this IEnumerable<object?> @this) =>
        @this.ForEachUntilIsSuccess(obj =>
            FailExtensions.FailWhen(obj != null, new ErrorDetail(
                message: $"{obj} is not null.")
            ));
}