using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OnRails.Extensions.ActionResult;

[DebuggerStepThrough]
public class ActionResultView : ObjectResult {
    public ActionResultView(Result result) : base(result) {
        StatusCode = result.GetViewStatusCode();
        Value = result.GetViewValue();
    }
}

[DebuggerStepThrough]
public class ActionResultView<T> : ObjectResult {
    public ActionResultView(Result<T> result) : base(result) {
        StatusCode = result.GetViewStatusCode();
        Value = result.GetViewValue();
    }
}