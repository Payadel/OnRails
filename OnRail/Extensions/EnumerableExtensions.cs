using System.Collections;

namespace OnRail.Extensions;

public static class EnumerableExtensions {
    public static bool IsNullOrEmpty(
        this IEnumerable? @this) =>
        @this is null || !@this.GetEnumerator().MoveNext();

    // public static Result IsNotNullOrEmpty(
    //     this IEnumerable? @this,
    //     ErrorDetail? errorDetail = null,
    //     bool showDefaultMessageToUser = true) {
    //     var error = errorDetail ?? new ErrorDetail(StatusCodes.Status400BadRequest,
    //         title: "IsNullOrEmptyError",
    //         message: "object is not null or empty.",
    //         showDefaultMessageToUser: showDefaultMessageToUser);
    //     if (@this is null || @this.IsNullOrEmpty())
    //         return Result.Fail(error);
    //     return Result.Ok();
    // }
}