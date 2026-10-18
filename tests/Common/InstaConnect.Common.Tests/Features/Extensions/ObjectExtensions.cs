namespace InstaConnect.Common.Tests.Features.Extensions;

public static class ObjectExtensions
{
	extension(object value)
	{
		public string GetAnalysisSummary()
		{
			const string Format = "{0} analysis summary";

			return Format.FormatCurrentCulture(value.GetType().Name);
		}
	}
}
