namespace InstaConnect.Common.Infrastructure.Features.Events.Models;

public class RabbitMqOptionsValidator : AbstractValidator<RabbitMqOptions>
{
	public RabbitMqOptionsValidator()
	{
		RuleFor(o => o.ConnectionString)
			.NotEmptyWithMessage();
	}
}
