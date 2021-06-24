using Abstractions.DateAndTime.Services;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using TimeZoneConverter;

namespace Abstractions.DateAndTime.Tests
{
    public class DateTimeOffsetServiceTests
    {
        private readonly IDateTimeOffsetService _dateTimeOffsetService;

        public DateTimeOffsetServiceTests()
        {
            _dateTimeOffsetService = A.Fake<IDateTimeOffsetService>();
        }

        [Test]
        public void IDateTimeOffsetService_AbstractsAllStaticDateTimeOffsetProperties()
        {
            var dateTimeOffsetStaticProperties = typeof(DateTimeOffset).GetProperties(BindingFlags.Public | BindingFlags.Static);
            var dateTimeOffsetServiceMethods = typeof(IDateTimeOffsetService).GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.GetParameters().Length == 0);

            Assert.That(
                dateTimeOffsetStaticProperties.Select(m => m.Name),
                Is.SubsetOf(dateTimeOffsetServiceMethods.Select(m => m.Name)),
                $"Not all static {nameof(DateTimeOffset)} properties are abstracted.");

            foreach (var property in dateTimeOffsetStaticProperties)
            {
                var abstraction = dateTimeOffsetServiceMethods.Single(m => m.Name == property.Name);

                Assert.That(
                    property.PropertyType,
                    Is.EqualTo(abstraction.ReturnType),
                    $"'{property.Name}' abstraction return type: '{abstraction.ReturnType}' does not match that of the {nameof(DateTimeOffset)} property: '{property.PropertyType}'.");
            }
        }

        [Test]
        public void IDateTimeOffsetService_DateTimeOffsetNowCanBeFaked()
        {
            // Arrange
            var pacificStandardTimeUtcOffset = TZConvert.GetTimeZoneInfo("Pacific Standard Time").BaseUtcOffset;
            var targetDateTimeOffset = new DateTimeOffset(2021, 01, 02, 12, 34, 56, pacificStandardTimeUtcOffset);
            A.CallTo(() => _dateTimeOffsetService.Now()).Returns(targetDateTimeOffset);

            // Act
            var fakedDateTimeOffsetNow = _dateTimeOffsetService.Now();

            // Assert
            Assert.That(
                fakedDateTimeOffsetNow,
                Is.EqualTo(targetDateTimeOffset),
                $"{nameof(IDateTimeOffsetService)}.{nameof(IDateTimeOffsetService.Now)} was not successfully faked.");
        }

        [Test]
        public void IDateTimeOffsetService_DateTimeOffsetUtcNowCanBeFaked()
        {
            // Arrange
            var tokyoStandardTimeUtcOffset = TZConvert.GetTimeZoneInfo("Tokyo Standard Time").BaseUtcOffset;
            var targetDateTimeOffset = new DateTimeOffset(2021, 01, 02, 12, 34, 56, tokyoStandardTimeUtcOffset);
            A.CallTo(() => _dateTimeOffsetService.UtcNow()).Returns(targetDateTimeOffset);

            // Act
            var fakedDateTimeOffsetUtcNow = _dateTimeOffsetService.UtcNow();

            // Assert
            Assert.That(
                fakedDateTimeOffsetUtcNow,
                Is.EqualTo(targetDateTimeOffset),
                $"{nameof(IDateTimeOffsetService)}.{nameof(IDateTimeOffsetService.UtcNow)} was not successfully faked.");
        }
    }
}