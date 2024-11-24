using OnRails.Extensions.OnSuccess;
using OnRails.ResultDetails.Success;

namespace OnRails.Extensions.ActionResult;

public static partial class ActionResultExtensions {
    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnNoContent(this Result result) =>
        result.OnSuccess(() => {
            if (result.Detail is not NoContentDetail)
                result.Detail = new NoContentDetail();

            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnNoContent(this Task<Result> source) =>
        source.OnSuccess(result => {
            if (result.Detail is not NoContentDetail)
                result.Detail = new NoContentDetail();

            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnNoContent<T>(this Result<T> result) =>
        result.OnSuccess(() => {
            if (result.Detail is NoContentDetail detail)
                return Result.Ok(detail);
            return Result.Ok(new NoContentDetail());
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnNoContent<T>(this Task<Result<T>> source) =>
        source.OnSuccess((_, result) => {
            if (result.Detail is NoContentDetail detail)
                return Result.Ok(detail);
            return Result.Ok(new NoContentDetail());
        }).ReturnResult();
}