using System;

namespace Abstractions.DateAndTime.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTimeService()
        {
        }

        public DateTime Now()
        {
            return DateTime.Now;
        }

        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }

        public DateTime Today()
        {
            return DateTime.Today;
        }
    }
}