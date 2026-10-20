using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

public class ForgotPasswordTokenExpiredException : BadRequestException
{
	public ForgotPasswordTokenExpiredException(ForgotPasswordTokenId id)
		: base(ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(id))
	{
	}
}
