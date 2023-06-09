using Hangfire;
using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ScheduledJobs;

public static class HangfireExtensions
{
    public static IServiceCollection AddHangfireService(this IServiceCollection services)
    {
        var settings = services.GetOptions<HangFireSettings>("HangFireSettings");
        if (settings == null || settings.Storage == null ||
            string.IsNullOrEmpty(settings.Storage.ConnectionString))
            throw new Exception("HangFireSettings is not configured properly!");

        services.AddHangfireServer(serverOptions => { serverOptions.ServerName = settings.ServerName; });
        
        return services;
    }
}
