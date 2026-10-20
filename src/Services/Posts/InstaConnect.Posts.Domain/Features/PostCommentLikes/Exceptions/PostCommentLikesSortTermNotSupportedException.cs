using InstaConnect.Posts.Domain.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikesSortTermNotSupportedException : BadRequestException
{
	public PostCommentLikesSortTermNotSupportedException(PostCommentLikesSortTerm sortTerm)
		: base(PostCommentLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
	{
	}

	public PostCommentLikesSortTermNotSupportedException(PostCommentLikesSortTerm sortTerm, Exception exception)
		: base(PostCommentLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
	{
	}
}
