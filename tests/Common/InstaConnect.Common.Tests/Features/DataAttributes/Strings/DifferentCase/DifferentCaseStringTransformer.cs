namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.DifferentCase;

public class DifferentCaseStringTransformer : IStringTransformer
{
	public string Transform(string? value)
	{
		return DataFaker.GetDifferentCaseString(value);
	}
}

