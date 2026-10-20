using InstaConnect.Follows.Domain.Features.Users.Utilities;

namespace InstaConnect.Follows.Domain.Features.Users.Exceptions;

public class UserNameAlreadyExistsException : BadRequestException
{
	public UserNameAlreadyExistsException(Name name)
		: base(UserExceptionErrorMessages.GetNameAlreadyExistsMessage(name))
	{
	}
}
