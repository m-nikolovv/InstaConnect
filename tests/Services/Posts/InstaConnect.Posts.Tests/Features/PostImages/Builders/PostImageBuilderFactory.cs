namespace InstaConnect.Posts.Tests.Features.PostImages.Builders;

public class PostImageBuilderFactory
{
	public PostImageBuilder Create(Post post)
	{
		return new(post);
	}
}
