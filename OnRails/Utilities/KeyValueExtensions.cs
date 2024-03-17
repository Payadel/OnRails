using OnRails.Models;

namespace OnRails.Utilities;

public static class KeyValueExtensions {
    public static Dictionary<string, T> ToDictionary<T>(this IEnumerable<KeyValue<T>> keyValues)
        => keyValues
            .Select(error => (error.Key, error.Value))
            .ToDictionary();
}