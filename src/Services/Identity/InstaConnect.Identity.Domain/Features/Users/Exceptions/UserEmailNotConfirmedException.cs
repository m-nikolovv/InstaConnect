namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailNotConfirmedException : BadRequestException
{
	public UserEmailNotConfirmedException(UserId id) : base(
		UserExceptionErrorMessages.GetEmailNotConfirmedMessage(id))
	{
	}

	public UserEmailNotConfirmedException(UserId id, Exception exception) : base(
		UserExceptionErrorMessages.GetEmailNotConfirmedMessage(id), exception)
	{
	}
}
