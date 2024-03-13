using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnRails.Extensions.ActionResult;

[DebuggerStepThrough]
public class ActionResultView : ObjectResult {
    public ActionResultView(ResultBase result) : base(result) {
        var hasDetailView = result.Detail is not null;
        var view = hasDetailView && result.Detail!.View;

        if (view) {
            // We have a detail data with view access
            Value = result.Detail!.GetViewModel();
            StatusCode = result.GetStatusCodeOrDefault(
                StatusCodes.Status204NoContent,
                StatusCodes.Status500InternalServerError);
        }
        else {
            // We have not detail data or have not access to show
            Value = null;
            StatusCode = result.Success
                ? StatusCodes.Status204NoContent
                : StatusCodes.Status500InternalServerError;
        }
    }
}

[DebuggerStepThrough]
public class ActionResultView<T> : ObjectResult {
    public ActionResultView(Result<T> result) : base(result) {
        var hasDetailView = result.Detail != null;
        var view = hasDetailView && result.Detail!.View;
        var hasValue = result.Value is not null;

        if (view) {
            // We have a detail data with view access
            Value = result.Success ? result.Value : result.Detail!.GetViewModel();
            StatusCode = result.GetStatusCodeOrDefault(
                hasValue ? StatusCodes.Status200OK : StatusCodes.Status204NoContent,
                StatusCodes.Status500InternalServerError);
        }
        else {
            // We have not detail data or have not access to show
            Value = result.Success ? result.Value : null;
        
            if (!result.Success)
                StatusCode = 500;
            else 
                StatusCode = hasValue ? 200 : 204;
        }
    }
}