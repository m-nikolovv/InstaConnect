namespace InstaConnect.Common.Infrastructure.Features.DateTimes.Extensions;

public static class DateTimeOffsetExtensions
{
	extension(DateTimeOffset date)
	{
		public DateTimeOffset TruncateToMilliseconds()
		{
			return DateTimeOffset.FromUnixTimeMilliseconds(date.ToUnixTimeMilliseconds());
		}
	}
}
