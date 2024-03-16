using Microsoft.AspNetCore.Http;

namespace OnRails.ResultDetails.Success;

public class CreatedDetail : SuccessDetail {
    public string? Location { get; }
    public Uri? LocationUri { get; }
    public string? ActionName { get; }
    public string? ControllerName { get; }
    public string? RouteName { get; }
    public object? RouteValues { get; }


    private const string DefaultTitle = nameof(CreatedDetail);
    private const int DefaultStatusCode = StatusCodes.Status201Created;
    private const bool DefaultView = true;

    public CreatedDetail() :
        base(DefaultTitle, null, DefaultStatusCode, null, DefaultView) { }

    public CreatedDetail(string location) :
        base(DefaultTitle, null, DefaultStatusCode, null, DefaultView) {
        Location = location;
    }

    public CreatedDetail(Uri location) :
        base(DefaultTitle, null, DefaultStatusCode, null, DefaultView) {
        LocationUri = location;
    }

    public CreatedDetail(
        string routeName,
        object routeValues
    ) : base(DefaultTitle, null, DefaultStatusCode, null, DefaultView) {
        RouteName = routeName;
        RouteValues = routeValues;
    }

    public CreatedDetail(
        string actionName,
        string? controllerName,
        object routeValues
    ) : base(DefaultTitle, null, DefaultStatusCode, null, DefaultView) {
        ActionName = actionName;
        ControllerName = controllerName;
        RouteValues = routeValues;
    }

    public override Dictionary<string, object?> GetViewModel() => new();
}