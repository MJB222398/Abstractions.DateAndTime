using Abstractions.DateAndTime.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Abstractions.DateAndTime.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDateTimeService(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IDateTimeService, DateTimeService>();

            return services;
        }

        public static IServiceCollection AddDateTimeOffsetService(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IDateTimeOffsetService, DateTimeOffsetService>();

            return services;
        }
    }
}