using InstaConnect.Posts.Domain.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

public class PostCommentsForUserSortTermNotSupportedException : BadRequestException
{
	public PostCommentsForUserSortTermNotSupportedException(PostCommentsForUserSortTerm sortTerm)
		: base(PostCommentExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
	{
	}

	public PostCommentsForUserSortTermNotSupportedException(PostCommentsForUserSortTerm sortTerm, Exception exception)
		: base(PostCommentExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
	{
	}
}
