namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class AddPostCommentApiRequestBuilderFactory
{
	public AddPostCommentApiRequestBuilder Create(Post post, User user)
	{
		return new(post, user);
	}
}
