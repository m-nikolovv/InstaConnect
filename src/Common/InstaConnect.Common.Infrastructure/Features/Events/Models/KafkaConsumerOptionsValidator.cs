namespace InstaConnect.Common.Infrastructure.Features.Events.Models;

public class KafkaConsumerOptionsValidator : AbstractValidator<KafkaConsumerOptions>
{
	public KafkaConsumerOptionsValidator()
	{
		RuleFor(o => o.PartitionCount)
			.NotEmptyWithMessage();

		RuleFor(o => o.ReplicationFactor)
			.NotEmptyWithMessage();

		RuleFor(o => o.RetryLimit)
			.NotEmptyWithMessage();

		RuleFor(o => o.RetryMinInterval)
			.NotEmptyWithMessage();

		RuleFor(o => o.RetryMaxInterval)
			.NotEmptyWithMessage();

		RuleFor(o => o.RetryIntervalDelta)
			.NotEmptyWithMessage();
	}
}
