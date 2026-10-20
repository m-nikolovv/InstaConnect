using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

public class ForgotPasswordTokenNotFoundException : NotFoundException
{
	public ForgotPasswordTokenNotFoundException(ForgotPasswordTokenId id)
		: base(ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}
}
