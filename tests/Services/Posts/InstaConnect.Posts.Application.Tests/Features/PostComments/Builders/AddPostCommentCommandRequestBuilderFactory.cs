namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class AddPostCommentCommandRequestBuilderFactory
{
	public AddPostCommentCommandRequestBuilder Create(Post post, User user, int numberOfImages)
	{
		return new(post, user, numberOfImages);
	}
}
