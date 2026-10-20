namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Builders;

public class PostCommentImageBuilderFactory
{
	public PostCommentImageBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}

	public PostCommentImageBuilder Create(PostCommentImage postCommentImage)
	{
		return new(postCommentImage);
	}
}
