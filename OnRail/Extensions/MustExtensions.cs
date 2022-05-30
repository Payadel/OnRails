using OnRail.ResultDetails;

namespace OnRail.Extensions {
    public static class MustExtensions {
        public static Result<T> Must<T>(
            this T @this,
            bool predicate,
            ResultDetail errorDetail
        ) => @this.OperateWhen(!predicate,
            () => Result<T>.Fail(errorDetail));

        public static Result<T> Must<T>(
            this T @this,
            Func<bool> predicate,
            ResultDetail errorDetail
        ) => @this.OperateWhen(!predicate(),
            () => Result<T>.Fail(errorDetail));

        public static Result<T> Must<T>(
            this T @this,
            bool predicate,
            Func<ResultDetail> errorDetail
        ) => @this.OperateWhen(!predicate,
            () => Result<T>.Fail(errorDetail()));

        public static Result<T> Must<T>(
            this T @this,
            Func<bool> predicate,
            Func<ResultDetail> errorDetail
        ) => @this.OperateWhen(!predicate(),
            () => Result<T>.Fail(errorDetail()));
    }
}