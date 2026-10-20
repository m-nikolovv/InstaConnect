using InstaConnect.Chats.Domain.Features.Users.Utilities;

namespace InstaConnect.Chats.Domain.Features.Users.Exceptions;

public class UserNameAlreadyExistsException : BadRequestException
{
	public UserNameAlreadyExistsException(Name name)
		: base(UserExceptionErrorMessages.GetNameAlreadyExistsMessage(name))
	{
	}
}
