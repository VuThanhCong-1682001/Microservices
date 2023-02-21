using Contracts.Common.Interfaces;
using Contracts.Messages;
using Infrastructure.Common;
using Infrastructure.Configurations;
using Infrastructure.Messages;

namespace Ordering.API.Extensions
{
    public static class ServiceExtensions
    {
        internal static IServiceCollection AddConfigurationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var emailSettings = configuration.GetSection(nameof(SMTPEmailSetting))
                                             .Get<SMTPEmailSetting>();
            services.AddSingleton(emailSettings);
            services.AddScoped<IMessageProducer, RabbitMQProducer>();
            services.AddScoped<ISerializeService, SerializeService>();
            return services;
        }
    }
}
