using InstaConnect.Identity.Domain.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

public class RefreshTokenNotFoundException : NotFoundException
{
	public RefreshTokenNotFoundException(RefreshTokenId id)
		: base(RefreshTokenExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}
}
