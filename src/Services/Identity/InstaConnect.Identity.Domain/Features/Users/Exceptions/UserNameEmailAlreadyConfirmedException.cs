namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserNameEmailAlreadyConfirmedException : BadRequestException
{
	public UserNameEmailAlreadyConfirmedException(Name name) : base(
		UserExceptionErrorMessages.GetNameEmailAlreadyConfirmedMessage(name))
	{
	}

	public UserNameEmailAlreadyConfirmedException(Name name, Exception exception) : base(
		UserExceptionErrorMessages.GetNameEmailAlreadyConfirmedMessage(name), exception)
	{
	}
}
