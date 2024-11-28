namespace MethodGeneratorTemplate.Helpers;

public static class TryHelpers {
    public static string? Try(this Action action) {
        try {
            action();
            return null;
        }
        catch (Exception e) {
            return e.ToString();
        }
    }
}