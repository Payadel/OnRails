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

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAccepted(this Result result, string location) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedDetail(location);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAccepted(this Result result, Uri location) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedDetail(location);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAccepted(this Result result, string routeName,
        object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedDetail(routeName, routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult ReturnAccepted(
        this Result result,
        string actionName,
        string? controllerName,
        object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedDetail(actionName, controllerName, routeValues);
            return result;
        }).ReturnResult();

    #endregion

    #region Task<Result>

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAccepted(this Task<Result> source) =>
        source.OnSuccess(result => {
            if (result.Detail is not AcceptedDetail)
                result.Detail = new AcceptedDetail();

            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult>
        ReturnAccepted(this Task<Result> source, string location) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedDetail(location);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAccepted(this Task<Result> source, Uri location) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedDetail(location);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAccepted(this Task<Result> source, string routeName,
        object routeValues) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedDetail(routeName, routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult> ReturnAccepted(
        this Task<Result> source,
        string actionName,
        string? controllerName,
        object routeValues) =>
        source.OnSuccess(result => {
            result.Detail = new AcceptedDetail(actionName, controllerName, routeValues);
            return result;
        }).ReturnResult();

    #endregion

    #region Result<T>

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnAccepted<T>(this Result<T> result) =>
        result.OnSuccess(() => {
            if (result.Detail is not AcceptedDetail)
                result.Detail = new AcceptedDetail();

            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnAccepted<T>(this Result<T> result, string location) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedDetail(location);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnAccepted<T>(this Result<T> result, Uri location) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedDetail(location);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnAccepted<T>(this Result<T> result, string routeName,
        object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedDetail(routeName, routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnAccepted<T>(this Result<T> result, string routeName,
        Func<T, object> routeValuesFunc) =>
        result.OnSuccess(routeValuesFunc)
            .OnSuccess(routeValues => {
                result.Detail = new AcceptedDetail(routeName, routeValues);
                return result;
            }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnAccepted<T>(
        this Result<T> result,
        string actionName,
        string? controllerName,
        object routeValues) =>
        result.OnSuccess(() => {
            result.Detail = new AcceptedDetail(actionName, controllerName, routeValues);
            return result;
        }).ReturnResult();

    public static Microsoft.AspNetCore.Mvc.ActionResult<T> ReturnAccepted<T>(
        this Result<T> result,
        string actionName,
        string? controllerName,
        Func<T, object> routeValuesFunc) =>
        result.OnSuccess(routeValuesFunc)
            .OnSuccess(routeValues => {
                result.Detail = new AcceptedDetail(actionName, controllerName, routeValues);
                return result;
            }).ReturnResult();

    #endregion

    #region Task<Result<T>>

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnAccepted<T>(this Task<Result<T>> source) =>
        source.OnSuccess((_, result) => {
            if (result.Detail is not AcceptedDetail)
                result.Detail = new AcceptedDetail();

            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnAccepted<T>(this Task<Result<T>> source,
        string location) =>
        source.OnSuccess((_, result) => {
            result.Detail = new AcceptedDetail(location);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnAccepted<T>(this Task<Result<T>> source,
        Uri location) =>
        source.OnSuccess((_, result) => {
            result.Detail = new AcceptedDetail(location);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnAccepted<T>(this Task<Result<T>> source,
        string routeName,
        object routeValues) =>
        source.OnSuccess((_, result) => {
            result.Detail = new AcceptedDetail(routeName, routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnAccepted<T>(this Task<Result<T>> source,
        string routeName,
        Func<T, object> routeValuesFunc) => source.OnSuccess((value, result) => {
        routeValuesFunc(value)
            .OnSuccess(routeValues => {
                result.Detail = new AcceptedDetail(routeName, routeValues);
                return result;
            }).ReturnResult();
    });

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnAccepted<T>(
        this Task<Result<T>> source,
        string actionName,
        string? controllerName,
        object routeValues) =>
        source.OnSuccess((_, result) => {
            result.Detail = new AcceptedDetail(actionName, controllerName, routeValues);
            return result;
        }).ReturnResult();

    public static Task<Microsoft.AspNetCore.Mvc.ActionResult<T>> ReturnAccepted<T>(
        this Task<Result<T>> source,
        string actionName,
        string? controllerName,
        Func<T, object> routeValuesFunc) => source.OnSuccess((value, result) => {
        routeValuesFunc(value)
            .OnSuccess(routeValues => {
                result.Detail = new AcceptedDetail(actionName, controllerName, routeValues);
                return result;
            }).ReturnResult();

        #endregion
    }