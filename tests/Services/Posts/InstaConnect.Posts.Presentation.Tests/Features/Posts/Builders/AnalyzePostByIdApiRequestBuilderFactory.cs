namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class AnalyzePostByIdApiRequestBuilderFactory
{
	public AnalyzePostByIdApiRequestBuilder Create(Post post)
	{
		return new(post);
	}
}
