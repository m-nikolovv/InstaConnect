using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Models.Options;

public class UserClaimCacheOptionsValidator : AbstractValidator<UserClaimCacheOptions>
{
	public UserClaimCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
