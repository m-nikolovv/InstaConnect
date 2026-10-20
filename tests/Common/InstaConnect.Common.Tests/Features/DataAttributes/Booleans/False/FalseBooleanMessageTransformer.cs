namespace InstaConnect.Common.Tests.Features.DataAttributes.Booleans.False;

internal class FalseBooleanMessageTransformer : IBooleanMessageTransformer
{
	public string Transform<T>(Expression<Func<T, bool>> propertyExpression, bool value)
	{
		return CommonValidationErrorMessages.GetEmpty(propertyExpression.GetPropertyDisplayName());
	}
}
