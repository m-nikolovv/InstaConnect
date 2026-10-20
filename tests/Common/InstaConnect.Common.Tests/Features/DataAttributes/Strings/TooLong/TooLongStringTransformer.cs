namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.TooLong;

internal class TooLongStringTransformer : IStringTransformer
{
	private readonly int _maxLength;

	public TooLongStringTransformer(int maxLength)
	{
		_maxLength = maxLength;
	}

	public string Transform(string? value)
	{
		return DataFaker.GetString(_maxLength.Increment());
	}
}

