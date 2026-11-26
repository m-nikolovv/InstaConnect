namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetPostByIdQueryRequestBuilderFactory
{
	public GetPostByIdQueryRequestBuilder Create(Post post)
	{
		return new(post);
	}
}
