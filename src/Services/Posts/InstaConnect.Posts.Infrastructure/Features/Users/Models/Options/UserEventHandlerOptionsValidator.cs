using InstaConnect.Common.Domain.Features.Validations.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Models;

using FluentValidation;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Models.Options;

public class UserEventHandlerOptionsValidator : AbstractValidator<UserEventHandlerOptions>
{
	public UserEventHandlerOptionsValidator()
	{
		RuleFor(o => o.Consumers)
			.NotEmptyWithMessage();

		RuleForEach(o => o.Consumers.Values)
			.SetValidator(new KafkaConsumerOptionsValidator());
	}
}
