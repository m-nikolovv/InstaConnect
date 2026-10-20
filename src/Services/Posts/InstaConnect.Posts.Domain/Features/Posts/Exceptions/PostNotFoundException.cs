using InstaConnect.Posts.Domain.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostNotFoundException : NotFoundException
{
	public PostNotFoundException(PostId id)
		: base(PostExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}

	public PostNotFoundException(PostId id, Exception exception)
		: base(PostExceptionErrorMessages.GetNotFoundMessage(id), exception)
	{
	}
}
