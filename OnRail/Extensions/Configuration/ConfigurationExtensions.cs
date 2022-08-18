using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnRail.Extensions.Map;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.Configuration;

public static class ConfigurationExtensions {
    public static Result<T> GetConfig<T>(this IConfiguration source, int numOfTry = 1) =>
        TryExtensions.Try(() => source.GetSection(typeof(T).Name)
            .Get<T>(), numOfTry);

    public static Result<IConfiguration> AddConfig<T>(
        this IConfiguration source,
        IServiceCollection services,
        int numOfTry = 1
    ) where T : class =>
        TryExtensions.Try(() => source
            .GetConfig<T>()
            .OnSuccess(services.AddSingleton)
            .Map(source), numOfTry);

    public static Result<IConfiguration> AddConfig<T>(
        this Result<IConfiguration> source,
        IServiceCollection services,
        int numOfTry = 1
    ) where T : class
        => source.OnSuccess(configuration => configuration.AddConfig<T>(services), numOfTry);
}