using MethodGenerator.App;

namespace MethodGenerator.Generators.Using;

public class UsingAsync() : App.MethodGenerator(nameof(Using), ["TSource", "TResult"], "Async") {
    public HashSet<string> SourceTypes { get; } = ["TSource", "Task<TSource>"];
    public HashSet<string> ReturnTypes { get; } = ["Task<Result<TResult>>", "Task<Result>"];

    public HashSet<string> FunctionTypes { get; } = [
        "Func<TResult> function", "Func<Result<TResult>> function",
        "Func<Task<TResult>> function", "Func<Task<Result<TResult>>> function",
        "Func<TSource, TResult> function", "Func<TSource, Result<TResult>> function",
        "Func<TSource, Task<TResult>> function", "Func<TSource, Task<Result<TResult>>> function",
        "Func<Result> function", "Func<TSource, Result> function",
        "Func<Task<Result>> function", "Func<TSource, Task<Result>> function",
    ];

    public string Format { get; set; } = """
                                         public static {0} Using(
                                         this {1} obj,
                                         {2},
                                         int numOfTry = 1) where TSource : IDisposable => null;
                                         """;

    protected override bool ValidCombination(IReadOnlyList<string> parameters) {
        return parameters.Skip(1).Any(param => param.Contains("Task"));
    }

    public override List<GeneratedMethod> GenerateMethodSignature() =>
        GenerateMethodSignature([ReturnTypes, SourceTypes, FunctionTypes], Format);
}