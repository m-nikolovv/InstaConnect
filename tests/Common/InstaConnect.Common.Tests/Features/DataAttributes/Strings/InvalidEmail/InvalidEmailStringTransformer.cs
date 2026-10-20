namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.InvalidEmail;

internal class InvalidEmailStringTransformer : IStringTransformer
{
	public string Transform(string? value)
	{
		const string DomainSeperator = "@";

		return value!.Split(DomainSeperator).FirstOrDefault()!;
	}
}
