using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Extensions;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

public class VerifyForgotPasswordTokenCommandRequestValidator : AbstractValidator<VerifyForgotPasswordTokenCommandRequest>
{
	public VerifyForgotPasswordTokenCommandRequestValidator()
	{
		RuleFor(r => r.Id)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(r => r.Value)
			.NotEmptyWithMessage()
			.ForgotPasswordTokenValueMinLengthWithMessage()
			.ForgotPasswordTokenValueMaxLengthWithMessage();

		RuleFor(r => r.Password)
			.NotEmptyWithMessage()
			.UserPasswordMinLengthWithMessage()
			.UserPasswordMaxLengthWithMessage();

		RuleFor(r => r.ConfirmPassword)
			.EqualWithMessage(r => r.Password);
	}
}
