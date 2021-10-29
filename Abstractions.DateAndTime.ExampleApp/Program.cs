using Abstractions.DateAndTime.ExampleApp.Helpers;
using Abstractions.DateAndTime.ExampleApp.Managers;
using Abstractions.DateAndTime.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Abstractions.DateAndTime.ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var outputManager = GetServiceProvider().GetRequiredService<IConsoleOutputManager>();

            outputManager.PrintMessage("The current date and time is:");
            outputManager.PrintCurrentDateTime();

            outputManager.PrintMessage("The current offset date and time is:");
            outputManager.PrintCurrentOffsetDateTime();
        }

        private static IServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<IConsoleOutputManager, ConsoleOutputManager>()
                .AddSingleton<IDateTimeHelper, DateTimeHelper>()
                .AddDateTimeService()
                .AddDateTimeOffsetService()
                .BuildServiceProvider();
        }
    }
}