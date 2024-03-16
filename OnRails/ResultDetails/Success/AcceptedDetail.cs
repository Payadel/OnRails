using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Success;

public class AcceptedDetail : SuccessDetail {
    public string? Location { get; }
    public Uri? LocationUri { get; }
    public string? ActionName { get; }
    public string? ControllerName { get; }
    public string? RouteName { get; }
    public object? RouteValues { get; }

    private const string DefaultTitle = nameof(CreatedDetail);
    private const string DefaultMessage = "Request accepted for processing.";
    private const int DefaultStatusCode = StatusCodes.Status202Accepted;
    private const bool DefaultView = true;

    public AcceptedDetail() :
        base(DefaultTitle, DefaultMessage, DefaultStatusCode, null, DefaultView) { }

    public AcceptedDetail(string location) :
        base(DefaultTitle, DefaultMessage, DefaultStatusCode, null, DefaultView) {
        Location = location;
    }

    public AcceptedDetail(Uri location) :
        base(DefaultTitle, DefaultMessage, DefaultStatusCode, null, DefaultView) {
        LocationUri = location;
    }

    public AcceptedDetail(
        string routeName,
        object routeValues
    ) : base(DefaultTitle, DefaultMessage, DefaultStatusCode, null, DefaultView) {
        RouteName = routeName;
        RouteValues = routeValues;
    }

    public AcceptedDetail(
        string actionName,
        string controllerName,
        object routeValues
    ) : base(DefaultTitle, DefaultMessage, DefaultStatusCode, null, DefaultView) {
        ActionName = actionName;
        ControllerName = controllerName;
        RouteValues = routeValues;
    }
}