using System;

namespace Abstractions.DateAndTime.Services
{
    public interface IDateTimeService
    {
        DateTime Now();

        DateTime Today();

        DateTime UtcNow();
    }
}