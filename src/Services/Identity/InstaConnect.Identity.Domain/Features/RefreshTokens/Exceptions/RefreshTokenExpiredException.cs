using InstaConnect.Identity.Domain.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

public class RefreshTokenExpiredException : BadRequestException
{
	public RefreshTokenExpiredException(RefreshTokenId id)
		: base(RefreshTokenExceptionErrorMessages.GetExpiredMessage(id))
	{
	}
}
