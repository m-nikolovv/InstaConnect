using InstaConnect.Follows.Domain.Features.Users.Utilities;

namespace InstaConnect.Follows.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyExistsException : BadRequestException
{
	public UserEmailAlreadyExistsException(Email email)
		: base(UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(email))
	{
	}
}
