namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.Null;

internal class NullStringMessageTransformer : IStringMessageTransformer
{
	public string Transform<T>(Expression<Func<T, string>> propertyExpression, string value)
	{
		return CommonValidationErrorMessages.GetEmpty(propertyExpression.GetPropertyDisplayName());
	}
}
