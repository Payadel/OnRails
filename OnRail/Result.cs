using System.Text;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail;

public sealed class Result : ResultBase {
    private Result(bool isSuccess, ResultDetail? detail = null) : base(isSuccess, detail) { }

    public static Result Ok() {
        return new Result(true);
    }

    public static Result Ok(SuccessDetail detail) {
        return new Result(true, detail);
    }

    public static Result Fail(ErrorDetail? detail = null) {
        return new Result(false, detail);
    }
}

public sealed class Result<T> : ResultBase {
    private Result(T item, ResultDetail? detail = null) : base(true, detail) {
        Value = item;
    }

    private Result(ResultDetail? detail = null) : base(false, detail) { }

    public T? Value { get; }

    public static Result<T> Ok(T item) {
        return new Result<T>(item);
    }

    public static Result<T> Ok(T item, SuccessDetail detail) {
        return new Result<T>(item, detail);
    }

    public static Result<T> Fail(ErrorDetail? detail = null) {
        return new Result<T>(detail);
    }

    public static Result<T> Fail(Func<ErrorDetail?> errorDetailFunc, int numOfTry = 1) =>
        TryExtensions.Try(() => new Result<T>(errorDetailFunc()), numOfTry);

    public override string ToString() {
        var sb = new StringBuilder();
        sb.AppendLine($"Success: {IsSuccess}");
        if (IsSuccess && Value is not null)
            sb.AppendLine($"Value: {Value}");
        if (Detail is not null)
            sb.AppendLine(Detail.ToString());
        return sb.ToString();
    }
}