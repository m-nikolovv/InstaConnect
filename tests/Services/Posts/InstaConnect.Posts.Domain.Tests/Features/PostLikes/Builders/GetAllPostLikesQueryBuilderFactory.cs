namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesQueryBuilderFactory
{
	public GetAllPostLikesQueryBuilder Create(PostLike postLike, UserId currentUserId)
	{
		return new(postLike, currentUserId);
	}
}
