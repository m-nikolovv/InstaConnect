namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.Empty;

internal class EmptyStringMessageTransformer : IStringMessageTransformer
{
	public string Transform<T>(Expression<Func<T, string>> propertyExpression, string value)
	{
		return CommonValidationErrorMessages.GetEmpty(propertyExpression.GetPropertyDisplayName());
	}
}
