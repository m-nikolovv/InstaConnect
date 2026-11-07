using FluentValidation;

using InstaConnect.Common.Domain.Features.Validations.Extensions;

namespace InstaConnect.Common.Presentation.Features.Controllers.Models;

public class RateLimiterPolicyOptionsValidator : AbstractValidator<RateLimiterPolicyOptions>
{
	public RateLimiterPolicyOptionsValidator()
	{
		RuleFor(o => o.PermitLimit)
			.NotEmptyWithMessage();

		RuleFor(o => o.Window)
			.NotEmptyWithMessage();

		RuleFor(o => o.SegmentsPerWindow)
			.NotEmptyWithMessage();
	}
}
