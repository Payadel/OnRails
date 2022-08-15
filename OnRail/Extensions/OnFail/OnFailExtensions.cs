using OnRail.Extensions.Fail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.OnFail;

//TODO: Test

public static partial class OnFailExtensions {
    public static Result<T> OnFail<T>(
        this Result<T> @this,
        ErrorDetail errorDetail) =>
        @this.IsSuccess ? @this : @this.Fail(errorDetail);

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Func<ErrorDetail> errorDetailFunc,
        int numOfTry = 1) => @this.IsSuccess
        ? @this
        : TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(@this.Fail);

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        object moreDetail) {
        if (!@this.IsSuccess)
            @this.Detail.AddDetail(moreDetail);
        return @this;
    }

    public static Result OnFail(
        this Result @this,
        ErrorDetail errorDetail) =>
        @this.IsSuccess ? @this : @this.Fail(errorDetail);

    public static Result OnFail(
        this Result @this,
        Func<ErrorDetail> errorDetailFunc,
        int numOfTry = 1) => @this.IsSuccess
        ? @this
        : TryExtensions.Try(errorDetailFunc, numOfTry)
            .OnSuccess(@this.Fail);


    public static Result OnFail(
        this Result @this,
        object moreDetail) {
        if (!@this.IsSuccess)
            @this.Detail.AddDetail(moreDetail);
        return @this;
    }

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Func<Result<T>, Result<T>> fail,
        int numOfTry = 1) => @this.IsSuccess
        ? @this
        : @this.Try(fail, numOfTry);

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Func<Result<T>> fail,
        int numOfTry = 1) => @this.IsSuccess
        ? @this
        : TryExtensions.Try(fail, numOfTry);

    public static Result OnFail(
        this Result @this,
        Func<Result, Result> fail,
        int numOfTry = 1) => @this.IsSuccess
        ? @this
        : @this.Try(fail, numOfTry);

    public static Result OnFail(
        this Result @this,
        Func<Result> fail,
        int numOfTry = 1) => @this.IsSuccess
        ? @this
        : TryExtensions.Try(fail, numOfTry);

    public static Result OnFail(
        this Result @this,
        Action fail,
        int numOfTry = 1) {
        if (!@this.IsSuccess)
            TryExtensions.Try(fail, numOfTry);
        return @this;
    }

    public static Result OnFail(
        this Result @this,
        Action<Result> fail,
        int numOfTry = 1) {
        if (!@this.IsSuccess)
            @this.Try(fail, numOfTry);
        return @this;
    }

    public static Result<T> OnFail<T>(
        this Result<T> @this,
        Action<Result<T>> fail,
        int numOfTry = 1) {
        if (!@this.IsSuccess)
            @this.Try(fail, numOfTry);
        return @this;
    }
}