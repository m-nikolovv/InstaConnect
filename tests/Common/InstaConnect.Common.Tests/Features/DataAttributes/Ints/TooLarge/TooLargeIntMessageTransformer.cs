namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.TooLarge;

internal class TooLargeIntMessageTransformer : IIntMessageTransformer
{
	private readonly int _maxValue;

	public TooLargeIntMessageTransformer(int maxValue)
	{
		_maxValue = maxValue;
	}

	public string Transform<T>(Expression<Func<T, int>> propertyExpression, int value)
	{
		return CommonValidationErrorMessages.GetMaxValue(propertyExpression.GetPropertyDisplayName(), value, _maxValue);
	}
}
