using System.Diagnostics;

namespace OnRails.Utilities;

[DebuggerStepThrough]
public record KeyValue<T>(string Key, T Value) {
    public override string ToString() {
        return $"{Key}: {Value}";
    }
}

internal static class KeyValueExtensions {
    public static Dictionary<string, T> ToDictionary<T>(this IEnumerable<KeyValue<T>> keyValues) =>
        keyValues.Select(error => (error.Key, error.Value)).ToDictionary();
}