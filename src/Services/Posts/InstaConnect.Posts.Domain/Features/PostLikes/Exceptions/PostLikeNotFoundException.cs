using InstaConnect.Posts.Domain.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikeNotFoundException : NotFoundException
{
	public PostLikeNotFoundException(PostLikeId id)
		: base(PostLikeExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}

	public PostLikeNotFoundException(PostLikeId id, Exception exception)
		: base(PostLikeExceptionErrorMessages.GetNotFoundMessage(id), exception)
	{
	}
}
