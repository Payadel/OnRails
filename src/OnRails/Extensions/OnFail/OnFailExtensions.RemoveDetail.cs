namespace OnRails.Extensions.OnFail;

public static partial class OnFailExtensions {
    public static Result OnFailRemoveDetail(this Result source) {
        return source.OnFail(result => {
            result.RemoveDetail();
            return result;
        });
    }

    public static Result<T> OnFailRemoveDetail<T>(this Result<T> source) {
        return source.OnFail(result => {
            result.RemoveDetail();
            return result;
        });
    }

    #region Async

    public static Task<Result> OnFailRemoveDetail(this Task<Result> source) {
        return source.OnFail(result => {
            result.RemoveDetail();
            return result;
        });
    }

    public static Task<Result<T>> OnFailRemoveDetail<T>(this Task<Result<T>> source) {
        return source.OnFail(result => {
            result.RemoveDetail();
            return result;
        });
    }

    #endregion
}