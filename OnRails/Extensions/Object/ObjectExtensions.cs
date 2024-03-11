using System.Collections;
using System.Diagnostics;
using OnRails.Extensions.Must;
using OnRails.Extensions.OnFail;
using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails.Extensions.Object;

[DebuggerStepThrough]
public static class ObjectExtensions {
    //TODO: Remove
    [Obsolete("This method will remove in next version.")]
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