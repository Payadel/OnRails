using OnRails.Extensions.Try;

namespace OnRails.Extensions.ActionResult;

public static class ActionResultExtensions {
    public static ActionResultObject ReturnResult(this Result result) => new(result);

    public static ActionResultObject<T> ReturnResult<T>(this Result<T> result) => new(result);

    public static async Task<ActionResultObject> ReturnResult(this Task<Result> taskResult) {
        var result = await TryExtensions.Try(() => taskResult);
        return new ActionResultObject(result);
    }

    public static async Task<ActionResultObject<T>> ReturnResult<T>(this Task<Result<T>> taskResult) {
        var result = await TryExtensions.Try(() => taskResult);
        return new ActionResultObject<T>(result);
    }
}