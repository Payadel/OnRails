using OnRail.Extensions.Tee;

namespace OnRail.Extensions.Using;

public static partial class UsingExtensions {
    public static TSource TeeUsing<TSource, TResult>(
        this TSource obj,
        Func<TSource, TResult> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));

    public static TSource TeeUsing<TSource, TResult>(
        this TSource obj,
        Func<TResult> function,
        int numOfTry = 1) where TSource : IDisposable =>
        obj.Tee(() => obj.Using(function, numOfTry));
}