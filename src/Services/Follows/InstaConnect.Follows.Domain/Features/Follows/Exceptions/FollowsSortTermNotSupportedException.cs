using InstaConnect.Follows.Domain.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowsSortTermNotSupportedException : BadRequestException
{
	public FollowsSortTermNotSupportedException(FollowsSortTerm sortTerm)
		: base(FollowExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
	{
	}

	public FollowsSortTermNotSupportedException(FollowsSortTerm sortTerm, Exception exception)
		: base(FollowExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
	{
	}
}
