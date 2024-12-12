using OnRails.Extensions.OnSuccess;
using OnRails.ResultDetails.Success.Created;

namespace OnRails.Extensions.ActionResult;

public static partial class ActionResultExtensions {
    #region Result

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnCreated(this Result result) =>
        result.OnSuccess(() => {
            if (result.Detail is not CreatedDetail)
                result.Detail = new CreatedDetail();

            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnCreatedAtLocation(this Result result, string location) =>
        result.OnSuccess(() => {
            result.Detail = new CreatedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnCreatedAtLocation(this Result result, Uri location) =>
        result.OnSuccess(() => {
            result.Detail = new CreatedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnCreatedAtRoute(
        this Result result, object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new CreatedAtRouteDetail(routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnCreatedAtRoute(this Result result, string routeName,
        object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new CreatedAtRouteDetail(routeName, routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnCreatedAtAction(
        this Result result,
        string actionName,
        string controllerName,
        object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new CreatedAtActionDetail(actionName, controllerName, routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnCreatedAtAction(
        this Result result,
        string actionName) =>
        result.OnSuccess(() => {
            result.Detail = new CreatedAtActionDetail(actionName);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnCreatedAtAction(
        this Result result,
        string actionName,
        string controllerName) =>
        result.OnSuccess(() => {
            result.Detail = new CreatedAtActionDetail(actionName, controllerName);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnCreatedAtAction(
        this Result result,
        string actionName,
        object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new CreatedAtActionDetail(actionName, routeValues);
            return result;
        }).ReturnResult();

    #endregion

    #region Result<T>

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreated<T>(this Result<T> source) =>
        source.OnSuccess((_, result) => {
            if (result.Detail is not CreatedDetail)
                result.Detail = new CreatedDetail();

            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreatedAtLocation<T>(this Result<T> source,
        string location) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T>
        ReturnCreatedAtLocation<T>(this Result<T> source, Uri location) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreatedAtRoute<T>(
        this Result<T> source, object routeValues) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtRouteDetail(routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreatedAtRoute<T>(
        this Result<T> source, Func<T, object> routeValuesFunc) =>
        source.OnSuccess((value, result) => {
            result.Detail = new CreatedAtRouteDetail(routeValuesFunc(value));
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreatedAtRoute<T>(this Result<T> source,
        string routeName,
        object routeValues) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtRouteDetail(routeName, routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreatedAtRoute<T>(this Result<T> source,
        string routeName,
        Func<T, object> routeValuesFunc) =>
        source.OnSuccess((value, result) => {
            result.Detail = new CreatedAtRouteDetail(routeName, routeValuesFunc(value));
            return result;
        }).ReturnResult();


    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreatedAtAction<T>(
        this Result<T> source,
        string actionName,
        string controllerName,
        object routeValues) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtActionDetail(actionName, controllerName, routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreatedAtAction<T>(
        this Result<T> source,
        string actionName,
        string controllerName,
        Func<T, object> routeValuesFunc) =>
        source.OnSuccess((value, result) => {
            result.Detail = new CreatedAtActionDetail(actionName, controllerName, routeValuesFunc(value));
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreatedAtAction<T>(
        this Result<T> source,
        string actionName) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtActionDetail(actionName);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreatedAtAction<T>(
        this Result<T> source,
        string actionName,
        string controllerName) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtActionDetail(actionName, controllerName);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreatedAtAction<T>(
        this Result<T> source,
        string actionName,
        object routeValues) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtActionDetail(actionName, routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnCreatedAtAction<T>(
        this Result<T> source,
        string actionName,
        Func<T, object> routeValuesFunc) =>
        source.OnSuccess((value, result) => {
            result.Detail = new CreatedAtActionDetail(actionName, routeValuesFunc(value));
            return result;
        }).ReturnResult();

    #endregion

    #region Task<Result>

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnCreated(this Task<Result> source) =>
        source.OnSuccess(result => {
            if (result.Detail is not CreatedDetail)
                result.Detail = new CreatedDetail();

            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnCreatedAtLocation(this Task<Result> source,
        string location) =>
        source.OnSuccess(result => {
            result.Detail = new CreatedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnCreatedAtLocation(this Task<Result> source,
        Uri location) =>
        source.OnSuccess(result => {
            result.Detail = new CreatedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnCreatedAtRoute(
        this Task<Result> source, object routeValues) =>
        source.OnSuccess(result => {
            result.Detail = new CreatedAtRouteDetail(routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnCreatedAtRoute(this Task<Result> source,
        string routeName,
        object routeValues) =>
        source.OnSuccess(result => {
            result.Detail = new CreatedAtRouteDetail(routeName, routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnCreatedAtAction(
        this Task<Result> source,
        string actionName,
        string controllerName,
        object routeValues) =>
        source.OnSuccess(result => {
            result.Detail = new CreatedAtActionDetail(actionName, controllerName, routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnCreatedAtAction(
        this Task<Result> source,
        string actionName) =>
        source.OnSuccess(result => {
            result.Detail = new CreatedAtActionDetail(actionName);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnCreatedAtAction(
        this Task<Result> source,
        string actionName,
        string controllerName) =>
        source.OnSuccess(result => {
            result.Detail = new CreatedAtActionDetail(actionName, controllerName);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnCreatedAtAction(
        this Task<Result> source,
        string actionName,
        object routeValues) =>
        source.OnSuccess(result => {
            result.Detail = new CreatedAtActionDetail(actionName, routeValues);
            return result;
        }).ReturnResult();

    #endregion

    #region Task<Result<T>>

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreated<T>(this Task<Result<T>> source) =>
        source.OnSuccess((_, result) => {
            if (result.Detail is not CreatedDetail)
                result.Detail = new CreatedDetail();

            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreatedAtLocation<T>(this Task<Result<T>> source,
        string location) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>>
        ReturnCreatedAtLocation<T>(this Task<Result<T>> source, Uri location) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtLocationDetail(location);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreatedAtRoute<T>(
        this Task<Result<T>> source, object routeValues) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtRouteDetail(routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreatedAtRoute<T>(
        this Task<Result<T>> source, Func<T, object> routeValuesFunc) =>
        source.OnSuccess((value, result) => {
            result.Detail = new CreatedAtRouteDetail(routeValuesFunc(value));
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreatedAtRoute<T>(this Task<Result<T>> source,
        string routeName,
        object routeValues) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtRouteDetail(routeName, routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreatedAtRoute<T>(this Task<Result<T>> source,
        string routeName,
        Func<T, object> routeValuesFunc) =>
        source.OnSuccess((value, result) => {
            result.Detail = new CreatedAtRouteDetail(routeName, routeValuesFunc(value));
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreatedAtAction<T>(
        this Task<Result<T>> source,
        string actionName,
        string controllerName,
        object routeValues) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtActionDetail(actionName, controllerName, routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreatedAtAction<T>(
        this Task<Result<T>> source,
        string actionName,
        string controllerName,
        Func<T, object> routeValuesFunc) =>
        source.OnSuccess((value, result) => {
            result.Detail = new CreatedAtActionDetail(actionName, controllerName, routeValuesFunc(value));
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreatedAtAction<T>(
        this Task<Result<T>> source,
        string actionName) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtActionDetail(actionName);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreatedAtAction<T>(
        this Task<Result<T>> source,
        string actionName,
        string controllerName) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtActionDetail(actionName, controllerName);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreatedAtAction<T>(
        this Task<Result<T>> source,
        string actionName,
        object routeValues) =>
        source.OnSuccess((_, result) => {
            result.Detail = new CreatedAtActionDetail(actionName, routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnCreatedAtAction<T>(
        this Task<Result<T>> source,
        string actionName,
        Func<T, object> routeValuesFunc) =>
        source.OnSuccess((value, result) => {
            result.Detail = new CreatedAtActionDetail(actionName, routeValuesFunc(value));
            return result;
        }).ReturnResult();

    #endregion
}