using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OnRails.Extensions.ActionResult;

[DebuggerStepThrough]
public class ActionResultObject : ObjectResult {
    public ActionResultObject(ResultBase result) : base(result) {
        var hasDetailView = result.Detail != null;
        var view = hasDetailView && result.Detail!.View;

        StatusCode = view ? result.GetStatusCodeOrDefault() : result.Success ? 200 : 500;
        Value = view ? result.Detail!.GetViewModel() : null;
    }
}

public class ActionResultObject<T> : ObjectResult {
    public ActionResultObject(Result<T> result) : base(result) {
        var hasDetailView = result.Detail != null;
        var view = hasDetailView && result.Detail!.View;

        StatusCode = view ? result.GetStatusCodeOrDefault() : result.Success ? 200 : 500;

        Value = result.Success ? result.Value : null;
        if (Value is null && view)
            Value = result.Detail!.GetViewModel();
    }
}