namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyTakenException : BadRequestException
{
	public UserEmailAlreadyTakenException(Email email) : base(
		UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(email))
	{
	}

	public UserEmailAlreadyTakenException(Email email, Exception exception) : base(
		UserExceptionErrorMessages.GetEmailAlreadyTakenMessage(email), exception)
	{
	}
}
