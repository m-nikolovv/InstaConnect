namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetPostByIdApiRequestBuilderFactory
{
	public GetPostByIdApiRequestBuilder Create(Post post, UserId currentUserId)
	{
		return new(post, currentUserId);
	}
}
