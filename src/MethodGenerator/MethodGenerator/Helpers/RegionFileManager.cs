using System.Text;
using System.Text.RegularExpressions;

namespace MethodGenerator.Helpers;

public static class RegionFileManager {
    public static string WrapContentWithRegion(string regionName, string content) =>
        $"#region {regionName}\n\n{content}\n\n#endregion\n\n";

    public static async Task UpdateOrAddRegionAsync(string filePath, string regionName, string content) {
        var contentWithRegion = WrapContentWithRegion(regionName, content);

        if (!File.Exists(filePath)) {
            // If the file does not exist, create it and write the region with content
            await using var writer = new StreamWriter(filePath, false);
            await writer.WriteLineAsync(contentWithRegion);
            return;
        }

        // Read the entire file content
        var fileContent = await File.ReadAllTextAsync(filePath);

        // Regex to match the specific region
        var pattern = $@"(?<=#region {Regex.Escape(regionName)}\n).*?(?=\n#endregion)";
        var match = Regex.Match(fileContent, pattern, RegexOptions.Singleline);

        if (match.Success) {
            // Region exists, replace the content
            fileContent = Regex.Replace(
                fileContent,
                pattern,
                $"\n{content}\n",
                RegexOptions.Singleline
            );
        }
        else {
            // Region does not exist, append it
            var builder = new StringBuilder(fileContent);
            builder.AppendLine(contentWithRegion);
            fileContent = builder.ToString();
        }

        // Write updated content back to the file
        await File.WriteAllTextAsync(filePath, fileContent);
    }
}