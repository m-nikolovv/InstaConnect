namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentIdBuilderFactory
{
	public PostCommentIdBuilder Create(PostCommentId id)
	{
		return new(id);
	}
}
