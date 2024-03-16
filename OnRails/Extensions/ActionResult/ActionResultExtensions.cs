using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;
using OnRails.ResultDetails.Success;

namespace OnRails.Extensions.ActionResult;

[DebuggerStepThrough]
public static class ActionResultExtensions {
    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnResult(this Result result) {
        var value = result.GetViewValue();
        var actionResult = GenerateActionResult(result.Detail, value) ?? new ActionResultView(result);
        return actionResult;
    }
    
    public static async Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnResult(this Task<Result> taskResult) =>
        (await TryExtensions.Try(taskResult))
        .ReturnResult();

    public static ActionResult<T> ReturnResult<T>(this Result<T> result) {
        var value = result.GetViewValue();
        var actionResult = GenerateActionResult(result.Detail, value) ?? new ActionResultView<T>(result);
        return actionResult;
    }

    public static async Task<ActionResult<T>>
        ReturnResult<T>(this Task<Result<T>> taskResult) =>
        (await TryExtensions.Try(taskResult))
        .ReturnResult();
    
        private static Microsoft.AspNetCore.Mvc.ActionResult? GenerateActionResult(ResultDetail? detail, object? value) {
        if (detail is null) return null;

        if (detail is CreatedDetail createdDetail) {
            if (createdDetail.Location is not null)
                return new CreatedResult(createdDetail.Location, value);
            if (createdDetail.LocationUri is not null)
                return new CreatedResult(createdDetail.LocationUri, value);

            if (createdDetail.RouteName is not null)
                return new CreatedAtRouteResult(createdDetail.RouteName, createdDetail.RouteValues, value);
            if (createdDetail.RouteValues is not null && createdDetail.ActionName is null)
                return new CreatedAtRouteResult(createdDetail.RouteValues, value);

            if (createdDetail.ActionName is not null)
                return new CreatedAtActionResult(createdDetail.ActionName, createdDetail.ControllerName,
                    createdDetail.RouteValues, value);

            // If all parameters are null, we handle later.
        }

        if (detail is AcceptedDetail acceptedDetail) {
            if (acceptedDetail.Location is not null)
                return new AcceptedResult(acceptedDetail.Location, value);
            if (acceptedDetail.LocationUri is not null)
                return new AcceptedResult(acceptedDetail.LocationUri, value);

            if (acceptedDetail.RouteName is not null)
                return new AcceptedAtRouteResult(acceptedDetail.RouteName, acceptedDetail.RouteValues, value);
            if (acceptedDetail.RouteValues is not null && acceptedDetail.ActionName is null)
                return new AcceptedAtRouteResult(acceptedDetail.RouteValues, value);

            if (acceptedDetail.ActionName is not null)
                return new AcceptedAtActionResult(acceptedDetail.ActionName, acceptedDetail.ControllerName,
                    acceptedDetail.RouteValues, value);

            // If all parameters are null, we handle later.
        }

        return null;
    }
}