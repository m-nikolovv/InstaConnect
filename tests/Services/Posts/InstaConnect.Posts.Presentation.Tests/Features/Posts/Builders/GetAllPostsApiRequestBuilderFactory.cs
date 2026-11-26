namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetAllPostsApiRequestBuilderFactory
{
	public GetAllPostsApiRequestBuilder Create(Post post)
	{
		return new(post);
	}
}
