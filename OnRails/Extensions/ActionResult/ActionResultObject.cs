using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnRails.Extensions.ActionResult;

public class ActionResultObject : ObjectResult {
    public ActionResultObject(ResultBase result) : base(result) {
        StatusCode =
            result.GetStatusCodeOrDefault(result.IsSuccess
                ? StatusCodes.Status200OK
                : StatusCodes.Status500InternalServerError);
        Value = result.IsSuccess
            ? null
            : result.Detail?.GetViewModel();
    }
}

public class ActionResultObject<T> : ObjectResult {
    public ActionResultObject(Result<T> result) : base(result) {
        StatusCode =
            result.GetStatusCodeOrDefault(result.IsSuccess
                ? StatusCodes.Status200OK
                : StatusCodes.Status500InternalServerError);
        Value = result.IsSuccess
            ? result.Value
            : result.Detail?.GetViewModel();
    }
}