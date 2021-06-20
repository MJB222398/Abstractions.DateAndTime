using System;

namespace Abstractions.DateAndTime.Services
{
    public class DateTimeOffsetService : IDateTimeOffsetService
    {
        public DateTimeOffsetService()
        {
        }

        public DateTimeOffset Now()
        {
            return DateTimeOffset.Now;
        }

        public DateTimeOffset UtcNow()
        {
            return DateTimeOffset.UtcNow;
        }
    }
}