using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Models.Options;

public class ForgotPasswordTokenCacheOptionsValidator : AbstractValidator<ForgotPasswordTokenCacheOptions>
{
	public ForgotPasswordTokenCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
