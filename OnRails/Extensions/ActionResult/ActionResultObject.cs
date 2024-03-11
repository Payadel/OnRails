using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OnRails.Extensions.ActionResult;

[DebuggerStepThrough]
public class ActionResultObject : ObjectResult {
    public ActionResultObject(ResultBase result) : base(result) {
        StatusCode = result.GetStatusCodeOrDefault();
        Value = result.Success
            ? null
            : result.Detail?.GetViewModel();
    }
}

public class ActionResultObject<T> : ObjectResult {
    public ActionResultObject(Result<T> result) : base(result) {
        StatusCode = result.GetStatusCodeOrDefault();
        Value = result.Success
            ? result.Value
            : result.Detail?.GetViewModel();
    }
}