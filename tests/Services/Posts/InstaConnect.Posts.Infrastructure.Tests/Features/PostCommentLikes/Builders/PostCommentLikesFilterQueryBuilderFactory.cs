namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikesFilterQueryBuilderFactory
{
	public PostCommentLikesFilterQueryBuilder Create(PostCommentLike postCommentLike)
	{
		return new(postCommentLike);
	}
}
