using MethodGeneratorTemplate.Helpers;

namespace MethodGeneratorTemplate.App;
public abstract class MethodGenerator {
    protected MethodGenerator(string methodName, string genericName) {
        if (string.IsNullOrWhiteSpace(methodName)) throw new ArgumentNullException(nameof(methodName));
        if (string.IsNullOrWhiteSpace(genericName)) throw new ArgumentNullException(nameof(genericName));
        
        MethodName = methodName;
        GenericName = genericName;
    }
    public string MethodName { get; set; }
    public string GenericName { get; set; }
    
    // Generate all combinations of parameter types
    protected List<GeneratedMethod> GenerateMethodSignature(List<HashSet<string>> parameters, string methodFormat) {
        // Generate all combinations of parameter types
        var parameterCombinations = CartesianProduct(parameters);

        var generatedMethods = from combination in parameterCombinations
            let isGeneric = combination.Any(param => PatternChecker.IsGeneric(param, GenericName))
            select new GeneratedMethod(MethodName, methodFormat, combination,
                isGeneric ? GenericName : null);

        return generatedMethods.ToList();
    }

    // Cartesian product logic for parameter combinations
    private IEnumerable<List<string>> CartesianProduct(List<HashSet<string>> lists) {
        IEnumerable<List<string>> result = new List<List<string>> { new() };

        foreach (var list in lists) {
            result = result.SelectMany(
                acc => list.Select(item => new List<string>(acc) { item })
            );
        }
        return result.Where(ValidCombination);
    }

    // Abstract method to validate a combination
    protected abstract bool ValidCombination(IReadOnlyList<string> parameters);

    public abstract List<GeneratedMethod> GenerateMethodSignature();
}