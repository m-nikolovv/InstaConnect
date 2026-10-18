namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class AddPostCommentCommandBuilderFactory
{
	public AddPostCommentCommandBuilder Create(Post post, User user, int numberOfImages)
	{
		return new(post, user, numberOfImages);
	}
}
