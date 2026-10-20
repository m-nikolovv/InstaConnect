namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserNameNotFoundException : NotFoundException
{
	public UserNameNotFoundException(Name name)
		: base(UserExceptionErrorMessages.GetNameNotFoundMessage(name))
	{
	}
}
