using OnRail.ResultDetails;

namespace OnRail;

public abstract class ResultBase {
    protected ResultBase(bool isSuccess, ResultDetail? detail = null) {
        IsSuccess = isSuccess;
        Detail = detail;
    }

    public bool IsSuccess { get; set; }
    public ResultDetail? Detail { get; set; }

    public int GetStatusCodeOrDefault(int defaultCode) {
        if (Detail?.StatusCode is null) return defaultCode;
        return (int) Detail.StatusCode;
    }
}