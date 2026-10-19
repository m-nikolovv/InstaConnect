namespace InstaConnect.Posts.Tests.Features.PostImages.Builders;

public class PostImageBuilderFactory
{
	public PostImageBuilder Create(Post post)
	{
		return new(post);
	}

	public PostImageBuilder Create(PostImage postImage)
	{
		return new(postImage);
	}
}
