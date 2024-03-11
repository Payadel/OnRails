using System.Text;
using OnRails.ResultDetails;

namespace OnRails;

public abstract class ResultBase(bool success, ResultDetail? detail = null) {
    public bool Success { get; } = success;
    public ResultDetail? Detail { get; set; } = detail;

    public int GetStatusCodeOrDefault(int defaultCode) {
        if (Detail?.StatusCode is null) return defaultCode;
        return (int)Detail.StatusCode;
    }

    public override string ToString() {
        var sb = new StringBuilder();
        sb.AppendLine($"Success: {Success}");

        if (Detail is not null)
            sb.AppendLine(Detail.ToString());

        return sb.ToString();
    }
}