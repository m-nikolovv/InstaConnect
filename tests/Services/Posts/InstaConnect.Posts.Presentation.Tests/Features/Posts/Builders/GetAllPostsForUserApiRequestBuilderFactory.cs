namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetAllPostsForUserApiRequestBuilderFactory
{
	public GetAllPostsForUserApiRequestBuilder Create(Post post, UserId currentUserId)
	{
		return new(post, currentUserId);
	}
}
