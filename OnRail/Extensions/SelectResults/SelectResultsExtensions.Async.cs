using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;

namespace OnRail.Extensions.SelectResults;

public static partial class SelectResultsExtensions {
    public static Task<Result<List<TResult>>> SelectResults<TSource, TResult>(
        this Task<IEnumerable<TSource>> source,
        Func<TSource, Result<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(items => {
            var list = items.ToList();
            var selectedResult = new List<TResult>(list.Count);
            foreach (var item in list) {
                var result = item.Try(function, numOfTry)
                    .OnFailAddMoreDetails(new {item});
                if (!result.IsSuccess)
                    return Result<List<TResult>>.Fail(result.Detail as ErrorDetail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        }, numOfTry: 1);

    public static Task<Result<List<TResult>>> SelectResults<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source.ToList, numOfTry)
        .OnSuccess(async list => {
            var selectedResult = new List<TResult>(list.Count);

            foreach (var item in list) {
                var result = await item.Try(function, numOfTry)
                    .OnFailAddMoreDetails(new {item});
                if (!result.IsSuccess)
                    return Result<List<TResult>>.Fail(result.Detail as ErrorDetail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        });

    public static Task<Result<List<TResult>>> SelectResults<TSource, TResult>(
        this Task<IEnumerable<TSource>> source,
        Func<TSource, Task<Result<TResult>>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(async items => {
            var list = items.ToList();
            var selectedResult = new List<TResult>(list.Count);
            foreach (var item in list) {
                var result = await item.Try(function, numOfTry)
                    .OnFailAddMoreDetails(new {item});
                if (!result.IsSuccess)
                    return Result<List<TResult>>.Fail(result.Detail as ErrorDetail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        });

    public static Task<Result<List<TResult>>> SelectResults<TSource, TResult>(
        this Task<IEnumerable<TSource>> source,
        Func<TSource, TResult> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(items => {
            var list = items.ToList();
            var selectedResult = new List<TResult>(list.Count);
            foreach (var item in list) {
                var result = item.Try(function, numOfTry)
                    .OnFailAddMoreDetails(new {item});
                if (!result.IsSuccess)
                    return Result<List<TResult>>.Fail(result.Detail as ErrorDetail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        });

    public static Task<Result<List<TResult>>> SelectResults<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source.ToList, numOfTry)
        .OnSuccess(async list => {
            var selectedResult = new List<TResult>(list.Count);

            foreach (var item in list) {
                var result = await item.Try(function, numOfTry)
                    .OnFailAddMoreDetails(new {item});
                if (!result.IsSuccess)
                    return Result<List<TResult>>.Fail(result.Detail as ErrorDetail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        });

    public static Task<Result<List<TResult>>> SelectResults<TSource, TResult>(
        this Task<IEnumerable<TSource>> source,
        Func<TSource, Task<TResult>> function,
        int numOfTry = 1
    ) => TryExtensions.Try(source, numOfTry)
        .OnSuccess(async items => {
            var list = items.ToList();
            var selectedResult = new List<TResult>(list.Count);
            foreach (var item in list) {
                var result = await item.Try(function, numOfTry)
                    .OnFailAddMoreDetails(new {item});
                if (!result.IsSuccess)
                    return Result<List<TResult>>.Fail(result.Detail as ErrorDetail);

                selectedResult.Add(result.Value!);
            }

            return Result<List<TResult>>.Ok(selectedResult);
        });
}