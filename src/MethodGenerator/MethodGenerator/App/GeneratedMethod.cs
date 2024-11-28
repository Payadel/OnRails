using MethodGeneratorTemplate.Helpers;

namespace MethodGeneratorTemplate.App;

public class GeneratedMethod : Equatable {
    public string MethodName { get; }
    public string? GenericName { get; }
    public bool IsGeneric => GenericName is not null;
    public string Format { get; }
    public string Result { get; }
    public List<string> Parameters { get; }

    public GeneratedMethod(string methodName, string format, List<string>? parameters, string? genericName) {
        if (string.IsNullOrWhiteSpace(methodName)) throw new ArgumentNullException(nameof(methodName));
        if (string.IsNullOrWhiteSpace(format)) throw new ArgumentNullException(nameof(format));
        
        Format = format;
        GenericName = genericName;
        MethodName = methodName;
        Parameters = parameters ?? [];

        var formatResult = string.Format(format, Parameters.ToArray());
        if (IsGeneric) {
            formatResult = formatResult.Replace(methodName, $"{methodName}<{genericName}>");
        }

        Result = formatResult;
    }

    protected override IEnumerable<object?> GetEqualityComponents() {
        yield return Result;
    }
}