using Abstractions.DateAndTime.Services;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace Abstractions.DateAndTime.Tests
{
    public class DateTimeServiceTests
    {
        private readonly IDateTimeService _dateTimeService;

        public DateTimeServiceTests()
        {
            _dateTimeService = A.Fake<IDateTimeService>();
        }

        [Test]
        public void IDateTimeService_AbstractsAllStaticDateTimeProperties()
        {
            var dateTimeStaticProperties = typeof(DateTime).GetProperties(BindingFlags.Public | BindingFlags.Static);
            var dateTimeServiceMethods = typeof(IDateTimeService).GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.GetParameters().Length == 0)
                .ToList();

            Assert.That(
                dateTimeStaticProperties.Select(m => m.Name),
                Is.SubsetOf(dateTimeServiceMethods.Select(m => m.Name)),
                $"Not all static {nameof(DateTime)} properties are abstracted.");

            foreach (var property in dateTimeStaticProperties)
            {
                var abstraction = dateTimeServiceMethods.Single(m => m.Name == property.Name);

                Assert.That(
                    property.PropertyType,
                    Is.EqualTo(abstraction.ReturnType),
                    $"'{property.Name}' abstraction return type: '{abstraction.ReturnType}' does not match that of the {nameof(DateTime)} property: '{property.PropertyType}'.");
            }
        }

        [Test]
        public void IDateTimeService_DateTimeNowCanBeFaked()
        {
            // Arrange
            var targetDateTime = new DateTime(2021, 01, 02, 12, 34, 56);
            A.CallTo(() => _dateTimeService.Now()).Returns(targetDateTime);

            // Act
            var fakedDateTimeNow = _dateTimeService.Now();

            // Assert
            Assert.That(
                fakedDateTimeNow,
                Is.EqualTo(targetDateTime),
                $"{nameof(IDateTimeService)}.{nameof(IDateTimeService.Now)} was not successfully faked.");
        }

        [Test]
        public void IDateTimeService_DateTimeUtcNowCanBeFaked()
        {
            // Arrange
            var targetDateTime = new DateTime(2021, 01, 02, 12, 34, 56);
            A.CallTo(() => _dateTimeService.UtcNow()).Returns(targetDateTime);

            // Act
            var fakedDateTimeUtcNow = _dateTimeService.UtcNow();

            // Assert
            Assert.That(
                fakedDateTimeUtcNow,
                Is.EqualTo(targetDateTime),
                $"{nameof(IDateTimeService)}.{nameof(IDateTimeService.UtcNow)} was not successfully faked.");
        }

        [Test]
        public void IDateTimeService_DateTimeTodayCanBeFaked()
        {
            // Arrange
            var targetDate = new DateTime(2021, 01, 02);
            A.CallTo(() => _dateTimeService.Today()).Returns(targetDate);

            // Act
            var fakedDateTimeToday = _dateTimeService.Today();

            // Assert
            Assert.That(
                fakedDateTimeToday,
                Is.EqualTo(targetDate),
                $"{nameof(IDateTimeService)}.{nameof(IDateTimeService.Today)} was not successfully faked.");
        }
    }
}