using Abstractions.DateAndTime.ExampleApp.Helpers;
using Abstractions.DateAndTime.Services;
using FakeItEasy;
using NUnit.Framework;
using System;

namespace Abstractions.DateAndTime.ExampleApp.Tests
{
    public class DateTimeHelperTests
    {
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IDateTimeService _dateTimeService;

        public DateTimeHelperTests()
        {
            _dateTimeService = A.Fake<IDateTimeService>();
            _dateTimeHelper = new DateTimeHelper(_dateTimeService, A.Fake<IDateTimeOffsetService>());
        }

        [Test]
        public void FormatCurrentDateTime_ReturnsCorrectlyFormattedDateTime()
        {
            // ARRANGE
            A.CallTo(() => _dateTimeService.Now()).Returns(new DateTime(2021, 6, 20, 13, 21, 04));

            // ACT
            var formattedCurrentDateTime = _dateTimeHelper.FormatCurrentDateTime();

            //ASSERT
            Assert.That(formattedCurrentDateTime, Is.EqualTo("20/06/2021 13:21:04"));
        }
    }
}