using MethodGenerator.App;

namespace MethodGenerator.Generators.Using;

public class TeeUsing() : App.MethodGenerator(nameof(TeeUsing), ["TSource", "TResult"], "Default") {
    public HashSet<string> SourceTypes { get; } = ["TSource", "Task<TSource>"];

    public HashSet<string> FunctionTypes { get; } = [
        "Func<TResult> function", "Func<Result<TResult>> function",
        "Func<Task<TResult>> function", "Func<Task<Result<TResult>>> function",
        "Func<TSource, TResult> function", "Func<TSource, Result<TResult>> function",
        "Func<TSource, Task<TResult>> function", "Func<TSource, Task<Result<TResult>>> function",
        "Func<Result> function", "Func<TSource, Result> function",
        "Func<Task<Result>> function", "Func<TSource, Task<Result>> function",
    ];

    public string Format { get; set; } = """
                                         public static {0} TeeUsing(
                                             this {0} obj,
                                             {1},
                                             int numOfTry = 1) where TSource : IDisposable =>
                                             throw new NotImplementedException();
                                         """;

    protected override bool ValidCombination(IReadOnlyList<string> parameters) {
        var taskParams = parameters.Count(param => param.Contains("Task"));
        return taskParams != 1;
    }

    public override List<GeneratedMethod> GenerateMethodSignature() =>
        GenerateMethodSignature([SourceTypes, FunctionTypes], Format);
}