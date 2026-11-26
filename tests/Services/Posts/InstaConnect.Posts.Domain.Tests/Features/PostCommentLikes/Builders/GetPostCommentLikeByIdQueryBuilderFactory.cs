namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;

public class GetPostCommentLikeByIdQueryBuilderFactory
{
	public GetPostCommentLikeByIdQueryBuilder Create(PostCommentLike postCommentLike, UserId currentUserId)
	{
		return new(postCommentLike, currentUserId);
	}
}
