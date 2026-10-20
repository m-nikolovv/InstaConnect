using InstaConnect.Chats.Domain.Features.Users.Utilities;

namespace InstaConnect.Chats.Domain.Features.Users.Exceptions;

public class UserAlreadyExistsException : BadRequestException
{
	public UserAlreadyExistsException(UserId id)
		: base(UserExceptionErrorMessages.GetAlreadyExistsMessage(id))
	{
	}
}
