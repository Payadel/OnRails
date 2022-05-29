using OnRail.ResultDetails;

namespace OnRail.Result;

public abstract class ResultBase {
    protected ResultBase(bool isSuccess, ResultDetail? detail = null) {
        IsSuccess = isSuccess;
        Detail = detail ?? new ResultDetail("No Data!");
    }

    public bool IsSuccess { get; }
    public ResultDetail Detail { get; }
}