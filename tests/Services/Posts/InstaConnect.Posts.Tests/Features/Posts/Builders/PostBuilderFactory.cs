namespace InstaConnect.Posts.Tests.Features.Posts.Builders;

public class PostBuilderFactory
{
	public PostBuilder Create(User user)
	{
		return new(user);
	}

	public PostBuilder Create(Post post)
	{
		return new(post);
	}
}
