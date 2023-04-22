using System.Text;
using OnRail.ResultDetails;

namespace OnRail;

public abstract class ResultBase {
    public bool IsSuccess { get; set; }
    public ResultDetail? Detail { get; set; }

    protected ResultBase(bool isSuccess, ResultDetail? detail = null) {
        IsSuccess = isSuccess;
        Detail = detail;
    }

    public int GetStatusCodeOrDefault(int defaultCode) {
        if (Detail?.StatusCode is null) return defaultCode;
        return (int) Detail.StatusCode;
    }

    public override string ToString() {
        var sb = new StringBuilder();
        sb.AppendLine($"Success: {IsSuccess}");
        if (Detail is not null) 
            sb.AppendLine(Detail.ToString());
        return sb.ToString();
    }
}