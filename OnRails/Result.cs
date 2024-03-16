using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails;

[DebuggerStepThrough]
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

    public object? GetViewValue() {
        var view = HasDetail && Detail!.View;

        return view
            ?
            // We have a detail data with view access
            Detail!.GetViewModel()
            :
            // We have not detail data or have not access to show
            null;
    }

    public int GetViewStatusCode() {
        var view = HasDetail && Detail!.View;

        if (view) {
            // We have a detail data with view access
            return GetStatusCodeOrDefault(
                StatusCodes.Status204NoContent,
                StatusCodes.Status500InternalServerError);
        }

        // We have not detail data or have not access to show
        return Success
            ? StatusCodes.Status204NoContent
            : StatusCodes.Status500InternalServerError;
    }
}

[DebuggerStepThrough]
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
        TryExtensions.Try(errorDetailFunc, numOfTry: numOfTry)
            .OnSuccess(Fail);

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

    public object? GetViewValue() {
        if (Success) return Value;

        var view = HasDetail && Detail!.View;
        return view
            ? Detail!.GetViewModel()
            : null;
    }

    public int GetViewStatusCode() {
        var view = HasDetail && Detail!.View;
        var hasValue = Value is not null;

        if (view) {
            // We have a detail data with view access
            return GetStatusCodeOrDefault(
                hasValue ? StatusCodes.Status200OK : StatusCodes.Status204NoContent,
                StatusCodes.Status500InternalServerError);
        }

        // We have not detail data or have not access to show
        if (!Success)
            return 500;
        return hasValue ? 200 : 204;
    }
}