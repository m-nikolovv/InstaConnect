namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserInvalidDetailsException : BadRequestException
{
	public UserInvalidDetailsException(Name name) : base(
		UserExceptionErrorMessages.GetInvalidDetailsMessage(name))
	{
	}

	public UserInvalidDetailsException(Name name, Exception exception) : base(
		UserExceptionErrorMessages.GetInvalidDetailsMessage(name), exception)
	{
	}
}
