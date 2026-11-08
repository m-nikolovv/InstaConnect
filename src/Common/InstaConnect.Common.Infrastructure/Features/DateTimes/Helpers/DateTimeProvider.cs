using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Infrastructure.Features.DateTimes.Extensions;

namespace InstaConnect.Common.Infrastructure.Features.DateTimes.Helpers;

public class DateTimeProvider : IDateTimeProvider
{
	public DateTimeOffset GetOffsetUtcNow()
	{
		return DateTimeOffset.UtcNow.TruncateToMilliseconds();
	}

	public DateTimeOffset GetOffsetUtcNow(int seconds)
	{
		return DateTimeOffset.FromUnixTimeSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds() + seconds);
	}

	public DateTime GetUtcNow()
	{
		return DateTime.UtcNow;
	}

	public DateTime GetUtcNow(int seconds)
	{
		return GetOffsetUtcNow(seconds).UtcDateTime;
	}
}
