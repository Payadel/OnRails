using MethodGenerator.Settings;
using Microsoft.Extensions.Logging;

namespace MethodGenerator.App;

public class App(ILogger<App> logger, AppSettings settings) {
    public async Task RunAsync() {
        var generatorCreators = GetGenerators();

        await GenerateAndSaveMethods(generatorCreators);
    }

    private static List<Func<MethodGenerator>> GetGenerators() {
        // Get all assemblies currently loaded
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        // Find all classes that inherit from MethodGenerator within the specific namespace
        var methodGeneratorTypes = assemblies
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type is { IsClass: true, IsAbstract: false }
                           && type.IsSubclassOf(typeof(MethodGenerator))
                           && (type.Namespace?.StartsWith("MethodGenerator.Generators") ?? false))
            .ToList();

        // Map each type to a Func<MethodGenerator> that calls its constructor
        var generatorCreators = methodGeneratorTypes
            .Select(type => (Func<MethodGenerator>)(() => (MethodGenerator)Activator.CreateInstance(type)))
            .ToList();
        return generatorCreators;
    }

    private async Task GenerateAndSaveMethods(List<Func<MethodGenerator>> generatorCreators) {
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
        var outputFileName = $"{methodName}.txt";
        var outputPath = Path.Combine(settings.Output, outputFileName);
        await File.WriteAllTextAsync(outputPath, methodStr);

        logger.LogInformation("{MethodName} methods saved to {path}", methodName, outputPath);
    }

    private static List<string> GetMethodResults(MethodGenerator generator) {
        return generator.GenerateMethodSignature()
            .Select(method => method.Result).ToList();
    }
}