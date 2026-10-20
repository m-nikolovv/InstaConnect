namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Builders;

public class PostCommentLikeIdBuilderFactory
{
	public PostCommentLikeIdBuilder Create(PostCommentLikeId id)
	{
		return new(id);
	}
}
