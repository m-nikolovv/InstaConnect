namespace InstaConnect.Common.Domain.Features.Validations.Utilities;

public static class CommonValidationErrorMessages
{
	public static string GetEmpty(string propertyName)
	{
		const string Format = "{0} must not be empty.";

		return Format.FormatCurrentCulture(propertyName);
	}

	public static string GetNotEqual(string propertyName, string equalPropertyName)
	{
		const string Format = "{0} must be the same as {1}.";

		return Format.FormatCurrentCulture(propertyName, equalPropertyName);
	}

	public static string GetMinLength(string propertyName, int length, int minLength)
	{
		const string Format = "{0} length is {1} and it must be at least {2} characters long";

		return Format.FormatCurrentCulture(propertyName, length, minLength);
	}

	public static string GetMaxLength(string propertyName, int length, int maxLength)
	{
		const string Format = "{0} length is {1} and it must be at most {2} characters long";

		return Format.FormatCurrentCulture(propertyName, length, maxLength);
	}

	public static string GetMinValue(string propertyName, int value, int minValue)
	{
		const string Format = "{0} value is {1} and it must be at least {2}";

		return Format.FormatCurrentCulture(propertyName, value, minValue);
	}

	public static string GetMaxValue(string propertyName, int value, int maxValue)
	{
		const string Format = "{0} value is {1} and it must be at most {2}";

		return Format.FormatCurrentCulture(propertyName, value, maxValue);
	}

	public static string GetInvalidEmail(string propertyName)
	{
		const string Format = "{0} is not a valid email address.";

		return Format.FormatCurrentCulture(propertyName);
	}

	public static string GetMaxCount(string propertyName, int count, int maxCount)
	{
		const string Format = "{0} count is {1} and it must be at most {2}";

		return Format.FormatCurrentCulture(propertyName, count, maxCount);
	}

	public static string GetMaxFileSize(string propertyName, long size, int maxSize)
	{
		const string Format = "{0} size is {1} and it must be at most {2} bytes";

		return Format.FormatCurrentCulture(propertyName, size, maxSize);
	}

	public static string GetInvalidContentType(string propertyName, ICollection<string> contentTypes)
	{
		const string Format = "{0} content type must be one of {1}";

		return Format.FormatCurrentCulture(propertyName, contentTypes.JoinWithComma());
	}
}
