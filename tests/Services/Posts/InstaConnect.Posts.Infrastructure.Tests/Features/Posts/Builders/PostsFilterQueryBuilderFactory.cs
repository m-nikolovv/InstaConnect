namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Builders;

public class PostsFilterQueryBuilderFactory
{
	public PostsFilterQueryBuilder Create(Post post)
	{
		return new(post);
	}
}
