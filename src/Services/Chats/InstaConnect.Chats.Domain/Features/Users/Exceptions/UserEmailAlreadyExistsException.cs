using InstaConnect.Chats.Domain.Features.Users.Utilities;

namespace InstaConnect.Chats.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyExistsException : BadRequestException
{
	public UserEmailAlreadyExistsException(Email email)
		: base(UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(email))
	{
	}
}
