using System;

namespace Abstractions.DateAndTime.Services
{
    public interface IDateTimeOffsetService
    {
        DateTimeOffset Now();

        DateTimeOffset UtcNow();
    }
}