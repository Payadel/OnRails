using OnRails.ResultDetails;

namespace OnRails.Extensions.GetValuesExtensions;

public static class GetValuesExtensions {
    public static Result<List<T?>> GetValues<T>(params Result<T>[] results) {
        foreach (var result in results)
            if (!result.Success)
                return Result<List<T?>>.Fail((ErrorDetail?)result.Detail);

        var values = results.Select(result => result.Value).ToList();
        return Result<List<T?>>.Ok(values);
    }

    public static Result<(T1?, T2?)> GetValues<T1, T2>(Result<T1> result1, Result<T2> result2) {
        if (!result1.Success) return Result<(T1?, T2?)>.Fail((ErrorDetail?)result1.Detail);
        if (!result2.Success) return Result<(T1?, T2?)>.Fail((ErrorDetail?)result2.Detail);

        return Result<(T1?, T2?)>.Ok((result1.Value, result2.Value));
    }

    public static Result<(T1?, T2?, T3?)> GetValues<T1, T2, T3>(
        Result<T1> result1, Result<T2> result2, Result<T3> result3) {
        if (!result1.Success) return Result<(T1?, T2?, T3?)>.Fail((ErrorDetail?)result1.Detail);
        if (!result2.Success) return Result<(T1?, T2?, T3?)>.Fail((ErrorDetail?)result2.Detail);
        if (!result3.Success) return Result<(T1?, T2?, T3?)>.Fail((ErrorDetail?)result3.Detail);

        return Result<(T1?, T2?, T3?)>.Ok((result1.Value, result2.Value, result3.Value));
    }

    public static Result<(T1?, T2?, T3?, T4?)> GetValues<T1, T2, T3, T4>(
        Result<T1> result1, Result<T2> result2, Result<T3> result3, Result<T4> result4) {
        if (!result1.Success) return Result<(T1?, T2?, T3?, T4?)>.Fail((ErrorDetail?)result1.Detail);
        if (!result2.Success) return Result<(T1?, T2?, T3?, T4?)>.Fail((ErrorDetail?)result2.Detail);
        if (!result3.Success) return Result<(T1?, T2?, T3?, T4?)>.Fail((ErrorDetail?)result3.Detail);
        if (!result4.Success) return Result<(T1?, T2?, T3?, T4?)>.Fail((ErrorDetail?)result4.Detail);

        return Result<(T1?, T2?, T3?, T4?)>.Ok((result1.Value, result2.Value, result3.Value, result4.Value));
    }

    public static Result<(T1?, T2?, T3?, T4?, T5?)> GetValues<T1, T2, T3, T4, T5>(
        Result<T1> result1, Result<T2> result2, Result<T3> result3, Result<T4> result4, Result<T5> result5) {
        if (!result1.Success) return Result<(T1?, T2?, T3?, T4?, T5?)>.Fail((ErrorDetail?)result1.Detail);
        if (!result2.Success) return Result<(T1?, T2?, T3?, T4?, T5?)>.Fail((ErrorDetail?)result2.Detail);
        if (!result3.Success) return Result<(T1?, T2?, T3?, T4?, T5?)>.Fail((ErrorDetail?)result3.Detail);
        if (!result4.Success) return Result<(T1?, T2?, T3?, T4?, T5?)>.Fail((ErrorDetail?)result4.Detail);
        if (!result5.Success) return Result<(T1?, T2?, T3?, T4?, T5?)>.Fail((ErrorDetail?)result5.Detail);

        return Result<(T1?, T2?, T3?, T4?, T5?)>.Ok((result1.Value, result2.Value, result3.Value, result4.Value,
            result5.Value));
    }
}