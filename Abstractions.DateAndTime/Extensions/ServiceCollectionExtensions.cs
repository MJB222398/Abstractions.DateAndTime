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

            return services.AddSingleton<IDateTimeService, DateTimeService>();
        }

        public static IServiceCollection AddDateTimeOffsetService(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddSingleton<IDateTimeOffsetService, DateTimeOffsetService>();
        }
    }
}