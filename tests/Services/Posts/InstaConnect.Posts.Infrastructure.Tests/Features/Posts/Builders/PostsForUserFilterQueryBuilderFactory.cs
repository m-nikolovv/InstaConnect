namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Builders;

public class PostsForUserFilterQueryBuilderFactory
{
	public PostsForUserFilterQueryBuilder Create(Post post)
	{
		return new(post);
	}
}
