using System.Diagnostics;

namespace OnRails.Models;

[DebuggerStepThrough]
public record KeyValue<T>(string Key, T Value) {
    public override string ToString() {
        return $"{Key}: {Value}";
    }
}