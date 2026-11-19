namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdQueryBuilderFactory
{
	public GetPostLikeByIdQueryBuilder Create(PostLike postLike, UserId currentUserId)
	{
		return new(postLike, currentUserId);
	}
}
