using System.Reflection;

namespace OnRails.Helpers;

internal static class PropertyHelpers {
    public static List<T> GetProperties<T>(this object detail, string? name) {
        if (string.IsNullOrWhiteSpace(name) && detail is T targetObject) {
            // The whole object is our target
            return [targetObject];
        }

        var properties = GetProperties<T>(detail);
        if (!string.IsNullOrWhiteSpace(name)) {
            properties = properties.Where(prop => prop.Name == name);
        }

        var matchingObjects = properties
            .Select(prop => prop.GetValue(detail))
            .Where(obj => obj != null)
            .OfType<T>()
            .ToList();

        return matchingObjects;
    }

    private static IEnumerable<PropertyInfo> GetProperties<T>(object detail) {
        var properties = detail
            .GetType()
            .GetProperties()
            .Where(prop => prop.PropertyType == typeof(T));
        return properties;
    }
}