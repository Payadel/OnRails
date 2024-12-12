namespace OnRails.Helpers;

internal static class AppNamespace {
    public static string GetLibraryNamespace() {
        return typeof(AppNamespace).Namespace ?? "OnRails";
    }
}