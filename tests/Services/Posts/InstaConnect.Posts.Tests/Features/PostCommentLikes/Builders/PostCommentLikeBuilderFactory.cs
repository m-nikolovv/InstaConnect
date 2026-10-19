namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeBuilderFactory
{
	public PostCommentLikeBuilder Create(PostComment postComment, User user)
	{
		return new(postComment, user);
	}

	public PostCommentLikeBuilder Create(PostCommentLike postCommentLike)
	{
		return new(postCommentLike);
	}
}
