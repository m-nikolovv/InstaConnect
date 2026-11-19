namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetPostByIdQueryRequestBuilderFactory
{
	public GetPostByIdQueryRequestBuilder Create(Post post, UserId currentUserId)
	{
		return new(post, currentUserId);
	}
}
