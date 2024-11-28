using System.Text.RegularExpressions;

namespace MethodGenerator.Helpers;

public static class PatternChecker {
    public static bool IsGeneric(string input, string genericName) {
        if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(genericName))
            return false;

        var regex = new Regex($@"<\s*{genericName}\s*(?:,|>)");
        return regex.IsMatch(input);
    }
}