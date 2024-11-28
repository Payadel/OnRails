using System.CommandLine;
using System.IO.Abstractions;
using MethodGenerator.Helpers;
using MethodGenerator.Settings;

namespace MethodGenerator;

public static class CommandLine {
    public static Task<int> InvokeAsync(string[] args, AppSettings settings, IFileSystem fileSystem) {
        var outputOption = new Option<string>(
            ["-o", "--output"],
            () => settings.Output,
            "Output Path"
        );
        outputOption.AddValidator(result => {
            var value = result.GetValueOrDefault<string>();
            if (string.IsNullOrWhiteSpace(value))
                result.ErrorMessage = "The output value is required.";
            else if (File.Exists(value))
                result.ErrorMessage = "Output value is not valid.";
            else if (!Directory.Exists(value)) {
                var error = TryHelpers.Try(() => Directory.CreateDirectory(value));
                if (!string.IsNullOrWhiteSpace(error))
                    result.ErrorMessage = error;
            }
        });

        var rootCommand = new RootCommand("C# command-line app that generates methods.") {
            outputOption,
        };

        rootCommand.SetHandler((output) => { settings.Output = output; }, outputOption);

        // Invoke the command
        return rootCommand.InvokeAsync(args);
    }
}