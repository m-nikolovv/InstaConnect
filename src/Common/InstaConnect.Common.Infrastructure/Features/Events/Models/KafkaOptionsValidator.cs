namespace InstaConnect.Common.Infrastructure.Features.Events.Models;

public class KafkaOptionsValidator : AbstractValidator<KafkaOptions>
{
	public KafkaOptionsValidator()
	{
		RuleFor(o => o.ConnectionString)
			.NotEmptyWithMessage();

		RuleFor(o => o.Username)
			.NotEmptyWithMessage();

		RuleFor(o => o.Password)
			.NotEmptyWithMessage();
	}
}
