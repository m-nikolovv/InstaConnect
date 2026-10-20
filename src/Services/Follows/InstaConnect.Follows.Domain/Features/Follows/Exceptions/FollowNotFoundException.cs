using InstaConnect.Follows.Domain.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowNotFoundException : NotFoundException
{
	public FollowNotFoundException(FollowId id)
		: base(FollowExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}

	public FollowNotFoundException(FollowId id, Exception exception)
		: base(FollowExceptionErrorMessages.GetNotFoundMessage(id), exception)
	{
	}
}
