using InstaConnect.Follows.Domain.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowAlreadyExistsException : BadRequestException
{
	public FollowAlreadyExistsException(FollowId id)
		: base(FollowExceptionErrorMessages.GetAlreadyExistsMessage(id))
	{
	}

	public FollowAlreadyExistsException(FollowId id, Exception exception)
		: base(FollowExceptionErrorMessages.GetAlreadyExistsMessage(id), exception)
	{
	}
}
