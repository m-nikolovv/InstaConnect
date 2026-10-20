namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.TooLong;

internal class TooLongStringMessageTransformer : IStringMessageTransformer
{
	private readonly int _maxLength;

	public TooLongStringMessageTransformer(int maxLength)
	{
		_maxLength = maxLength;
	}

	public string Transform<T>(Expression<Func<T, string>> propertyExpression, string value)
	{
		return CommonValidationErrorMessages.GetMaxLength(propertyExpression.GetPropertyDisplayName(), value.Length, _maxLength);
	}
}
