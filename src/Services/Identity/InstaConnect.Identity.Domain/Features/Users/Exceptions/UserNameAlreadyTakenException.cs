namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserNameAlreadyTakenException : BadRequestException
{
	public UserNameAlreadyTakenException(Name name) : base(
		UserExceptionErrorMessages.GetNameAlreadyTakenMessage(name))
	{
	}

	public UserNameAlreadyTakenException(Name name, Exception exception) : base(
		UserExceptionErrorMessages.GetNameAlreadyTakenMessage(name), exception)
	{
	}
}
