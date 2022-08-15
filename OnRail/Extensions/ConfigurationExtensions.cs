using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnRail.Extensions.Map;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;

namespace OnRail.Extensions;

public static class ConfigurationExtensions {
    public static Result<T> GetConfig<T>(
        this IConfiguration @this) =>
        TryExtensions.Try(() => @this.GetSection(typeof(T).Name)
            .Get<T>());

    public static Result<IConfiguration> AddConfig<T>(
        this IConfiguration @this,
        IServiceCollection services) where T : class =>
        @this
            .GetConfig<T>()
            .OnSuccess(services.AddSingleton)
            .Map(@this);

    public static Result<IConfiguration> AddConfig<T>(
        this Result<IConfiguration> @this,
        IServiceCollection services) where T : class => @this
        .OnSuccess(configuration => configuration.AddConfig<T>(services));
}