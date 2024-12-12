namespace OnRails.Models;

public class FieldErrors {
    public string Name { get; }
    public List<string> Messages { get; }

    public FieldErrors(string name, string? message) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        Name = name;
        Messages = [];
        if (!string.IsNullOrWhiteSpace(message))
            Messages.Add(message);
    }

    public FieldErrors(string name, List<string> messages) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        Name = name;
        Messages = messages;
    }

    public override bool Equals(object? obj) {
        if (obj is FieldErrors other) {
            return Name == other.Name;
        }

        return false;
    }

    public override int GetHashCode() {
        return Name.GetHashCode();
    }

    public override string ToString() => $"{Name}:\n\t{string.Join("\n\t", Messages)}";
}