namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.Empty;

internal class EmptyIntTransformer : IIntTransformer
{
	public int Transform(int value)
	{
		return default;
	}
}
