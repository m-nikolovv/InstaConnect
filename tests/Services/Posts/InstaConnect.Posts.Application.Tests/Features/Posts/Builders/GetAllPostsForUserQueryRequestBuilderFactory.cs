namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetAllPostsForUserQueryRequestBuilderFactory
{
	public GetAllPostsForUserQueryRequestBuilder Create(Post post)
	{
		return new(post);
	}
}
