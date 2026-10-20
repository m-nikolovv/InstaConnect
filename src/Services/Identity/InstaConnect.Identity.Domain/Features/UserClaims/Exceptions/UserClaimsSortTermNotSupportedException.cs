using InstaConnect.Identity.Domain.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;

public class UserClaimsSortTermNotSupportedException : BadRequestException
{
	public UserClaimsSortTermNotSupportedException(UserClaimsSortTerm sortTerm)
		: base(UserClaimExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
	{
	}

	public UserClaimsSortTermNotSupportedException(UserClaimsSortTerm sortTerm, Exception exception)
		: base(UserClaimExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
	{
	}
}
