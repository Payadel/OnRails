using OnRail.ResultDetails;

namespace OnRail;

public sealed class Result : ResultBase {
    private Result(bool isSuccess, ResultDetail? detail = null) : base(isSuccess, detail) { }

    public static Result Ok() {
        return new Result(true);
    }

    public static Result Ok(ResultDetail detail) {
        return new Result(true, detail);
    }

    public static Result Fail(ResultDetail? detail = null) {
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

    public static Result<T> Ok(T item, ResultDetail detail) {
        return new Result<T>(item, detail);
    }

    public static Result<T> Fail(ResultDetail? detail = null) {
        return new Result<T>(detail);
    }
}