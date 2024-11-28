namespace MethodGeneratorTemplate.Helpers;

public abstract class Equatable {
    protected abstract IEnumerable<object?> GetEqualityComponents();

    public override bool Equals(object? obj) {
        if (obj is null || obj.GetType() != GetType()) {
            return false;
        }

        var valueObject = (Equatable)obj;

        return GetEqualityComponents()
            .SequenceEqual(valueObject.GetEqualityComponents());
    }

    public override int GetHashCode() {
        return GetEqualityComponents()
            .Aggregate(0, (hash, obj) => HashCode.Combine(hash, obj != null ? obj.GetHashCode() : 0));
    }

    public static bool operator ==(Equatable? left, Equatable? right) {
        if (left is null && right is null) {
            return true;
        }

        if (left is null || right is null) {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(Equatable left, Equatable right) {
        return !(left == right);
    }
}