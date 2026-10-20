namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Builders;

public class PostLikesFilterQueryBuilderFactory
{
	public PostLikesFilterQueryBuilder Create(PostLike postLike)
	{
		return new(postLike);
	}
}
