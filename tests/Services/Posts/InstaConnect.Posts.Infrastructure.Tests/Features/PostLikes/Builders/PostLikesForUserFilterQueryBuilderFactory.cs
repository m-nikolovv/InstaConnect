namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Builders;

public class PostLikesForUserFilterQueryBuilderFactory
{
	public PostLikesForUserFilterQueryBuilder Create(PostLike postLike)
	{
		return new(postLike);
	}
}
