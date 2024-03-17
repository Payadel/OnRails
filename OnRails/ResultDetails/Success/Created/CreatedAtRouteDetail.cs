using System.Diagnostics;
using System.Text;

namespace OnRails.ResultDetails.Success.Created;

[DebuggerStepThrough]
public class CreatedAtRouteDetail : CreatedDetail {
    public CreatedAtRouteDetail(object routeValues) : base(nameof(CreatedAtRouteDetail)) {
        RouteValues = routeValues;
    }

    public CreatedAtRouteDetail(string routeName, object routeValues) :
        base(nameof(CreatedAtRouteDetail)) {
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