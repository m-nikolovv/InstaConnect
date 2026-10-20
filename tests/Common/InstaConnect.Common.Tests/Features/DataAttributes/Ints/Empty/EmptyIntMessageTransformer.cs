namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.Empty;

internal class EmptyIntMessageTransformer : IIntMessageTransformer
{
	public string Transform<T>(Expression<Func<T, int>> propertyExpression, int value)
	{
		return CommonValidationErrorMessages.GetEmpty(propertyExpression.GetPropertyDisplayName());
	}
}
