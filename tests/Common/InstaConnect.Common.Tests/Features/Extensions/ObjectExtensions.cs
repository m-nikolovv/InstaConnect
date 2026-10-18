namespace InstaConnect.Common.Tests.Features.Extensions;

public static class ObjectExtensions
{
	extension(object value)
	{
		public string GetAnalysisSummary()
		{
			const string Message = "Analysis summary";

			return Message;
		}
	}
}
