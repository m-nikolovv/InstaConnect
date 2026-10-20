namespace InstaConnect.Common.Tests.Features.DataAttributes.Booleans.False;

internal class FalseBooleanTransformer : IBooleanTransformer
{
	public bool Transform(bool value)
	{
		return false;
	}
}

