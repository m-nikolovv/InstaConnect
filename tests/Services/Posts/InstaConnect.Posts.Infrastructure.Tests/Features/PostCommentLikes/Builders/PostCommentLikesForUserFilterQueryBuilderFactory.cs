namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikesForUserFilterQueryBuilderFactory
{
	public PostCommentLikesForUserFilterQueryBuilder Create(PostCommentLike postCommentLike)
	{
		return new(postCommentLike);
	}
}
