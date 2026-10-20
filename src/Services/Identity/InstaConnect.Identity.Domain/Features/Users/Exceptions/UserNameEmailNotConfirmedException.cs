namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserNameEmailNotConfirmedException : BadRequestException
{
	public UserNameEmailNotConfirmedException(Name name) : base(
		UserExceptionErrorMessages.GetNameEmailNotConfirmedMessage(name))
	{
	}

	public UserNameEmailNotConfirmedException(Name name, Exception exception) : base(
		UserExceptionErrorMessages.GetNameEmailNotConfirmedMessage(name), exception)
	{
	}
}
