using Microsoft.Extensions.DependencyInjection;
using Rebus.Config;
using Rebus.ServiceProvider;
using Rebus.RabbitMq;
using System;

namespace Ambev.DeveloperEvaluation.Common.Configuration
{
    public static class RebusConfig
    {
        public static void AddRebusConfiguration(this IServiceCollection services, string rabbitMqConnectionString, string queueName)
        {
            if (string.IsNullOrEmpty(rabbitMqConnectionString))
                throw new ArgumentNullException(nameof(rabbitMqConnectionString));

            if (string.IsNullOrEmpty(queueName))
                throw new ArgumentNullException(nameof(queueName));

            // Configurando o Rebus com RabbitMq
            services.AddRebus(configure => configure
                .Transport(t => t.UseRabbitMq(rabbitMqConnectionString, queueName))
                .Logging(l => l.Console()));
        }
    }
}
