namespace OnRails.Utilities;

public record KeyValue(string Key, string Value) {
    public override string ToString() {
        return $"{Key}: {Value}";
    }
}

internal static class KeyValueExtensions {
    public static Dictionary<string, string> ToDictionary(this IEnumerable<KeyValue> keyValues) =>
        keyValues.Select(error => (error.Key, error.Value)).ToDictionary();
}