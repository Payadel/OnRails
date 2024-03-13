using System.Diagnostics;
using OnRails.Extensions.Try;

namespace OnRails.Extensions.ActionResult;

[DebuggerStepThrough]
public static class ActionResultExtensions {
    public static ActionResultView ReturnResult(this Result result) => new(result);

    public static ActionResultView<T> ReturnResult<T>(this Result<T> result) => new(result);

    public static async Task<ActionResultView> ReturnResult(this Task<Result> taskResult) {
        var result = await TryExtensions.Try(taskResult);
        return new ActionResultView(result);
    }

    public static async Task<ActionResultView<T>> ReturnResult<T>(this Task<Result<T>> taskResult) {
        var result = await TryExtensions.Try(taskResult);
        return new ActionResultView<T>(result);
    }
}