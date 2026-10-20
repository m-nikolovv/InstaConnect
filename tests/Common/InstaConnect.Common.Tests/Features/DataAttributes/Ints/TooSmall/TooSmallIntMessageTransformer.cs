namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.TooSmall;

internal class TooSmallIntMessageTransformer : IIntMessageTransformer
{
	private readonly int _minValue;

	public TooSmallIntMessageTransformer(int minValue)
	{
		_minValue = minValue;
	}

	public string Transform<T>(Expression<Func<T, int>> propertyExpression, int value)
	{
		return CommonValidationErrorMessages.GetMinValue(propertyExpression.GetPropertyDisplayName(), value, _minValue);
	}
}
