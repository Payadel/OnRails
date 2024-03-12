namespace OnRails.Utilities;

public record KeyValue(string Key, string Value) {
    public override string ToString() {
        return $"{Key}: {Value}";
    }
}