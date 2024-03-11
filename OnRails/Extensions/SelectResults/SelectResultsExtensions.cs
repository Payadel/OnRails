using System.Diagnostics;
using OnRails.Extensions.OnFail;
using OnRails.Extensions.OnSuccess;
using OnRails.Extensions.Try;
using OnRails.ResultDetails;

namespace OnRails.Extensions.SelectResults;

[DebuggerStepThrough]
public static partial class SelectResultsExtensions {
    public static Result<List<TResult>> SelectResults<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source.ToList, numOfTry)
        .OnSuccess(list => {
            var selectedResult = new List<TResult>(list.Count);

            foreach (var item in list) {
                var result = item.Try(function, numOfTry)
                    .OnFailAddMoreDetails(new { item });
                if (!result.Success)
                    return Result<List<TResult>>.Fail(result.Detail as ErrorDetail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        });

    public static Result<List<TResult>> SelectResults<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source.ToList, numOfTry)
        .OnSuccess(list => {
            var selectedResult = new List<TResult>(list.Count);

            foreach (var item in list) {
                var result = item.Try(function, numOfTry)
                    .OnFailAddMoreDetails(new { item });
                if (!result.Success)
                    return Result<List<TResult>>.Fail(result.Detail as ErrorDetail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        });
}