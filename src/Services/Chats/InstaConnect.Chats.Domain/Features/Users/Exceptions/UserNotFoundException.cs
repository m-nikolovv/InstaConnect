using InstaConnect.Chats.Domain.Features.Users.Utilities;

namespace InstaConnect.Chats.Domain.Features.Users.Exceptions;

public class UserNotFoundException : NotFoundException
{
	public UserNotFoundException(UserId id)
		: base(UserExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}
}
