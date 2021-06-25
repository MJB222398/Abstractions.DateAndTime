![CI Build](https://github.com/MJB222398/Abstractions.DateAndTime/actions/workflows/ci.yml/badge.svg)

# Abstractions.DateAndTime
A simple library for abstracting the static properties in .NET's `System.DateTime` and `System.DateTimeOffset`.

The structs `System.DateTime` and `System.DateTimeOffset` each have a few static properties that are abstracted here in the following interfaces and their implementations:

- `IDateTimeService` - abstracts the `Now`, `UtcNow` and `Today` properties from `System.DateTime`.
- `IDateTimeOffsetService` - abstracts the `Now` and `UtcNow` properties from `System.DateTimeOffset`.

These abstractions can be faked, allowing for methods that access the system's date and time, to be unit tested. 

## Usage

In your application's services, wire up the dependencies that you require, using the extension methods in `Abstractions.DateAndTime.Extensions.ServiceCollectionExtensions`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddDateTimeService();
    services.AddDateTimeOffsetService();
    ...
}
```

The appropriate service can then be injected wherever it is required and then wherever `DateTime.Now`, `DateTime.UtcNow`, `DateTime.Today`, `DateTimeOffset.Now` or `DateTimeOffset.UtcNow` are used, replace them with a call to the corresponding abstraction:

```csharp
private readonly IDateTimeService _dateTimeService;

public DateTimeHelper(IDateTimeService dateTimeService)
{
    _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
}

public string FormatCurrentDateTime()
{
    // return DateTime.Now.ToString();
    return _dateTimeService.Now().ToString();
}
```

Such code can then be unit tested by mocking the `IDateTimeService` or `IDateTimeOffsetService` instances:

```csharp
private readonly IDateTimeHelper _dateTimeHelper;
private readonly IDateTimeService _dateTimeService;

public DateTimeHelperTests()
{
    _dateTimeService = A.Fake<IDateTimeService>();
    _dateTimeHelper = new DateTimeHelper(_dateTimeService);
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
```

The above snippets are part of an example console application that consumes these abstractions and which can be found in this same repository [here](https://github.com/MJB222398/Abstractions.DateAndTime/tree/main/Abstractions.DateAndTime.ExampleApp)
