namespace InstaConnect.Common.Infrastructure.Features.Events.Models;

public record KafkaConsumerOptions(
	ushort PartitionCount,
	short ReplicationFactor,
	int ConcurrentMessageLimit,
	int RetryLimit,
	TimeSpan RetryMinInterval,
	TimeSpan RetryMaxInterval,
	TimeSpan RetryIntervalDelta);
