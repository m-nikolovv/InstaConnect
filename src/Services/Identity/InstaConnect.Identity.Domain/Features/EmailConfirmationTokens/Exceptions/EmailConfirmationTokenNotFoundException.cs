using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenNotFoundException : NotFoundException
{
	public EmailConfirmationTokenNotFoundException(EmailConfirmationTokenId id)
		: base(EmailConfirmationTokenExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}
}
