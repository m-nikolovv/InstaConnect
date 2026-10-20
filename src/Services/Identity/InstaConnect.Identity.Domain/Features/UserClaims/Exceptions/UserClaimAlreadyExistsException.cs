using InstaConnect.Identity.Domain.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;

public class UserClaimAlreadyExistsException : BadRequestException
{
	public UserClaimAlreadyExistsException(UserClaimId id)
		: base(UserClaimExceptionErrorMessages.GetAlreadyExistsMessage(id))
	{
	}
}
