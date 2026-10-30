namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.NotEqual;

internal class NotEqualStringTransformer : IStringTransformer
{
	private readonly int _maxLength;
	private readonly int _minLength;

	public NotEqualStringTransformer(int maxLength, int minLength = default)
	{
		_maxLength = maxLength;
		_minLength = minLength;
	}

	public string Transform(string? value)
	{
		return DataFaker.GetAverageString(_maxLength, _minLength);
	}
}

