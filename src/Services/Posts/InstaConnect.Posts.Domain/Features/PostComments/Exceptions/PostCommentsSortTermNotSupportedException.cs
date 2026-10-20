using InstaConnect.Posts.Domain.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

public class PostCommentsSortTermNotSupportedException : BadRequestException
{
	public PostCommentsSortTermNotSupportedException(PostCommentsSortTerm sortTerm)
		: base(PostCommentExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
	{
	}

	public PostCommentsSortTermNotSupportedException(PostCommentsSortTerm sortTerm, Exception exception)
		: base(PostCommentExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
	{
	}
}
