using Abstractions.DateAndTime.Services;
using System;

namespace Abstractions.DateAndTime.ExampleApp.Helpers
{
    public class DateTimeHelper : IDateTimeHelper
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IDateTimeOffsetService _dateTimeOffsetService;

        public DateTimeHelper(IDateTimeService dateTimeService, IDateTimeOffsetService dateTimeOffsetService)
        {
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
            _dateTimeOffsetService = dateTimeOffsetService ?? throw new ArgumentNullException(nameof(dateTimeOffsetService));
        }

        public string FormatCurrentDateTime()
        {
            return _dateTimeService.Now().ToString();
        }

        public string FormatCurrentOffsetDateTime()
        {
            return _dateTimeOffsetService.Now().ToString();
        }
    }
}