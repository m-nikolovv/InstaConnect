namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class AnalyzePostByIdQueryRequestBuilderFactory
{
	public AnalyzePostByIdQueryRequestBuilder Create(Post post)
	{
		return new(post);
	}
}
