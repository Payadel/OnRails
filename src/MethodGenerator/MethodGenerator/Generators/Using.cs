using MethodGenerator.App;

namespace MethodGenerator.Generators;

public class Using() : App.MethodGenerator(nameof(Using), ["TSource", "TResult"]) {
    public HashSet<string> SourceTypes { get; } = ["TSource"];
    public HashSet<string> ReturnTypes { get; } = ["Result<TResult>", "Result"];

    public HashSet<string> FunctionTypes { get; } = [
        "Func<TResult> function", "Func<Result<TResult>> function",
        "Func<TSource, TResult> function", "Func<TSource, Result<TResult>> function",
        "Func<Result> function", "Func<TSource, Result> function",
        "Action action", "Action<TSource> action"
    ];

    public string Format { get; set; } = """
                                         public static {0} Using(
                                         this {1} obj,
                                         {2},
                                         int numOfTry = 1) where TSource : IDisposable => null;
                                         """;

    protected override bool ValidCombination(IReadOnlyList<string> parameters) {
        return true;
    }

    public override List<GeneratedMethod> GenerateMethodSignature() =>
        GenerateMethodSignature([ReturnTypes, SourceTypes, FunctionTypes], Format);
}