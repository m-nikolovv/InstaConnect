using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Extensions;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;

public class VerifyEmailConfirmationTokenCommandRequestValidator : AbstractValidator<VerifyEmailConfirmationTokenCommandRequest>
{
	public VerifyEmailConfirmationTokenCommandRequestValidator()
	{
		RuleFor(r => r.Id)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(r => r.Value)
			.NotEmptyWithMessage()
			.EmailConfirmationTokenValueMinLengthWithMessage()
			.EmailConfirmationTokenValueMaxLengthWithMessage();
	}
}
