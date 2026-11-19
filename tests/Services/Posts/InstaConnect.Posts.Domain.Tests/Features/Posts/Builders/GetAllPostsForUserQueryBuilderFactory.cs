namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;

public class GetAllPostsForUserQueryBuilderFactory
{
	public GetAllPostsForUserQueryBuilder Create(Post post, UserId currentUserId)
	{
		return new(post, currentUserId);
	}
}
