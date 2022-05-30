using OnRail.ResultDetails;

namespace OnRail.Extensions {
    public class ResultObject : ObjectResult {
        public ResultObject(ResultBase methodResult, bool isDevelopMode = false) :
            base(Extension.GetSuitableObject(methodResult.IsSuccess, null,
                methodResult.Detail, isDevelopMode)) {
            StatusCode = methodResult.Detail.StatusCode;
        }
    }

    public class ResultObject<T> : ObjectResult {
        public ResultObject(Result<T> methodResult, bool isDevelopMode = false) :
            base(Extension.GetSuitableObject(methodResult.IsSuccess, methodResult.Value,
                methodResult.Detail, isDevelopMode)) {
            StatusCode = methodResult.Detail.StatusCode;
        }
    }

    internal static class Extension {
        public static object? GetSuitableObject(bool isSuccess, object? value,
            ResultDetail detail, bool isDevelopMode) {
            if (isSuccess)
                return value;
            return !isDevelopMode
                ? (object) new {Result = detail.GetViewModel()}
                : new {Result = detail.GetViewModel(), AllDetails = detail};
        }
    }

    public static class ActionResultExtension {
        public static ResultObject ReturnResult(
            this Result methodResult, bool isDevelopMode = false) =>
            new ResultObject(methodResult, isDevelopMode);

        public static async Task<ResultObject> ReturnResultAsync(
            this Task<Result> methodResult, bool isDevelopMode = false) =>
            new ResultObject(await methodResult, isDevelopMode);

        public static ResultObject<T> ReturnResult<T>(
            this Result<T> methodResult, bool isDevelopMode = false) =>
            new ResultObject<T>(methodResult, isDevelopMode);

        public static async Task<ResultObject<T>> ReturnResultAsync<T>(
            this Task<Result<T>> methodResult, bool isDevelopMode = false) =>
            new ResultObject<T>(await methodResult, isDevelopMode);
    }
}