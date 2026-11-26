using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models.Options;

public class FollowCacheOptionsValidator : AbstractValidator<FollowCacheOptions>
{
	public FollowCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
