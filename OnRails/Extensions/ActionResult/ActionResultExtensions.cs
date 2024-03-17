using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;
using OnRails.ResultDetails.Success.Accepted;
using OnRails.ResultDetails.Success.Created;

namespace OnRails.Extensions.ActionResult;

[DebuggerStepThrough]
public static partial class ActionResultExtensions {
    #region Result

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnResult(this Result result) {
        var value = result.GetViewValue();
        var actionResult = GenerateActionResult(result.Detail, value) ?? new ActionResultView(result);
        return actionResult;
    }

    public static async Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnResult(this Task<Result> taskResult) =>
        (await TryExtensions.Try(taskResult))
        .ReturnResult();

    #endregion

    #region Result<T>

    public static ActionResult<T> ReturnResult<T>(this Result<T> result) {
        var value = result.GetViewValue();
        var actionResult = GenerateActionResult(result.Detail, value) ?? new ActionResultView<T>(result);
        return actionResult;
    }

    public static async Task<ActionResult<T>>
        ReturnResult<T>(this Task<Result<T>> taskResult) =>
        (await TryExtensions.Try(taskResult))
        .ReturnResult();

    #endregion

    private static Microsoft.AspNetCore.Mvc.ActionResult? GenerateActionResult(ResultDetail? detail, object? value) {
        switch (detail) {
            case CreatedDetail: {
                if (detail is CreatedAtLocationDetail createdAtLocationDetail) {
                    if (createdAtLocationDetail.Location is not null)
                        return new CreatedResult(createdAtLocationDetail.Location, value);
                    if (createdAtLocationDetail.LocationUri is not null) {
                        return new CreatedResult(createdAtLocationDetail.LocationUri, value);
                    }
                }

                if (detail is CreatedAtRouteDetail createdAtRouteDetail) {
                    return createdAtRouteDetail.RouteName is not null
                        ? new CreatedAtRouteResult(createdAtRouteDetail.RouteName, createdAtRouteDetail.RouteValues,
                            value)
                        : new CreatedAtRouteResult(createdAtRouteDetail.RouteValues, value);
                }

                if (detail is CreatedAtActionDetail createdAtAction) {
                    return new CreatedAtActionResult(createdAtAction.ActionName, createdAtAction.ControllerName,
                        createdAtAction.RouteValues, value);
                }

                break;
            }
            case AcceptedDetail: {
                if (detail is AcceptedAtLocationDetail acceptedAtLocationDetail) {
                    if (acceptedAtLocationDetail.Location is not null)
                        return new AcceptedResult(acceptedAtLocationDetail.Location, value);
                    if (acceptedAtLocationDetail.LocationUri is not null) {
                        return new AcceptedResult(acceptedAtLocationDetail.LocationUri, value);
                    }
                }

                if (detail is AcceptedAtRouteDetail acceptedAtRouteDetail) {
                    return acceptedAtRouteDetail.RouteName is not null
                        ? new AcceptedAtRouteResult(acceptedAtRouteDetail.RouteName, acceptedAtRouteDetail.RouteValues,
                            value)
                        : new AcceptedAtRouteResult(acceptedAtRouteDetail.RouteValues, value);
                }

                if (detail is AcceptedAtActionDetail acceptedAtAction) {
                    return new AcceptedAtActionResult(acceptedAtAction.ActionName, acceptedAtAction.ControllerName,
                        acceptedAtAction.RouteValues, value);
                }

                break;
            }
        }

        return null;
    }
}