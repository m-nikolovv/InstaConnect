using InstaConnect.Follows.Domain.Features.Users.Utilities;

namespace InstaConnect.Follows.Domain.Features.Users.Exceptions;

public class UserAlreadyExistsException : BadRequestException
{
	public UserAlreadyExistsException(UserId id)
		: base(UserExceptionErrorMessages.GetAlreadyExistsMessage(id))
	{
	}
}
