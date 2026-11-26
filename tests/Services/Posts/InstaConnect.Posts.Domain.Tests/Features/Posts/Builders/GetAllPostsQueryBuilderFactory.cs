namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class GetAllPostsQueryBuilderFactory
{
	public GetAllPostsQueryBuilder Create(Post post)
	{
		return new(post);
	}
}
