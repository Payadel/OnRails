using System.Collections;
using OnRail.Extensions.Must;
using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.Object;

//TODO: Test

public static class ObjectExtensions {
    public static bool IsNullOrEmpty(
        this IEnumerable? source) =>
        source is null || !source.GetEnumerator().MoveNext();

    public static Result<TResult> As<TResult>(
        this object source,
        ErrorDetail? errorDetail = null
    ) => TryExtensions.Try(() => Convert.ChangeType(source, typeof(TResult)))
        .OnSuccess(obj => obj.MustNotNull<TResult>())
        .OnFail(() => Result<TResult>.Fail(errorDetail ?? new ErrorDetail(
            message: $"({source} - Type of ({source.GetType()})) is not {typeof(TResult)}")));
}