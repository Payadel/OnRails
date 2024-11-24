using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace OnRails.Middlewares;

public class RequestTrackingMiddleware(RequestDelegate next) {
    public Task InvokeAsync(HttpContext context) {
        var requestId = context.TraceIdentifier;
        var traceId = Activity.Current?.RootId ?? context.TraceIdentifier;

        // Add the IDs to the response headers
        context.Response.Headers.TryAdd("Request-Id", requestId);
        context.Response.Headers.TryAdd("Trace-Id", traceId);

        // Call the next delegate/middleware in the pipeline.
        return next(context);
    }
}

public static class RequestTrackingMiddlewareExtensions {
    public static IApplicationBuilder UseRequestTracking(
        this IApplicationBuilder builder) =>
        builder.UseMiddleware<RequestTrackingMiddleware>();
}