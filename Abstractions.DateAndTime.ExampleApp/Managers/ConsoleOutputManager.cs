using Abstractions.DateAndTime.ExampleApp.Helpers;
using System;

namespace Abstractions.DateAndTime.ExampleApp.Managers
{
    public class ConsoleOutputManager : IConsoleOutputManager
    {
        private readonly IDateTimeHelper _dateTimeHelper;

        public ConsoleOutputManager(IDateTimeHelper dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper ?? throw new ArgumentNullException(nameof(dateTimeHelper));
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintCurrentDateTime()
        {
            Console.WriteLine(_dateTimeHelper.FormatCurrentDateTime());
        }

        public void PrintCurrentOffsetDateTime()
        {
            Console.WriteLine(_dateTimeHelper.FormatCurrentOffsetDateTime());
        }
    }
}