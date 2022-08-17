using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnRail.Extensions.Map;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;

namespace OnRail.Extensions.Configuration;

public static class ConfigurationExtensions {
    public static Result<T> GetConfig<T>(this IConfiguration @this, int numOfTry = 1) =>
        TryExtensions.Try(() => @this.GetSection(typeof(T).Name)
            .Get<T>(), numOfTry);

    public static Result<IConfiguration> AddConfig<T>(
        this IConfiguration @this,
        IServiceCollection services,
        int numOfTry = 1) where T : class =>
        TryExtensions.Try(() => @this
            .GetConfig<T>()
            .OnSuccess(services.AddSingleton)
            .Map(@this), numOfTry);

    public static Result<IConfiguration> AddConfig<T>(
        this Result<IConfiguration> @this,
        IServiceCollection services,
        int numOfTry = 1) where T : class
        => @this.OnSuccess(configuration => configuration.AddConfig<T>(services), numOfTry);
}