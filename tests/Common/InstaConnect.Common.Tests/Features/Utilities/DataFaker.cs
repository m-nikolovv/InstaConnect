using System.Net.Mime;

using Bogus;

using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Common.Tests.Features.Utilities;

public abstract class DataFaker
{
	private static readonly Faker _faker = new();

	public static IFormFile GetFormFile(int length, string contentType = MediaTypeNames.Image.Png)
	{
		return GetFormFile(_faker.System.FileName(), _faker.Random.Bytes(length), contentType);
	}

	public static IFormFile GetFormFile(string fileName, byte[] content, string contentType)
	{
		var stream = new MemoryStream(content);

		return new FormFile(stream, default, stream.Length, fileName, fileName)
		{
			Headers = new HeaderDictionary(),
			ContentType = contentType
		};
	}

	public static IFormFile GetAverageFormFile(int maxLength, int minLength = default)
	{
		return GetFormFile(GetAverageNumber(maxLength, minLength));
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

	public static string GetString(int length)
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

	public static int GetAverageNumber(int maxLength, int minLength = default)
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
