using System.Text.RegularExpressions;

namespace MethodGenerator.Helpers;

public static class PatternChecker {
    private const string RegexFormat = @"<\s*{0}\s*(?:,|>)|{0}";

    public static bool IsGeneric(string input, HashSet<string> genericNames) {
        if (string.IsNullOrWhiteSpace(input) || genericNames.Count == 0)
            return false;

        return genericNames.Any(genericName => IsGeneric(input, genericName));
    }

    public static bool IsGeneric(string input, string genericName) {
        if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(genericName))
            return false;

        var regex = new Regex(string.Format(RegexFormat, genericName));
        return regex.IsMatch(input);
    }

    public static HashSet<string> GetExistGenerics(List<string> parameters, HashSet<string> genericNames) {
        if (parameters.Count == 0 || genericNames.Count == 0) return [];

        var exist = from genericName in genericNames
                    let regex = new Regex(string.Format(RegexFormat, genericName))
                    where parameters.Any(regex.IsMatch)
                    select genericName;

        return exist.ToHashSet();
    }
}