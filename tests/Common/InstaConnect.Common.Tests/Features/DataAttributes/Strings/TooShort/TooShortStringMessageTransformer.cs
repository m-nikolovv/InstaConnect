namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.TooShort;

internal class TooShortStringMessageTransformer : IStringMessageTransformer
{
	private readonly int _minLength;

	public TooShortStringMessageTransformer(int minLength)
	{
		_minLength = minLength;
	}

	public string Transform<T>(Expression<Func<T, string>> propertyExpression, string value)
	{
		return CommonValidationErrorMessages.GetMinLength(propertyExpression.GetPropertyDisplayName(), value.Length, _minLength);
	}
}
