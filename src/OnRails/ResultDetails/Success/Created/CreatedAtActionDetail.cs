using System.Diagnostics;
using System.Text;

namespace OnRails.ResultDetails.Success.Created;

[DebuggerStepThrough]
public class CreatedAtActionDetail : CreatedDetail {
    public CreatedAtActionDetail(string actionName) : base(nameof(CreatedAtActionDetail)) {
        ActionName = actionName;
    }

    public CreatedAtActionDetail(
        string actionName,
        string controllerName) : base(nameof(CreatedAtActionDetail)) {
        ActionName = actionName;
        ControllerName = controllerName;
    }

    public CreatedAtActionDetail(
        string actionName,
        string controllerName,
        object routeValues) : base(nameof(CreatedAtActionDetail)) {
        ActionName = actionName;
        ControllerName = controllerName;
        RouteValues = routeValues;
    }

    public CreatedAtActionDetail(
        string actionName,
        object routeValues) : base(nameof(CreatedAtActionDetail)) {
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