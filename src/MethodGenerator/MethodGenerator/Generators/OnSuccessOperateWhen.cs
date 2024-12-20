using MethodGenerator.App;
using MethodGenerator.Helpers;

namespace MethodGenerator.Generators;

public class OnSuccessOperateWhen() : App.MethodGenerator(nameof(OnSuccessOperateWhen), ["T"], "Default") {
    public HashSet<string> SourceTypes { get; } = ["Result", "Result<T>"];
    public HashSet<string> PredicateTypes { get; } = ["bool condition", "Func<bool> predicate"];

    public HashSet<string> FunctionTypes { get; } = [
        "Func<Result> function", "Func<Result<T>> function", "Action action", "Action<T> action",
        "Func<T, Result<T>> function", "Func<T, Result> function"
    ];

    public string Format { get; set; } = """
                                         public static {0} OnSuccessOperateWhen(
                                             this {0} source,
                                             {1},
                                             {2},
                                             int numOfTry = 1
                                         ) => throw new NotImplementedException();
                                         """;

    public override List<GeneratedMethod> GenerateMethodSignature() =>
        GenerateMethodSignature([SourceTypes, PredicateTypes, FunctionTypes], Format);

    protected override bool ValidCombination(IReadOnlyList<string> parameters) {
        if (GenericNames.Count == 0) return true; // None of them are generic.

        var sourceType = parameters[0];
        return PatternChecker.IsGeneric(sourceType, GenericNames)
               || parameters.Skip(1).All(param => !PatternChecker.IsGeneric(param, GenericNames));
    }
}