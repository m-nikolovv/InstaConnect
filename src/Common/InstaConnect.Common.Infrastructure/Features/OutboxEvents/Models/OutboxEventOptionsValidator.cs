namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models;

public class OutboxEventOptionsValidator : AbstractValidator<OutboxEventOptions>
{
	public OutboxEventOptionsValidator()
	{
		RuleFor(o => o.LifetimeSeconds)
			.NotEmptyWithMessage();
	}
}
