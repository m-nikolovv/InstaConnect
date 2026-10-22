namespace InstaConnect.Common.Infrastructure.Features.Events.Models;

public class KafkaRetryOptionsValidator : AbstractValidator<KafkaRetryOptions>
{
	public KafkaRetryOptionsValidator()
	{
		RuleFor(o => o.Limit)
			.NotEmptyWithMessage();

		RuleFor(o => o.MinInterval)
			.NotEmptyWithMessage();

		RuleFor(o => o.MaxInterval)
			.NotEmptyWithMessage();

		RuleFor(o => o.IntervalDelta)
			.NotEmptyWithMessage();
	}
}
