using System.Diagnostics;
using System.Text;

namespace OnRails.ResultDetails.Success.Created;

[DebuggerStepThrough]
public class CreatedAtActionDetail(
    string actionName,
    string? controllerName,
    object? routeValues)
    : CreatedDetail(nameof(CreatedAtActionDetail)) {
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