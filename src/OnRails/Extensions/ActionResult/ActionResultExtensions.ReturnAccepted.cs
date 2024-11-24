using OnRails.Extensions.OnSuccess;
using OnRails.ResultDetails.Success.Accepted;

namespace OnRails.Extensions.ActionResult;

public static partial class ActionResultExtensions {
    #region Result

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAccepted(this Result result) =>
        result.OnSuccess(() => {
            if (result.Detail is not AcceptedDetail)
                result.Detail = new AcceptedDetail();

            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtLocation(this Result result, string location) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtLocation(this Result result, Uri location) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtRoute(
        this Result result, object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedAtRouteDetail(routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtRoute(this Result result, string routeName,
        object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedAtRouteDetail(routeName, routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtAction(
        this Result result,
        string actionName,
        string controllerName,
        object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedAtActionDetail(actionName, controllerName, routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtAction(
        this Result result,
        string actionName) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedAtActionDetail(actionName);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtAction(
        this Result result,
        string actionName,
        string controllerName) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedAtActionDetail(actionName, controllerName);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtAction(
        this Result result,
        string actionName,
        object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedAtActionDetail(actionName, routeValues);
            return result;
        }).ReturnResult();

    #endregion

    #region Result<T>

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAccepted<T>(this Result<T> result) =>
        result.OnSuccess(() => {
            if (result.Detail is AcceptedDetail acceptedDetail)
                return Result.Ok(acceptedDetail);
            return Result.Ok(new AcceptedDetail());
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtLocation<T>(this Result<T> result,
        string location) =>
        result.OnSuccess(() => Result.Ok(new AcceptedAtLocationDetail(location)))
            .ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult
        ReturnAcceptedAtLocation<T>(this Result<T> result, Uri location) =>
        result.OnSuccess(() => Result.Ok(new AcceptedAtLocationDetail(location)))
            .ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtRoute<T>(
        this Result<T> result, object routeValues) =>
        result.OnSuccess(() => Result.Ok(new AcceptedAtRouteDetail(routeValues)))
            .ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtRoute<T>(
        this Result<T> result, Func<T, object> routeValuesFunc) =>
        result.OnSuccess(value => Result.Ok(new AcceptedAtRouteDetail(routeValuesFunc(value))))
            .ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtRoute<T>(this Result<T> result,
        string routeName,
        object routeValues) =>
        result.OnSuccess(() => Result.Ok(new AcceptedAtRouteDetail(routeName, routeValues)))
            .ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtRoute<T>(this Result<T> result,
        string routeName,
        Func<T, object> routeValuesFunc) =>
        result.OnSuccess(value => Result.Ok(new AcceptedAtRouteDetail(routeName, routeValuesFunc(value))))
            .ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtAction<T>(
        this Result<T> result,
        string actionName,
        string controllerName,
        object routeValues) =>
        result.OnSuccess(() => Result.Ok(
                new AcceptedAtActionDetail(actionName, controllerName, routeValues)))
            .ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtAction<T>(
        this Result<T> result,
        string actionName,
        string controllerName,
        Func<T, object> routeValuesFunc) =>
        result.OnSuccess(value => Result.Ok(
                new AcceptedAtActionDetail(actionName, controllerName, routeValuesFunc(value))))
            .ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtAction<T>(
        this Result<T> result,
        string actionName) =>
        result.OnSuccess(() => Result.Ok(
                new AcceptedAtActionDetail(actionName)))
            .ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtAction<T>(
        this Result<T> result,
        string actionName,
        string controllerName) =>
        result.OnSuccess(() => Result.Ok(
                new AcceptedAtActionDetail(actionName, controllerName)))
            .ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtAction<T>(
        this Result<T> result,
        string actionName,
        object routeValues) =>
        result.OnSuccess(() => Result.Ok(
                new AcceptedAtActionDetail(actionName, routeValues)))
            .ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAcceptedAtAction<T>(
        this Result<T> result,
        string actionName,
        Func<T, object> routeValuesFunc) =>
        result.OnSuccess(value => Result.Ok(
                new AcceptedAtActionDetail(actionName, routeValuesFunc(value))))
            .ReturnResult();

    #endregion

    #region Task<Result>

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAccepted(this Task<Result> source) =>
        source.OnSuccess(result => {
            if (result.Detail is not AcceptedDetail)
                result.Detail = new AcceptedDetail();

            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtLocation(this Task<Result> source,
        string location) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtLocation(this Task<Result> source,
        Uri location) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtRoute(
        this Task<Result> source, object routeValues) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedAtRouteDetail(routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtRoute(this Task<Result> source,
        string routeName,
        object routeValues) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedAtRouteDetail(routeName, routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtAction(
        this Task<Result> source,
        string actionName,
        string controllerName,
        object routeValues) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedAtActionDetail(actionName, controllerName, routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtAction(
        this Task<Result> source,
        string actionName) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedAtActionDetail(actionName);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtAction(
        this Task<Result> source,
        string actionName,
        string controllerName) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedAtActionDetail(actionName, controllerName);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtAction(
        this Task<Result> source,
        string actionName,
        object routeValues) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedAtActionDetail(actionName, routeValues);
            return result;
        }).ReturnResult();

    #endregion

    #region Task<Result<T>>

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAccepted<T>(this Task<Result<T>> source) =>
        source.OnSuccess((_, result) => {
            if (result.Detail is AcceptedDetail acceptedDetail)
                return Result.Ok(acceptedDetail);
            return Result.Ok(new AcceptedDetail());
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtLocation<T>(this Task<Result<T>> source,
        string location) =>
        source.OnSuccess(() => Result.Ok(new AcceptedAtLocationDetail(location)))
            .ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtLocation<T>(this Task<Result<T>> source,
        Uri location) =>
        source.OnSuccess(() => Result.Ok(new AcceptedAtLocationDetail(location)))
            .ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtRoute<T>(
        this Task<Result<T>> source, object routeValues) =>
        source.OnSuccess(() => Result.Ok(new AcceptedAtRouteDetail(routeValues)))
            .ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtRoute<T>(
        this Task<Result<T>> source, Func<T, object> routeValuesFunc) =>
        source.OnSuccess(value => Result.Ok(new AcceptedAtRouteDetail(routeValuesFunc(value))))
            .ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtRoute<T>(this Task<Result<T>> source,
        string routeName,
        object routeValues) =>
        source.OnSuccess(() => Result.Ok(new AcceptedAtRouteDetail(routeName, routeValues)))
            .ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtRoute<T>(this Task<Result<T>> source,
        string routeName,
        Func<T, object> routeValuesFunc) =>
        source.OnSuccess(value => Result.Ok(new AcceptedAtRouteDetail(routeName, routeValuesFunc(value))))
            .ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtAction<T>(
        this Task<Result<T>> source,
        string actionName,
        string controllerName,
        object routeValues) =>
        source.OnSuccess(() => Result.Ok(
                new AcceptedAtActionDetail(actionName, controllerName, routeValues)))
            .ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtAction<T>(
        this Task<Result<T>> source,
        string actionName,
        string controllerName,
        Func<T, object> routeValuesFunc) =>
        source.OnSuccess(value => Result.Ok(
                new AcceptedAtActionDetail(actionName, controllerName, routeValuesFunc(value))))
            .ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtAction<T>(
        this Task<Result<T>> source,
        string actionName) =>
        source.OnSuccess(() => Result.Ok(
                new AcceptedAtActionDetail(actionName)))
            .ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtAction<T>(
        this Task<Result<T>> source,
        string actionName,
        string controllerName) =>
        source.OnSuccess(() => Result.Ok(
                new AcceptedAtActionDetail(actionName, controllerName)))
            .ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtAction<T>(
        this Task<Result<T>> source,
        string actionName,
        object routeValues) =>
        source.OnSuccess(() => Result.Ok(
                new AcceptedAtActionDetail(actionName, routeValues)))
            .ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAcceptedAtAction<T>(
        this Task<Result<T>> source,
        string actionName,
        Func<T, object> routeValuesFunc) =>
        source.OnSuccess(value => Result.Ok(
                new AcceptedAtActionDetail(actionName, routeValuesFunc(value))))
            .ReturnResult();

    #endregion
}