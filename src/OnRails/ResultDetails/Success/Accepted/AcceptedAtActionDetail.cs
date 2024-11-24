using System.Diagnostics;
using System.Text;

namespace OnRails.ResultDetails.Success.Accepted;

[DebuggerStepThrough]
public class AcceptedAtActionDetail : AcceptedDetail {
    public AcceptedAtActionDetail(string actionName) : base(nameof(AcceptedAtActionDetail)) {
        ActionName = actionName;
    }

    public AcceptedAtActionDetail(
        string actionName,
        string controllerName) : base(nameof(AcceptedAtActionDetail)) {
        ActionName = actionName;
        ControllerName = controllerName;
    }

    public AcceptedAtActionDetail(
        string actionName,
        string controllerName,
        object routeValues) : base(nameof(AcceptedAtActionDetail)) {
        ActionName = actionName;
        ControllerName = controllerName;
        RouteValues = routeValues;
    }

    public AcceptedAtActionDetail(
        string actionName,
        object routeValues) : base(nameof(AcceptedAtActionDetail)) {
        ActionName = actionName;
        RouteValues = routeValues;
    }

    public string ActionName { get; }
    public string? ControllerName { get; }
    public object? RouteValues { get; }

    protected override string CustomFieldsToString() {
        var sb = new StringBuilder();

        sb.AppendLine($"Action Name: {ActionName}")
            .AppendLine($"Controller Name: {ControllerName}")
            .AppendLine($"Route Values: {RouteValues}");

        return sb.ToString();
    }
}