using MethodGenerator.Generators;
using MethodGenerator.Settings;
using Microsoft.Extensions.Logging;

namespace MethodGenerator.App;

public class App(ILogger<App> logger, AppSettings settings) {
    public async Task RunAsync() {
        List<Func<MethodGenerator>> generatorCreators = [
            () => new OnSuccessOperateWhen(),
        ];

        foreach (var generatorFunc in generatorCreators) {
            var generator = generatorFunc();

            logger.LogInformation("Generating methods for {MethodName}", generator.MethodName);

            var methods = GetMethodResults(generator);
            logger.LogInformation("{MethodsCount} methods generated.", methods.Count);

            var methodStr = string.Join("\n\n", methods);

            await SaveOutputs(generator.MethodName, methodStr);
        }
    }

    private async Task SaveOutputs(string methodName, string methodStr) {
        var outputFileName = $"{methodName}.cs";
        await File.WriteAllTextAsync(Path.Combine(settings.Output, outputFileName), methodStr);
    }

    private static List<string> GetMethodResults(MethodGenerator generator) {
        return generator.GenerateMethodSignature()
            .Select(method => method.Result).ToList();
    }
}