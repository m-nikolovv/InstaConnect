namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class GetAllPostsForUserQueryBuilderFactory
{
	public GetAllPostsForUserQueryBuilder Create(Post post)
	{
		return new(post);
	}
}
