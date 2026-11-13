using InstaConnect.Common.Domain.Features.Validations.Extensions;

using FluentValidation;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Models.Options;

public class EmailConfirmationTokenCacheOptionsValidator : AbstractValidator<EmailConfirmationTokenCacheOptions>
{
	public EmailConfirmationTokenCacheOptionsValidator()
	{
		RuleFor(o => o.Expirations)
			.NotEmptyWithMessage();
	}
}
