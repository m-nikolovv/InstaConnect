namespace InstaConnect.Common.Tests.Features.Extensions;

public static class StringExtensions
{
	extension(string str)
	{
		public string GetHash()
		{
			const string Format = "hashed-{0}";

			return Format.FormatCurrentCulture(str);
		}

		public string GetTest()
		{
			const string Format = "test-{0}";

			return Format.FormatCurrentCulture(str);
		}
	}
}
