using System.Text;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails;

public sealed class Result : ResultBase {
    private Result(bool success, ResultDetail? detail = null) : base(success, detail) { }

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
    public T? Value { get; }

    private Result(T item) : base(true) {
        Value = item;
    }

    private Result(T item, ResultDetail detail) : base(true, detail) {
        Value = item;
    }

    private Result(ResultDetail? detail = null) : base(false, detail) { }


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
        sb.AppendLine($"Success: {Success}");

        if (Success) {
            var value = Value is null ? "null" : Value.ToString();
            sb.AppendLine($"Value: {value}");
        }

        if (Detail is not null)
            sb.AppendLine(Detail.ToString());

        return sb.ToString();
    }
}