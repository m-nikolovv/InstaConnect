using InstaConnect.Posts.Domain.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostsForUserSortTermNotSupportedException : BadRequestException
{
	public PostsForUserSortTermNotSupportedException(PostsForUserSortTerm sortTerm)
		: base(PostExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
	{
	}

	public PostsForUserSortTermNotSupportedException(PostsForUserSortTerm sortTerm, Exception exception)
		: base(PostExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
	{
	}
}
