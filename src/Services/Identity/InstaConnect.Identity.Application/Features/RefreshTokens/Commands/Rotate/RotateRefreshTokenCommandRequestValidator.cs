using InstaConnect.Identity.Application.Features.RefreshTokens.Extensions;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;

public class RotateRefreshTokenCommandRequestValidator : AbstractValidator<RotateRefreshTokenCommandRequest>
{
	public RotateRefreshTokenCommandRequestValidator()
	{
		RuleFor(r => r.Id)
			.NotEmptyWithMessage()
			.UserIdMinLengthWithMessage()
			.UserIdMaxLengthWithMessage();

		RuleFor(r => r.Value)
			.NotEmptyWithMessage()
			.RefreshTokenValueMinLengthWithMessage()
			.RefreshTokenValueMaxLengthWithMessage();
	}
}
