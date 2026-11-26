namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesQueryBuilderFactory
{
	public GetAllPostCommentLikesQueryBuilder Create(PostCommentLike postCommentLike, UserId currentUserId)
	{
		return new(postCommentLike, currentUserId);
	}
}
