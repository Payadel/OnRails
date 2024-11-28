using MethodGenerator.Helpers;
using MethodGenerator.Settings;
using Microsoft.Extensions.Logging;

namespace MethodGenerator.App;

public class App(ILogger<App> logger, AppSettings settings) {
    public async Task RunAsync() {
        var generatorCreators = GetGenerators();

        foreach (var generatorFunc in generatorCreators) {
            var generator = generatorFunc();
            logger.LogInformation("Generating methods for {MethodName}", generator.MethodName);

            var methods = GetMethodResults(generator);
            logger.LogInformation("{MethodsCount} methods generated.", methods.Count);

            var content = string.Join("\n\n", methods);

            var outputFileName = $"{generator.MethodName}.txt";
            var outputPath = Path.Combine(settings.Output, outputFileName);

            await RegionFileManager.UpdateOrAddRegionAsync(outputPath, generator.RegionName, content);
            logger.LogInformation("{MethodName} methods saved to {path}", generator.MethodName, outputPath);
        }
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

    private static List<string> GetMethodResults(MethodGenerator generator) {
        return generator.GenerateMethodSignature()
            .Select(method => method.Result).ToList();
    }
}