using InstaConnect.Posts.Domain.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikeAlreadyExistsException : BadRequestException
{
	public PostLikeAlreadyExistsException(PostLikeId id)
		: base(PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(id))
	{
	}

	public PostLikeAlreadyExistsException(PostLikeId id, Exception exception)
		: base(PostLikeExceptionErrorMessages.GetAlreadyExistsMessage(id), exception)
	{
	}
}
