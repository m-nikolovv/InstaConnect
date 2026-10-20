using InstaConnect.Posts.Domain.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeAlreadyExistsException : BadRequestException
{
	public PostCommentLikeAlreadyExistsException(PostCommentLikeId id)
		: base(PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(id))
	{
	}

	public PostCommentLikeAlreadyExistsException(PostCommentLikeId id, Exception exception)
		: base(PostCommentLikeExceptionErrorMessages.GetAlreadyExistsMessage(id), exception)
	{
	}
}
