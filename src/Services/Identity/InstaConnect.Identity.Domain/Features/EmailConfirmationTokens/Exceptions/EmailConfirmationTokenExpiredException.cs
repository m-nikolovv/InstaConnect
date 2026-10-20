using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenExpiredException : BadRequestException
{
	public EmailConfirmationTokenExpiredException(EmailConfirmationTokenId id)
		: base(EmailConfirmationTokenExceptionErrorMessages.GetExpiredMessage(id))
	{
	}
}
