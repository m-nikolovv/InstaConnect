using InstaConnect.Identity.Application.Features.RefreshTokens.Extensions;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.DeleteCurrent;

public class DeleteCurrentRefreshTokenCommandRequestValidator : AbstractValidator<DeleteCurrentRefreshTokenCommandRequest>
{
	public DeleteCurrentRefreshTokenCommandRequestValidator()
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
