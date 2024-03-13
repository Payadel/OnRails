using System.Diagnostics;
using System.Text;
using OnRails.ResultDetails;

namespace OnRails;

[DebuggerStepThrough]
public abstract class ResultBase(bool success, ResultDetail? detail = null) {
    public bool Success { get; protected init; } = success;
    public ResultDetail? Detail { get; set; } = detail;
    public bool HasStatusCode => Detail?.StatusCode is not null;

    public int GetStatusCodeOrDefault(int defaultSuccessCode, int defaultFailCode) {
        if (HasStatusCode) return (int)Detail!.StatusCode!;
        return Success ? defaultSuccessCode : defaultFailCode;
    }

    public void RemoveDetail() {
        Detail = null;
    }

    public bool IsDetailTypeOf(Type type) => Detail?.IsTypeOf(type) ?? false;

    public override string ToString() {
        var sb = new StringBuilder();
        sb.AppendLine($"Success: {Success}");

        if (Detail is not null)
            sb.AppendLine(Detail.ToString());

        return sb.ToString();
    }
}