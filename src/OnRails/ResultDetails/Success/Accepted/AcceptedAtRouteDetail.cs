using System.Diagnostics;
using System.Text;

namespace OnRails.ResultDetails.Success.Accepted;

[DebuggerStepThrough]
public class AcceptedAtRouteDetail : AcceptedDetail {
    public AcceptedAtRouteDetail(object routeValues) : base(nameof(AcceptedAtRouteDetail)) {
        RouteValues = routeValues;
    }

    public AcceptedAtRouteDetail(string routeName, object routeValues) :
        base(nameof(AcceptedAtRouteDetail)) {
        RouteName = routeName;
        RouteValues = routeValues;
    }

    public string? RouteName { get; }
    public object RouteValues { get; }

    protected override string CustomFieldsToString() {
        var sb = new StringBuilder();

        sb.AppendLine($"Route Name: {RouteName}")
            .AppendLine($"Route Values: {RouteValues}");

        return sb.ToString();
    }
}