namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetAllPostsQueryRequestBuilderFactory
{
	public GetAllPostsQueryRequestBuilder Create(Post post)
	{
		return new(post);
	}
}
