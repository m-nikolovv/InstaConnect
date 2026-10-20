using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserNotFoundException : NotFoundException
{
	public UserNotFoundException(UserId id)
		: base(UserExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}
}
