namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class AnalyzePostByIdQueryBuilderFactory
{
	public AnalyzePostByIdQueryBuilder Create(Post post)
	{
		return new(post);
	}
}
