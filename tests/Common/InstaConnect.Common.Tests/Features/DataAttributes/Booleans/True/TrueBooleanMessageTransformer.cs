namespace InstaConnect.Common.Tests.Features.DataAttributes.Booleans.True;

internal class TrueBooleanMessageTransformer : IBooleanMessageTransformer
{
	public string Transform<T>(Expression<Func<T, bool>> propertyExpression, bool value)
	{
		return CommonValidationErrorMessages.GetEmpty(propertyExpression.GetPropertyDisplayName());
	}
}
