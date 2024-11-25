using System.Diagnostics;

namespace OnRails.Utilities;

internal static class StackTraceUtility {
    public static StackTrace RemoveFrames(this StackTrace originalStackTrace, string appNamespace) {
        ArgumentNullException.ThrowIfNull(originalStackTrace);
        if (string.IsNullOrWhiteSpace(appNamespace))
            throw new ArgumentException("Namespace cannot be null or empty", nameof(appNamespace));

        // Filter out frames where the namespace starts with the specified appNamespace
        var filteredFrames = originalStackTrace.GetFrames()
            .Where(frame => {
                var methodNamespace = frame.GetMethod()?.DeclaringType?.Namespace;
                return methodNamespace != null &&
                       !methodNamespace.StartsWith(appNamespace, StringComparison.CurrentCultureIgnoreCase);
            })
            .ToArray();

        return new StackTrace(filteredFrames);
    }
}