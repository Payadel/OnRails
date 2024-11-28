using System.Reflection;
using System.Text;

namespace MethodGenerator.Settings;

public class AppSettings {
    public string Output { get; set; } = default!;

    public override string ToString() {
        var sb = new StringBuilder();
        var properties = GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties) {
            // Skip properties with the SecureConfig attribute
            if (property.GetCustomAttribute<SecureConfigAttribute>() != null)
                continue;

            var value = property.GetValue(this);
            var formattedValue = value switch {
                null => "null",
                IEnumerable<string> list => string.Join(", ", list),
                _ => value.ToString()
            };

            sb.AppendLine($"{property.Name}: {formattedValue}");
        }

        return sb.ToString();
    }
}