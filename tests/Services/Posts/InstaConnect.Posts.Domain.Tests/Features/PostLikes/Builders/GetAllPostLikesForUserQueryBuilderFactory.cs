namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesForUserQueryBuilderFactory
{
	public GetAllPostLikesForUserQueryBuilder Create(PostLike postLike, UserId currentUserId)
	{
		return new(postLike, currentUserId);
	}
}
