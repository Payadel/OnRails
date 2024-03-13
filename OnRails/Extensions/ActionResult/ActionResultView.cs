using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OnRails.Extensions.ActionResult;

[DebuggerStepThrough]
public class ActionResultView : ObjectResult {
    public ActionResultView(ResultBase result) : base(result) {
        var hasDetailView = result.Detail != null;
        var view = hasDetailView && result.Detail!.View;

        StatusCode = view ? result.GetStatusCodeOrDefault() : result.Success ? 200 : 500;
        Value = view ? result.Detail!.GetViewModel() : null;
    }
}

[DebuggerStepThrough]
public class ActionResultView<T> : ObjectResult {
    public ActionResultView(Result<T> result) : base(result) {
        var hasDetailView = result.Detail != null;
        var view = hasDetailView && result.Detail!.View;

        StatusCode = view ? result.GetStatusCodeOrDefault() : result.Success ? 200 : 500;

        Value = result.Success ? result.Value : null;
        if (Value is null && view)
            Value = result.Detail!.GetViewModel();
    }
}