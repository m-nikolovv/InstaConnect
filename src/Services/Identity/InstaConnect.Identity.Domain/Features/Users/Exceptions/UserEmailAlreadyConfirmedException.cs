namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserEmailAlreadyConfirmedException : BadRequestException
{
	public UserEmailAlreadyConfirmedException(UserId id) : base(
		UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(id))
	{
	}

	public UserEmailAlreadyConfirmedException(UserId id, Exception exception) : base(
		UserExceptionErrorMessages.GetEmailAlreadyConfirmedMessage(id), exception)
	{
	}
}
