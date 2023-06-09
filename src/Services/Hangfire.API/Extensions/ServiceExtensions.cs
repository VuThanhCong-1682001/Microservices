namespace Hangfire.API.Extensions;

public static class ServiceExtensions
{
    internal static IServiceCollection AddConfigurationSettings(this IServiceCollection services,
       IConfiguration configuration)
    {
        var hangFireSettings = configuration.GetSection(nameof(HangFireSettings))
            .Get<HangFireSettings>();
        services.AddSingleton(hangFireSettings);

        return services;
    }
}
