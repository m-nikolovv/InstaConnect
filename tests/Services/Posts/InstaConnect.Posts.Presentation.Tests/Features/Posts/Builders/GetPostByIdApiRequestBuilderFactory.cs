namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetPostByIdApiRequestBuilderFactory
{
	public GetPostByIdApiRequestBuilder Create(Post post)
	{
		return new(post);
	}
}
