namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UsersSortTermNotSupportedException : BadRequestException
{
	public UsersSortTermNotSupportedException(UsersSortTerm sortTerm)
		: base(UserExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
	{
	}

	public UsersSortTermNotSupportedException(UsersSortTerm sortTerm, Exception exception)
		: base(UserExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
	{
	}
}
