using System.Diagnostics;
using System.Text;

namespace OnRails.ResultDetails.Success.Accepted;

[DebuggerStepThrough]
public class AcceptedAtActionDetail(
    string actionName,
    string? controllerName,
    object? routeValues)
    : AcceptedDetail(nameof(AcceptedAtActionDetail)) {
    public string ActionName { get; } = actionName;
    public string? ControllerName { get; } = controllerName;
    public object? RouteValues { get; } = routeValues;

    protected override string CustomFieldsToString() {
        var sb = new StringBuilder();

        sb.AppendLine($"Action Name: {ActionName}")
            .AppendLine($"Controller Name: {ControllerName}")
            .AppendLine($"Route Values: {RouteValues}");

        return sb.ToString();
    }
}