namespace InstaConnect.Posts.Tests.Features.PostLikes.Builders;

public class PostLikeBuilderFactory
{
	public PostLikeBuilder Create(Post post, User user)
	{
		return new(post, user);
	}

	public PostLikeBuilder Create(PostLike postLike)
	{
		return new(postLike);
	}
}
