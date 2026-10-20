using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserNameAlreadyExistsException : BadRequestException
{
	public UserNameAlreadyExistsException(Name name)
		: base(UserExceptionErrorMessages.GetNameAlreadyExistsMessage(name))
	{
	}
}
