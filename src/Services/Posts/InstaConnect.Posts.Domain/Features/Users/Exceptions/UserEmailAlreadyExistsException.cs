using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyExistsException : BadRequestException
{
	public UserEmailAlreadyExistsException(Email email)
		: base(UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(email))
	{
	}
}
