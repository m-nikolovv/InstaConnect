using System.Text;

using Bogus;

using InstaConnect.Common.Domain.Features.Requests.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Tests.Features.Utilities;

public abstract class DataFaker
{
	private const int DefaultStringLength = 100;

	private static readonly Faker _faker = new();

	public static IFormFile GetFormFile()
	{
		var name = _faker.System.FileName();
		var formFile = Mocker.Mock<IFormFile>();

		var fileContent = Encoding.UTF8.GetBytes("This is a test file.");
		var stream = new MemoryStream(fileContent)
		{
			Position = 0
		};

		formFile.OpenReadStream().ReturnsResponse(stream);
		formFile.Name.ReturnsResponse(name);
		formFile.FileName.ReturnsResponse(name);
		formFile.ContentType.ReturnsResponse("text/plain");
		formFile.Length.ReturnsResponse(stream.Length);

		return formFile;
	}

	public static string GetGuid()
	{
		return _faker.Random.Guid().ToString();
	}

	public static DateTimeOffset GetSoonDate()
	{
		return _faker.Date.SoonOffset();
	}

	public static DateTimeOffset GetFutureDate(DateTimeOffset date)
	{
		return _faker.Date.FutureOffset(refDate: date);
	}

	public static DateTimeOffset GetPastDate(DateTimeOffset date)
	{
		return _faker.Date.PastOffset(refDate: date);
	}

	public static string GetUrl()
	{
		return _faker.Internet.Url();
	}

	public static string GetEmail(int maxLength, int minLength = default)
	{
		const string Format = "{0}@{1}";

		var name = GetAverageString(maxLength, minLength);
		var domain = _faker.Internet.DomainName();

		return Format.FormatCurrentCulture(name, domain).Substring(domain.Length - 1);
	}

	public static string GetString(int length = DefaultStringLength)
	{
		return _faker.Random.AlphaNumeric(length);
	}

	public static string GetAverageString(int maxLength, int minLength = default)
	{
		return _faker.Random.AlphaNumeric(GetAverageNumber(maxLength, minLength));
	}

	public static int GetRandomNumber()
	{
		return _faker.Random.Number();
	}

	public static int GetAverageNumber(int maxLength, int minLength)
	{
		return (maxLength + minLength) / 2;
	}

	public static string GetPrefixString(string? value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return string.Empty;
		}

		return value[..(value.Length / 2)];
	}

	public static string GetAverageWithPrefixString(string? value, int maxLength, int minLength = default)
	{
		var average = GetAverageString(maxLength, minLength);

		if (string.IsNullOrEmpty(value))
		{
			return average;
		}

		var mid = value.Length / 2;

		return string.Concat(
			value.AsSpan(0, mid),
			average.AsSpan(mid)
		);
	}

	public static string GetDifferentCaseString(string? value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return string.Empty;
		}

		return value.ToUpperCurrentCulture();
	}

	public static TEnum GetEmptyEnum<TEnum>()
		where TEnum : Enum
	{
		return default!;
	}

	public static CommonSortOrder GetSortOrder()
	{
		const CommonSortOrder SortOrder = CommonSortOrder.Ascending;

		return SortOrder;
	}
}
