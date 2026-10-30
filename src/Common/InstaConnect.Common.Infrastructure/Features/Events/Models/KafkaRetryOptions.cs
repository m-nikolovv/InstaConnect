namespace InstaConnect.Common.Infrastructure.Features.Events.Models;

public record KafkaRetryOptions(
	int Limit,
	TimeSpan MinInterval,
	TimeSpan MaxInterval,
	TimeSpan IntervalDelta);
