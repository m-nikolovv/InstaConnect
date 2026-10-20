namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.TooShort;

internal class TooShortStringTransformer : IStringTransformer
{
	private readonly int _minLength;

	public TooShortStringTransformer(int minLength)
	{
		_minLength = minLength;
	}

	public string Transform(string? value)
	{
		return DataFaker.GetString(_minLength.Decrement());
	}
}

