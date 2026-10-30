namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;

public class AddPostCommentCommandBuilderFactory
{
	public AddPostCommentCommandBuilder Create(Post post, User user)
	{
		return new(post, user);
	}
}
