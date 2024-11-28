using MethodGeneratorTemplate.App;
using MethodGeneratorTemplate.Helpers;

namespace MethodGeneratorTemplate.Generators;

public class OnSuccessOperateWhen() : MethodGenerator(nameof(OnSuccessOperateWhen), "T") {
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
                                         ) => null;
                                         """;

    public override List<GeneratedMethod> GenerateMethodSignature() =>
        GenerateMethodSignature([SourceTypes, PredicateTypes, FunctionTypes], Format);

    protected override bool ValidCombination(IReadOnlyList<string> parameters) {
        if (string.IsNullOrWhiteSpace(GenericName)) return true; // None of them are generic.

        var sourceType = parameters[0];
        return PatternChecker.IsGeneric(sourceType, GenericName)
               || parameters.Skip(1).All(param => !PatternChecker.IsGeneric(param, GenericName));
    }
}