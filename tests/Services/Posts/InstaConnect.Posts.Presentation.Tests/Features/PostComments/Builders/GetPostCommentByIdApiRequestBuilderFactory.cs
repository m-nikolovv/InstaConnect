namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Builders;

public class GetPostCommentByIdApiRequestBuilderFactory
{
	public GetPostCommentByIdApiRequestBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
