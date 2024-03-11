using System.Diagnostics;

namespace OnRails.Utilities;

internal static class StackTraceUtility {
    public static StackTrace RemoveFrames(this StackTrace originalStackTrace, string appNamespace) {
        // Get the frames from the original stack trace
        var originalFrames = originalStackTrace.GetFrames();

        var filteredFrames = originalFrames
            .Where(frame => frame.GetMethod()?.DeclaringType?.Namespace != null &&
                            !frame.GetMethod()!.DeclaringType!.Namespace!.StartsWith(appNamespace))
            .ToArray();

        // Create a new stack trace with the filtered frames
        var filteredStackTrace = new StackTrace(filteredFrames);

        return filteredStackTrace;
    }
}