namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.Empty;

internal class EmptyStringTransformer : IStringTransformer
{
	public string Transform(string? value)
	{
		return string.Empty;
	}
}

