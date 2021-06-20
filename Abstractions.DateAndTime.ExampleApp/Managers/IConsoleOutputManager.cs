namespace Abstractions.DateAndTime.ExampleApp.Managers
{
    public interface IConsoleOutputManager
    {
        void PrintCurrentDateTime();

        void PrintCurrentOffsetDateTime();

        void PrintMessage(string message);
    }
}