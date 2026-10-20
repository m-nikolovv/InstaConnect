namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.TooSmall;

internal class TooSmallIntTransformer : IIntTransformer
{
	private readonly int _minValue;

	public TooSmallIntTransformer(int minValue)
	{
		_minValue = minValue;
	}

	public int Transform(int value)
	{
		return _minValue.Decrement();
	}
}

