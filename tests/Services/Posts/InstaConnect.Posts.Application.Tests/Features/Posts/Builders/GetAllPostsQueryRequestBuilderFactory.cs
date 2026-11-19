namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetAllPostsQueryRequestBuilderFactory
{
	public GetAllPostsQueryRequestBuilder Create(Post post, UserId currentUserId)
	{
		return new(post, currentUserId);
	}
}
