namespace OnRail.Extensions;

public static class ObjectExtensions {
    // public static Result<T> IsNotNull<T>(
    //     this object? @this,
    //     ErrorDetail? errorDetail = null,
    //     bool showDefaultMessageToUser = true) =>
    //     @this.FailWhen(@this is null, errorDetail ?? new ErrorDetail(
    //             StatusCodes.Status400BadRequest, title: "NullError",
    //             message: "Object is null.", showDefaultMessageToUser: showDefaultMessageToUser))
    //         .MapResult((T) @this!);
    //
    // public static Result<TResult> As<TResult>(
    //     this object @this,
    //     ErrorDetail? errorDetail = null,
    //     bool showDefaultMessageToUser = true) =>
    //     TryExtensions.Try(() => Convert.ChangeType(@this, typeof(TResult)))
    //         .OnSuccess(obj => obj.IsNotNull<TResult>())
    //         .OnFail(() =>
    //             Result<TResult>.Fail(errorDetail ??
    //                                  new ErrorDetail(StatusCodes.Status400BadRequest,
    //                                      message:
    //                                      $"({@this} - Type of ({@this.GetType()})) is not {typeof(TResult)}",
    //                                      showDefaultMessageToUser: showDefaultMessageToUser)));
    //
    // public static Result AreNull(
    //     this IEnumerable<object?> @this,
    //     bool showDefaultMessageToUser = true) =>
    //     @this.ForEachUntilIsSuccess(obj =>
    //         FailExtensions.FailWhen(obj != null, new ErrorDetail(
    //             StatusCodes.Status400BadRequest, message: $"{obj} is not null.",
    //             showDefaultMessageToUser: showDefaultMessageToUser))
    //     );
}