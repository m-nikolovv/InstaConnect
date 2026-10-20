using InstaConnect.Posts.Domain.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostForbiddenException : ForbiddenException
{
	public PostForbiddenException(PostId id, UserId userId)
		: base(PostExceptionErrorMessages.GetForbiddenMessage(id, userId))
	{
	}

	public PostForbiddenException(PostId id, UserId userId, Exception exception)
		: base(PostExceptionErrorMessages.GetForbiddenMessage(id, userId), exception)
	{
	}
}
