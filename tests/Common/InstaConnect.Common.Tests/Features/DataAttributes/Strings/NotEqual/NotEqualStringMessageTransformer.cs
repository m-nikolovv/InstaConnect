namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.NotEqual;

internal class NotEqualStringMessageTransformer : IStringMessageTransformer
{
	private readonly string _equalPropertyName;

	public NotEqualStringMessageTransformer(string equalPropertyName)
	{
		_equalPropertyName = equalPropertyName;
	}

	public string Transform<T>(Expression<Func<T, string>> propertyExpression, string value)
	{
		return CommonValidationErrorMessages.GetNotEqual(propertyExpression.GetPropertyDisplayName(), _equalPropertyName);
	}
}
