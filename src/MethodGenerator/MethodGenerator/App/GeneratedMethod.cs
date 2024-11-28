using MethodGenerator.Helpers;

namespace MethodGenerator.App;

public class GeneratedMethod : Equatable {
    public string MethodName { get; }
    public HashSet<string> GenericNames { get; }
    public bool IsGeneric => GenericNames.Count > 0;
    public string Format { get; }
    public string Result { get; }
    public List<string> Parameters { get; }

    public GeneratedMethod(string methodName, string format, List<string>? parameters, HashSet<string>? genericNames) {
        if (string.IsNullOrWhiteSpace(methodName)) throw new ArgumentNullException(nameof(methodName));
        if (string.IsNullOrWhiteSpace(format)) throw new ArgumentNullException(nameof(format));

        Format = format;
        MethodName = methodName;
        Parameters = parameters ?? [];


        GenericNames = genericNames ?? [];
        GenericNames = PatternChecker.GetExistGenerics(Parameters, GenericNames);

        var formatResult = string.Format(format, Parameters.ToArray());
        if (IsGeneric) {
            var genericTypes = string.Join(", ", GenericNames);
            formatResult = formatResult.Replace(methodName, $"{methodName}<{genericTypes}>");
        }

        Result = formatResult;
    }

    protected override IEnumerable<object?> GetEqualityComponents() {
        yield return Result;
    }
}