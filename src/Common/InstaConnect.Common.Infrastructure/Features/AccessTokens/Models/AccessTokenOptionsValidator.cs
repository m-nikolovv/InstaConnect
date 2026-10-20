namespace InstaConnect.Common.Infrastructure.Features.AccessTokens.Models;

public class AccessTokenOptionsValidator : AbstractValidator<AccessTokenOptions>
{
	public AccessTokenOptionsValidator()
	{
		RuleFor(o => o.Issuer)
			.NotEmptyWithMessage();

		RuleFor(o => o.Audience)
			.NotEmptyWithMessage();

		RuleFor(o => o.SecurityKey)
			.NotEmptyWithMessage();

		RuleFor(o => o.LifetimeSeconds)
			.NotEmptyWithMessage();
	}
}
