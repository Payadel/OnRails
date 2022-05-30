namespace OnRail.Extensions;

// public static class ConfigurationExtensions {
//     public static T GetConfig<T>(
//         this IConfiguration @this) =>
//         @this.GetSection(typeof(T).Name)
//             .Get<T>();
//
//     public static Result<IConfiguration> AddConfig<T>(
//         this IConfiguration @this,
//         IServiceCollection services) where T : class =>
//         @this
//             .GetConfig<T>()
//             .TryTee(services.AddSingleton!)
//             .MapResult(@this);
//
//     public static Result<IConfiguration> AddConfig<T>(
//         this Result<IConfiguration> @this,
//         IServiceCollection services) where T : class => @this
//         .OnSuccess(configuration => configuration.AddConfig<T>(services));
// }