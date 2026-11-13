using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Models.Options;

public class RefreshTokenCacheOptionsValidator : AbstractValidator<RefreshTokenCacheOptions>
{
	public RefreshTokenCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
