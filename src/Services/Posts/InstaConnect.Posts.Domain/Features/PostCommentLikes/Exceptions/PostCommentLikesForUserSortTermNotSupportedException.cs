using InstaConnect.Posts.Domain.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikesForUserSortTermNotSupportedException : BadRequestException
{
	public PostCommentLikesForUserSortTermNotSupportedException(PostCommentLikesForUserSortTerm sortTerm)
		: base(PostCommentLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
	{
	}

	public PostCommentLikesForUserSortTermNotSupportedException(PostCommentLikesForUserSortTerm sortTerm, Exception exception)
		: base(PostCommentLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
	{
	}
}
