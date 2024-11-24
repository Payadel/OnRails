using OnRails.Extensions.OnSuccess;
using OnRails.ResultDetails.Success;

namespace OnRails.Extensions.ActionResult;

public static partial class ActionResultExtensions {
    public static Microsoft.AspNetCore.Mvc.ActionResult ResetContent(this Result result) =>
        result.OnSuccess(() => {
            if (result.Detail is not ResetContentDetail)
                result.Detail = new ResetContentDetail();

            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ResetContent(this Task<Result> source) =>
        source.OnSuccess(result => {
            if (result.Detail is not ResetContentDetail)
                result.Detail = new ResetContentDetail();

            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ResetContent<T>(this Result<T> result) =>
        result.OnSuccess(() => {
            if (result.Detail is ResetContentDetail detail)
                return Result.Ok(detail);
            return Result.Ok(new ResetContentDetail());
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ResetContent<T>(this Task<Result<T>> source) =>
        source.OnSuccess((_, result) => {
            if (result.Detail is ResetContentDetail detail)
                return Result.Ok(detail);
            return Result.Ok(new ResetContentDetail());
        }).ReturnResult();
}